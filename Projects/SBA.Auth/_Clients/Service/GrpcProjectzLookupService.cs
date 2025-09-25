using SBA.Auth.Grpc;

namespace SBA._Clients.Service;

public class GrpcProjectzLookupService : GrpcProjectzLookup.GrpcProjectzLookupBase
{
  private readonly string _lookupService;
}