using NailWarehouse.ProductManager;
using NailWarehouse.Storage.Memory;
using Serilog;

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

            var serilogLogger = new LoggerConfiguration()
                .WriteTo.Seq("http://localhost:5341", apiKey: "P9byCpl4ZvC3z60Acp4l")
                .CreateLogger();

            var storage = new MemoryProductStorage();
            var manager = new ProductsManager(storage, serilogLogger);
            Application.Run(new MainForm(manager));
        }
    }
}
