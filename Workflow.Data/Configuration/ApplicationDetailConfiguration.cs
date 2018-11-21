using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workflow.Models;

namespace Workflow.Data.Configuration
{
    public class ApplicationDetailConfiguration : IEntityTypeConfiguration<ApplicationDetail>
    {
        public void Configure(EntityTypeBuilder<ApplicationDetail> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.AppNumber).IsRequired();
            builder.Property(c => c.DateCreated).IsRequired();
            builder.Property(c => c.AppDescription).IsRequired();
            builder.Property(c => c.RequestedBy).IsRequired();
        }
    }
}
