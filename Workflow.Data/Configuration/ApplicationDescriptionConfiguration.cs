using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workflow.Models;

namespace Workflow.Data.Configuration
{
    public class ApplicationDescriptionConfiguration : IEntityTypeConfiguration<ApplicationDescription>
    {
        public void Configure(EntityTypeBuilder<ApplicationDescription> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.AppCode).IsRequired();
            builder.Property(c => c.AppType).IsRequired();
        }
    }
}
