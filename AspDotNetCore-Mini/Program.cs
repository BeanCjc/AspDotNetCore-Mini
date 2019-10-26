using System;
using System.Threading.Tasks;

namespace AspDotNetCore_Mini
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await new WebHostBuilder()
                .UseHttpListenter()
                .Configue(app => app
                    .Use(FooMiddleWare)
                    .Use(BarMiddleWare)
                    .Use(BazMiddleWare))
                .Build()
                .StartAsync();
        }

        public static RequestDelegate FooMiddleWare(RequestDelegate next)
            => async context =>
            {
                await context.Response.WriteAsync("Foo =>");
                await next(context);
            };

        public static RequestDelegate BarMiddleWare(RequestDelegate next)
            => async context =>
            {
                await context.Response.WriteAsync("Bar =>");
                await next(context);
            };

        public static RequestDelegate BazMiddleWare(RequestDelegate next)
            => async context =>
            {
                await context.Response.WriteAsync("Baz");
                await next(context);
            };
    }
}
