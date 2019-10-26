using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspDotNetCore_Mini.Interface
{
    public interface IWebHost
    {
        Task StartAsync();
    }
}
