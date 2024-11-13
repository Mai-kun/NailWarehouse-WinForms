using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace NailWarehouse.ProductManager
{
    public static class StopwatchWrapper
    {
        private const string DefaultTimeLogTemplate = "{Operation} executing in {Time}";
        private const string DefaultOperationName = "Operation";

        /// <summary>
        /// Измеряет время выполнения асинхронной операции
        /// и регистрирует его продолжительность.
        /// </summary>
        public static async Task<T> MeasureExecutionTimeAsync<T>(
            Func<Task<T>> func,
            ILogger logger,
            string operationName = DefaultOperationName,
            string logTemplate = DefaultTimeLogTemplate
        )
        {
            var stopwatch = Stopwatch.StartNew();
            var result = await func();
            stopwatch.Stop();

            logger?.LogInformation(logTemplate, operationName, stopwatch.ElapsedMilliseconds);

            return result;
        }

        /// <inheritdoc cref="MeasureExecutionTimeAsync{T}(Func{Task{T}}, ILogger, string, string)"/>
        public static async Task MeasureExecutionTimeAsync(
            Func<Task> func,
            ILogger logger,
            string operationName = DefaultOperationName,
            string logTemplate = DefaultTimeLogTemplate
        )
        {
            var stopwatch = Stopwatch.StartNew();
            await func();
            stopwatch.Stop();

            logger.LogInformation(logTemplate, operationName, stopwatch.ElapsedMilliseconds);
        }
    }
}
