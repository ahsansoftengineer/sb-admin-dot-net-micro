using AutoMapper;
using Grpc.Core;
using Grpc.Net.Client;
using SBA.Projectz.Grpc.Model;

namespace SBA.Projectz.Grpc.Service;

public partial class ProjectzLookupClient
{
  private readonly IMapper _map;
  private readonly GrpcProjectzLookup.GrpcProjectzLookupClient _client;

  public ProjectzLookupClient(string grpcUrl)
  {
    var channel = GrpcChannel.ForAddress(grpcUrl, new GrpcChannelOptions
    {
      Credentials = ChannelCredentials.Insecure
    });

    _client = new GrpcProjectzLookup.GrpcProjectzLookupClient(channel);
  }
}