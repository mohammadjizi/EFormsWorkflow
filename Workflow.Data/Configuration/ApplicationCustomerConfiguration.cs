using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workflow.Models;

namespace Workflow.Data.Configuration
{
    public class ApplicationCustomerConfiguration : IEntityTypeConfiguration<ApplicationCustomer>
    {
        public void Configure(EntityTypeBuilder<ApplicationCustomer> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.AccountNumber).IsRequired();
            builder.Property(c => c.IDNumber).IsRequired();
            builder.Property(c => c.IDType).IsRequired();
            builder.Property(c => c.FullName).IsRequired();

        }
    }
}
