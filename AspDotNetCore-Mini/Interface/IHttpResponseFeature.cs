using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;

namespace AspDotNetCore_Mini.Interface
{
    public interface IHttpResponseFeature
    {
        NameValueCollection Headers { get; }
        Stream Body { get; }
        int StatusCode { get; set; }
    }
}
