using System.Diagnostics;

namespace NailWarehouse.ProductManager
{
    public class StopwatchWrapper
    {
        private readonly Stopwatch stopwatch = Stopwatch.StartNew();

        public T Execute<T>(Func<T> action)
        {
            try
            {
                T result = action();
                stopwatch.Stop();
                return result;
            }
            finally
            {
                stopwatch.Reset();
            }
        }
    }

}
