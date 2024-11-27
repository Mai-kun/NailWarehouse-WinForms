using NailWarehouse.Forms;
using NailWarehouse.ProductManager;
using NailWarehouse.Database;
using Serilog.Extensions.Logging;
using Microsoft.Extensions.Logging;
using Serilog;

namespace NailWarehouse
{
    static internal class Program
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

            var logger = new SerilogLoggerFactory(serilogLogger)
                .CreateLogger<ProductsManager>();

            var storage = new ProductStorage();
            var manager = new ProductsManager(storage, logger);
            Application.Run(new MainForm(manager));
        }
    }
}
