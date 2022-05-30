using Lec_11_MiddleWares;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.UseMiddleware<MyMiddleware1>();
app.UseMiddleware<MyMiddleware2>();

app.MapGet("/", () => "Hello World!");


/*app.Use(async (context, next) => {
    context.Response.ContentType = "text/plain";
    await context.Response.WriteAsync("Welcome to class\n");
    await next();
    await context.Response.WriteAsync("Welcome to class after\n");
});
app.Use(async (context, next) => {
    await context.Response.WriteAsync("Aoa Pak...\n");
    await next();
    if (context.Request.Query["someData"].Equals("abc")){
        await context.Response.WriteAsync("Aoa Pak after...\n");
    }
});*/
app.Run(async (context) => {
    await context.Response.WriteAsync("last mw...\n");
});

app.Run();