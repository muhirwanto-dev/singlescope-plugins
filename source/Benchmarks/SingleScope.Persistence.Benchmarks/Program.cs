using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Running;

namespace SingleScope.Persistence.Benchmark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var summaryStyle = new BenchmarkDotNet.Reports.SummaryStyle(
                    cultureInfo: null,
                    printUnitsInHeader: false,
                    sizeUnit: Perfolizer.Metrology.SizeUnit.KB,
                    timeUnit: Perfolizer.Horology.TimeUnit.Microsecond,
                    printUnitsInContent: true,
                    printZeroValuesInContent: true
                    );

            var config = ManualConfig.Create(DefaultConfig.Instance)
                .WithSummaryStyle(summaryStyle)
                .AddExporter(new CsvExporter(CsvSeparator.CurrentCulture, summaryStyle));

            BenchmarkRunner.Run<UseSingleScopePersistenceReadOnlyRepositoryBenchmarks>(config, args);
        }
    }
}
