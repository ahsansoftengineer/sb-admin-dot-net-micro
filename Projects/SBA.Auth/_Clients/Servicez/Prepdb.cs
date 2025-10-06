namespace SBA.Projectz.Grpc.Service;

public static class ProjectzLookupGrpcSeed
{
    public static void PrepPopulation(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var grpcClient = scope.ServiceProvider.GetSrvc<ProjectzLookupClient>();
        // var list = grpcClient.Gets();
        // var uow = scope.ServiceProvider.GetSrvc<IUOW_Projectz>();

        // SeedData(uow, list);
    }
    
    private static void SeedData(IUOW_Projectz uow, IEnumerable<ProjectzLookup> list)
    {
        if (uow.ProjectzLookups.Gets().Result.Any()) return;

        foreach (var item in list)
        {
            uow.ProjectzLookups.Add(item);
        }

        uow.Save();
    }

}