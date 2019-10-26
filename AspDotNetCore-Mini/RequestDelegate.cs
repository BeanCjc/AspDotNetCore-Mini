using System.Threading.Tasks;

namespace AspDotNetCore_Mini
{
    public delegate Task RequestDelegate(HttpContext context);
}
