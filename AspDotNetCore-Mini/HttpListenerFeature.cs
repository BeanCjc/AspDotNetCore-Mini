using AspDotNetCore_Mini.Interface;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;

namespace AspDotNetCore_Mini
{
    public class HttpListenerFeature : IHttpRequestFeature, IHttpResponseFeature
    {
        private readonly HttpListenerContext _httpListenerContext;
        public HttpListenerFeature(HttpListenerContext httpListenerContext) => _httpListenerContext = httpListenerContext;
        Uri IHttpRequestFeature.Uri => _httpListenerContext.Request.Url;

        NameValueCollection IHttpRequestFeature.Headers => _httpListenerContext.Request.Headers;

        Stream IHttpRequestFeature.Body => _httpListenerContext.Request.InputStream;

        NameValueCollection IHttpResponseFeature.Headers => _httpListenerContext.Response.Headers;

        Stream IHttpResponseFeature.Body => _httpListenerContext.Response.OutputStream;

        int IHttpResponseFeature.StatusCode { get => _httpListenerContext.Response.StatusCode; set => _httpListenerContext.Response.StatusCode = value; }
    }
}
