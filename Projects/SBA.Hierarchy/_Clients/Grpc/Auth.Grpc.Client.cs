using Grpc.Net.Client;
using SBA.Projectz.Grpc.Model;

namespace SBA.Projectz.Grpc.Service;

public partial class AuthGrpcClient
{
  public readonly GrpcProjectzLookup.GrpcProjectzLookupClient projectzLookup;

  public AuthGrpcClient(string url)
  {
    var channel = GrpcChannel.ForAddress(url, new GrpcChannelOptions
    {
      // Credentials = ChannelCredentials.Insecure // <-- default https
    });

    projectzLookup = new GrpcProjectzLookup.GrpcProjectzLookupClient(channel);
  }
}