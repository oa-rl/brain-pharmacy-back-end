using Core.Entities;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Infrastructure
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Companies.Any()) {
                    var companyData = File.ReadAllText("../Infrastructure/Data/SeedData/company2.json");
                    var companies = JsonSerializer.Deserialize<List<CompanyEntity>>(companyData)!;
                    foreach (var item in companies) { 
                        context.Companies.Add(item);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.Branches.Any())
                {
                    var branchData = File.ReadAllText("../Infrastructure/Data/SeedData/branch.json");
                    var branches = JsonSerializer.Deserialize<List<BranchEntity>>(branchData)!;
                    foreach (var item in branches)
                    {
                        context.Branches.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
