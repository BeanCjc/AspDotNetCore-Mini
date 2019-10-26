using System;
using System.Collections.Generic;
using System.Text;

namespace AspDotNetCore_Mini.Interface
{
    public interface IApplicationBuilder
    {
        IApplicationBuilder Use(Func<RequestDelegate, RequestDelegate> middleware);
        RequestDelegate Build();
    }
}
