using System;
using System.Diagnostics;

namespace GenCode.Utils
{
    public class BenchmarkGenerateLineCodes
    {
        public static void StartBenchmark(
                int lineIndex = 1,
                int totalLines = 14,
                int startValue = 100,
                int initialCurrent = 100,
                int quantity = 1000000  // test số lượng lớn
)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            Base30AutoCodeGenerator.GenerateLineCodes(
                quantity: quantity
            );

            sw.Stop();

            Console.WriteLine($"⏱ Đã sinh {quantity} mã trên Line {lineIndex} trong {sw.ElapsedMilliseconds} ms ({sw.Elapsed.TotalSeconds:0.000} giây)");
        }
    }
}
