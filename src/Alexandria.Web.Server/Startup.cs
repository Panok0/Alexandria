namespace Mpanagos.Alexandria.Web.Server;

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

using Mpanagos.Alexandria.Data;
using Mpanagos.Alexandria.Data.PostgreSql;
using Mpanagos.Alexandria.Data.Sqlite;

public class Startup
{
  public Startup(IConfiguration configuration, IWebHostEnvironment environment)
  {
    Configuration = configuration;
    Environment = environment;
  }

  private IConfiguration Configuration { get; set; }

  private IWebHostEnvironment Environment { get; set; }

  public void ConfigureServices(IServiceCollection services)
  {
    services.AddRazorPages();
    services.AddMvc();
    var provider = Configuration.GetConnectionString("DatabaseProvider");

    services.AddDbContext<AlexandriaDbContext>(
      options => _ = provider switch
      {
        "Sqlite" => options.UseSqlite(Configuration.GetConnectionString("Alexandria"), sqlite => sqlite
          .MigrationsAssembly(typeof(Mpanagos.Alexandria.Data.Sqlite.Migrations.AlexandriaDbContextModelSnapshot).Assembly.GetName().Name)),
        "PostgreSql" => options.UseNpgsql(Configuration.GetConnectionString("Alexandria"), npgsql => npgsql
          .MigrationsAssembly(typeof(ANpgSql).Assembly.GetName().Name)),
        _ => throw new ArgumentException($"Unsupported provider: {provider}"),
      });
  }

  public void Configure(IApplicationBuilder app)
  {
    if (Environment.IsDevelopment())
    {
      app.UseExceptionHandler("/Error");
      app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
      endpoints.MapControllers();
      endpoints.MapRazorPages();
    });
  }
}
