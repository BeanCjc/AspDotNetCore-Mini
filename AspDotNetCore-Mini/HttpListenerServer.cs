using AspDotNetCore_Mini.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AspDotNetCore_Mini
{
    public class HttpListenerServer : IServer
    {
        private readonly HttpListener _httpListener;//采用现成的东西,asp.net core 内部重写了新的kestrel
        private readonly string[] _args;
        public HttpListenerServer(params string[] args)
        {
            _httpListener = new HttpListener();
            _args = args.Any() ? args : new string[] { "http://localhost:5001/" };
        }
        public async Task StartAsync(RequestDelegate handler)
        {
            Array.ForEach(_args, url => _httpListener.Prefixes.Add(url));
            _httpListener.Start();
            while (true)
            {
                var listenerContext = await _httpListener.GetContextAsync();
                var feature = new HttpListenerFeature(listenerContext);
                var features = new FeatureCollection().Set<IHttpRequestFeature>(feature).Set<IHttpResponseFeature>(feature);
                var httpContext = new HttpContext(features);
                await handler(httpContext);
                listenerContext.Response.Close();
            }
        }
    }
}
