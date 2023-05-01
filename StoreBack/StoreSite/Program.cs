namespace StoreSite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

/*
 *Add-migrations:créer une migrations à partir du context dbcontext
 *Update-database:mettre à jour la databse à la derniere version de migrations créé
 *Update-database [nom d'une migration]:mettre à jour la databse à la version de la migration en paramètre.
 *Get-Migrations: obtenir toutes les migrations créés
 */