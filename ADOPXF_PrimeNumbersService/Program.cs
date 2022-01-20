using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System.Text;

using ADOPXF_E_PrimeNumbersService.Models;
using ADOPXF_E_PrimeNumbersService.Services;

namespace ADOPXF_E_PrimeNumbersService
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var service = new PrimeNumberService();
            var progressReporter = new Progress<(float, string)>(value =>
            {
                Console.WriteLine(value.Item2);
            });

            var progressReporter1 = new Progress<float>(value =>
            {
                Console.WriteLine($"Reading batches progress: {value}");
            });

            Console.WriteLine("Get Primes using Progress reporter:");
            await service.DisplayPrimeCountsAsync(10, progressReporter);

            Console.WriteLine();
            Console.WriteLine("Get Primes using Progress reporter and List<PrimeBatch>:");
            var batches = await service.GetPrimeBatchCountsAsync(10, progressReporter1);

            Console.WriteLine();
            Console.WriteLine("List<PrimeBatch> Content:");
            Console.WriteLine($"Number of batches {batches.Count}");
            batches.ForEach(batch => Console.WriteLine(batch.ToString()));

        }
    }
}
