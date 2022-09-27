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
          .MigrationsAssembly(typeof(Mpanagos.Alexandria.Data.Sqlite.Migrations.Initialmigration).Assembly.GetName().Name)),
        "PostgreSql" => options.UseNpgsql(Configuration.GetConnectionString("Alexandria"), npgsql => npgsql
          .MigrationsAssembly(typeof(Mpanagos.Alexandria.Data.PostgreSql.Migrations.InitialMigration).Assembly.GetName().Name)),
        _ => throw new ArgumentException($"Unsupported provider: {provider}"),
      });

    services.AddSwaggerGen(swag =>
    {
      swag.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Alexandria API", Version = "v1", });

      swag.DescribeAllParametersInCamelCase();
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

    app.UseSwagger();
    app.UseSwaggerUI(swag =>
    {
      swag.SwaggerEndpoint("/swagger/v1/swagger.json", "Alexandria API v1");
      swag.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
      swag.EnableDeepLinking();
      swag.EnableFilter();
      swag.EnableValidator();
      swag.DisplayOperationId();
      swag.DisplayRequestDuration();
      swag.ShowExtensions();
    });

    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
      endpoints.MapControllers();
      endpoints.MapRazorPages();
    });
  }
}
