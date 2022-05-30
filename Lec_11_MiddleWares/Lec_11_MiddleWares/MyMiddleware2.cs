namespace Lec_11_MiddleWares
{
    public class MyMiddleware2
    {
        RequestDelegate next;
        public MyMiddleware2(RequestDelegate nextDelegate)
        {
            this.next = nextDelegate;
        }
        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path == "/short")
            {
                await context.Response.WriteAsync("class\n");

            }
            else
            {
                await next(context);
                //await context.Response.WriteAsync("class after\n");
            }

        }
    }
}
