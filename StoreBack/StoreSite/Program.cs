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
 *Add-migrations:cr�er une migrations � partir du context dbcontext
 *Update-database:mettre � jour la databse � la derniere version de migrations cr��
 *Update-database [nom d'une migration]:mettre � jour la databse � la version de la migration en param�tre.
 *Get-Migrations: obtenir toutes les migrations cr��s
 */