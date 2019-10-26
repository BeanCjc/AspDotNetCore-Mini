using AspDotNetCore_Mini.Interface;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;

namespace AspDotNetCore_Mini
{
    public class HttpContext
    {
        public HttpContext(IFeatureCollection features)
        {
            Request = new HttpRequest(features);
            Response = new HttpResponse(features);
        }
        public HttpRequest Request { get; }
        public HttpResponse Response { get; }
    }

    public class HttpRequest : IHttpRequestFeature
    {
        private readonly IHttpRequestFeature _feature;
        public HttpRequest(IFeatureCollection features) => _feature = features.Get<IHttpRequestFeature>();
        public Uri Uri => _feature.Uri;
        public NameValueCollection Headers => _feature.Headers;
        public Stream Body => _feature.Body;
    }

    public class HttpResponse : IHttpResponseFeature
    {
        private readonly IHttpResponseFeature _feature;
        public HttpResponse(IFeatureCollection features) => _feature = features.Get<IHttpResponseFeature>();
        public NameValueCollection Headers => _feature.Headers;
        public Stream Body => _feature.Body;
        public int StatusCode { get => _feature.StatusCode; set => _feature.StatusCode = value; }
    }
}
