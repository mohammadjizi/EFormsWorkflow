using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Workflow.Models;

namespace Workflow.Data.Configuration
{
    public class AppConfiguration : IEntityTypeConfiguration<App>
    {
        public void Configure(EntityTypeBuilder<App> builder)
        {
            //builder.Property(c => c.AppDetail).IsRequired();
        }
    }
}
