var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) => {
    context.Response.ContentType = "text/plain";
    await context.Response.WriteAsync("Aoa Pak...");
    await next();
});

app.Use(async (context, next) => {
    await context.Response.WriteAsync("Welcome to class");
    await next();
});

app.MapGet("/", () => "Hello World!");

app.Run();