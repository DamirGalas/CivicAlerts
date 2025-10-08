internal class Program
{
    private static void Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);
        builder.Services.AddHostedService<IncidentReportedWorker>();
        builder.Services.AddHostedService<IncidentStatusChangedWorker>();

        var host = builder.Build();
        host.Run();
    }
}