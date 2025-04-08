namespace WebApplication1
{
    internal static class Utils
    {
        internal static readonly string ConnectionString;

        static Utils() 
        {
            var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            ConnectionString = configuration.GetConnectionString("local");
        }
    }
}
