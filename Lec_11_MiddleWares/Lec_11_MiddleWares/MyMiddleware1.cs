using System.IO;

namespace Lec_11_MiddleWares
{
    public class MyMiddleware1
    {
        RequestDelegate next;
        public MyMiddleware1(RequestDelegate nextDelegate)
        {
            Console.WriteLine("hello here*****************************\n");
            this.next = nextDelegate;
        }
        public async Task Invoke (HttpContext context)
        {
            Console.WriteLine("hello here&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&\n");

            await context.Response.WriteAsync("class  1\n");
            await next(context);
            await context.Response.WriteAsync("class 1 after\n");
        }
    }
}
