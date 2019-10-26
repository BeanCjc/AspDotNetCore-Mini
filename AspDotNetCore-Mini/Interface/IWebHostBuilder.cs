using System;
using System.Collections.Generic;
using System.Text;

namespace AspDotNetCore_Mini.Interface
{
    public interface IWebHostBuilder
    {
        IWebHostBuilder UseServer(IServer server);
        IWebHostBuilder Configue(Action<IApplicationBuilder> configure);
        IWebHost Build();
    }
}
