namespace Alexandria.Web.Server;

using Mpanagos.Alexandria.Web.Server;

public static class Program
{
  public static async Task<int> Main(string[] args)
  {
    try
    {
      var host = CreateHostBuilder(args);

      await host.RunConsoleAsync();
      return 0;
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message);
      return 1;
    }
  }

  public static IHostBuilder CreateHostBuilder(string[] args)
    => Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(b =>
    {
      b.UseStartup<Startup>();
    });
}
