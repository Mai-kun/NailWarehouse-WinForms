using Microsoft.Extensions.Logging;
using NailWarehouse.ProductManager;
using NailWarehouse.Storage.Memory;

namespace NailWarehouse
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var logger = LoggerFactory.Create(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Debug);
                builder.AddDebug();
            }).CreateLogger(nameof(ProductsManager));

            var storage = new MemoryProductStorage();
            var manager = new ProductsManager(storage, logger);
            Application.Run(new MainForm(manager));
        }
    }
}
