using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace NailWarehouse.ProductManager
{
    public static class StopwatchWrapper
    {
        private const string DefaultTimeLogTemplate = "{Operation} выполнилась за {ElapsedMilliseconds} мс";
        private const string DefaultOperationName = "Операция";

        /// <summary>
        /// Измеряет время выполнения асинхронной операции
        /// и регистрирует ее продолжительность.
        /// </summary>
        public static async Task<T> MeasureExecutionTimeAsync<T>(
            Func<Task<T>> func,
            ILogger logger,
            string operationName = DefaultOperationName
        )
        {
            var stopwatch = Stopwatch.StartNew();
            var result = await func();
            stopwatch.Stop();

            logger.LogInformation(DefaultTimeLogTemplate, operationName, stopwatch.ElapsedMilliseconds);

            return result;
        }

        /// <inheritdoc cref="MeasureExecutionTimeAsync{T}(Func{Task{T}}, ILogger, string)"/>
        public static async Task MeasureExecutionTimeAsync(
            Func<Task> func,
            ILogger logger,
            string operationName = DefaultOperationName
        )
        {
            var stopwatch = Stopwatch.StartNew();
            await func();
            stopwatch.Stop();

            logger.LogInformation(DefaultTimeLogTemplate, operationName, stopwatch.ElapsedMilliseconds);
        }
    }
}
