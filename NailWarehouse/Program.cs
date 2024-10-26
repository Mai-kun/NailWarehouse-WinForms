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
            using var factory = LoggerFactory.Create(builder => builder.AddDebug());
            var logger = factory.CreateLogger("NailWarehouse.ProductManager");

            var storage = new MemoryProductStorage();
            var manager = new ProductsManager(storage, logger);
            Application.Run(new MainForm(manager));
        }
    }
}
