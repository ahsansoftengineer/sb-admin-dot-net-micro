using Grpc.Core;
using Grpc.Net.Client;
using SBA.Projectz.Grpc.Model;

namespace SBA.Projectz.Grpc.Service;

public partial class AuthGrpcClient
{
  public readonly GrpcProjectzLookup.GrpcProjectzLookupClient projectzLookup;

  public AuthGrpcClient(string url)
  {
    // AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true); // if using HTTP
    // AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2Support", true);
    var channel = GrpcChannel.ForAddress(url, new GrpcChannelOptions
    {
      // Credentials = ChannelCredentials.Insecure, // <-- default https
      // HttpHandler = new HttpClientHandler
      // {
      //     ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
      // }
    });

    projectzLookup = new GrpcProjectzLookup.GrpcProjectzLookupClient(channel);
  }
}