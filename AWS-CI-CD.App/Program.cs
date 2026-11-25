var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/", () =>
{
    return Results.Ok(new { Message = "Hello, AWS CI/CD BEANSTALK!" });
});

app.Run();

public partial class Program { }