using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using SingleScope.Persistence.Benchmark.DataSource;

namespace SingleScope.Persistence.Benchmark
{
    [SimpleJob(RuntimeMoniker.Net80)]
    [SimpleJob(RuntimeMoniker.Net90)]
    [GroupBenchmarksBy(BenchmarkDotNet.Configs.BenchmarkLogicalGroupRule.ByCategory)]
    [MemoryDiagnoser]
    [CategoriesColumn, MinColumn, MaxColumn, OperationsPerSecond]
    [RPlotExporter]
    public class UseSingleScopePersistenceReadOnlyRepositoryBenchmarks
    {
        private static RoVirtualRepositoryImpl _virtualRepository = new();
        private static RoNonVirtualRepositoryImpl _nonVirtualRepository = new();

        //[Benchmark, BenchmarkCategory("Find_n")]
        //public void Find_n_Virtual()
        //{
        //    _virtualRepository.Find<NullEntity>(1);
        //}

        //[Benchmark(Baseline = true), BenchmarkCategory("Find_n")]
        //public void Find_n_NonVirtual()
        //{
        //    _nonVirtualRepository.Find<NullEntity>(1);
        //}

        //[Benchmark, BenchmarkCategory("FindAsync_2")]
        //public Task FindAsync_2_Virtual()
        //{
        //    return _virtualRepository.FindAsync<NullEntity>(1, CancellationToken.None);
        //}

        //[Benchmark(Baseline = true), BenchmarkCategory("FindAsync_2")]
        //public Task FindAsync_2_NonVirtual()
        //{
        //    return _nonVirtualRepository.FindAsync<NullEntity>(1, CancellationToken.None);
        //}

        //[Benchmark, BenchmarkCategory("FindAsync_2[]")]
        //public Task FindAsync_2arr_Virtual()
        //{
        //    return _virtualRepository.FindAsync<NullEntity>([1], CancellationToken.None);
        //}

        //[Benchmark(Baseline = true), BenchmarkCategory("FindAsync_2[]")]
        //public Task FindAsync_2arr_NonVirtual()
        //{
        //    return _nonVirtualRepository.FindAsync<NullEntity>([1], CancellationToken.None);
        //}

        //[Benchmark, BenchmarkCategory("Get_1")]
        //public NullEntity? Get_1_Virtual()
        //{
        //    return _virtualRepository.Get<NullEntity>(e => e.Id == 1);
        //}

        //[Benchmark(Baseline = true), BenchmarkCategory("Get_1")]
        //public NullEntity? Get_1_NonVirtual()
        //{
        //    return _nonVirtualRepository.Get<NullEntity>(e => e.Id == 1);
        //}

        //[Benchmark, BenchmarkCategory("Get_3")]
        //public NullEntity? Get_3_Virtual()
        //{
        //    return _virtualRepository.Get<NullEntity>(e => e.Id == 1, [], []);
        //}

        //[Benchmark(Baseline = true), BenchmarkCategory("Get_3")]
        //public NullEntity? Get_3_NonVirtual()
        //{
        //    return _nonVirtualRepository.Get<NullEntity>(e => e.Id == 1, [], []);
        //}

        //[Benchmark, BenchmarkCategory("GetAsync_2")]
        //public Task GetAsync_2_Virtual()
        //{
        //    return _virtualRepository.GetAsync<NullEntity>(e => e.Id == 1, CancellationToken.None);
        //}

        //[Benchmark(Baseline = true), BenchmarkCategory("GetAsync_2")]
        //public Task GetAsync_2_NonVirtual()
        //{
        //    return _nonVirtualRepository.GetAsync<NullEntity>(e => e.Id == 1, CancellationToken.None);
        //}

        //[Benchmark, BenchmarkCategory("GetAsync_4")]
        //public Task GetAsync_4_Virtual()
        //{
        //    return _virtualRepository.GetAsync<NullEntity>(e => e.Id == 1, [], [], CancellationToken.None);
        //}

        //[Benchmark(Baseline = true), BenchmarkCategory("GetAsync_4")]
        //public Task GetAsync_4_NonVirtual()
        //{
        //    return _nonVirtualRepository.GetAsync<NullEntity>(e => e.Id == 1, [], [], CancellationToken.None);
        //}

        [Benchmark, BenchmarkCategory("GetAll_0")]
        public NullEntity[] GetAll_0_Virtual()
        {
            return _virtualRepository.GetAll<NullEntity>();
        }

        [Benchmark(Baseline = true), BenchmarkCategory("GetAll_0")]
        public NullEntity[] GetAll_0_NonVirtual()
        {
            return _nonVirtualRepository.GetAll<NullEntity>();
        }

        [Benchmark, BenchmarkCategory("GetAllAsync_1")]
        public Task GetAllAsync_1_Virtual()
        {
            return _virtualRepository.GetAllAsync<NullEntity>(CancellationToken.None);
        }

        [Benchmark(Baseline = true), BenchmarkCategory("GetAllAsync_1")]
        public Task GetAllAsync_1_NonVirtual()
        {
            return _nonVirtualRepository.GetAllAsync<NullEntity>(CancellationToken.None);
        }

        [Benchmark, BenchmarkCategory("GetAllAsync_2")]
        public Task GetAllAsync_2_Virtual()
        {
            return _virtualRepository.GetAllAsync<NullEntity>([], CancellationToken.None);
        }

        [Benchmark(Baseline = true), BenchmarkCategory("GetAllAsync_2")]
        public Task GetAllAsync_2_NonVirtual()
        {
            return _nonVirtualRepository.GetAllAsync<NullEntity>([], CancellationToken.None);
        }
    }
}