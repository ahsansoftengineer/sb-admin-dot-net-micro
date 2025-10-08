using Google.Protobuf.WellKnownTypes;


namespace GLOB.API.Extz;

public static partial class Exts
{
  public static IEndpointRouteBuilder MapFileToRoute(this IEndpointRouteBuilder app, string routePath, string filePath)
  {
    app.MapGet(routePath, async ctx =>
    {
      if (File.Exists(filePath))
      {
        ctx.Response.ContentType = "text/plain"; // or "application/octet-stream"
        var content = await File.ReadAllTextAsync(filePath);
        await ctx.Response.WriteAsync(content);
      }
      else
      {
        ctx.Response.StatusCode = StatusCodes.Status404NotFound;
        await ctx.Response.WriteAsync($"File not found: {filePath}");
      }
    });

    return app;
  }
}

