

using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Modelo.Infra.Data.Oracle.Utilities
{
    public static class DbContextOptionsBuilderExtensions
    {
        public static OracleDbContextOptionsBuilder ApplyConfiguration(this OracleDbContextOptionsBuilder optionsBuilder)
        {
            var maxBatch = OracleEnvironment.GetInt(nameof(OracleDbContextOptionsBuilder.MaxBatchSize));
            if (maxBatch.HasValue)
            {
                optionsBuilder.MaxBatchSize(maxBatch.Value);
            }

            return optionsBuilder;
        }
    }
}
