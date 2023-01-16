
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DefaultTemplate.DataAccess.Config.Common;

namespace DefaultTemplate.DataAccess.Config
{
    public class ProjectEntityConfig : BaseEntityConfig<ProjectEntity>
    {
        protected override void Config(EntityTypeBuilder<ProjectEntity> builder)
        {
            builder.ToTable("Projects");
            builder.OwnsOne(x => x.Name);
            builder.OwnsOne(x => x.FullDescription);
            builder.OwnsOne(x => x.ShortDescription);

            builder.HasOne(x => x.ConstructionObject)
                .WithMany().HasForeignKey(x => x.ConstructionObjectId).Metadata.DeleteBehavior = DeleteBehavior.Restrict;
            builder.HasOne(x => x.ConstructionType)
                .WithMany().HasForeignKey(x => x.ConstructionTypeId).Metadata.DeleteBehavior = DeleteBehavior.Restrict;
            builder.HasOne(x => x.FinancingSource)
                .WithMany().HasForeignKey(x => x.FinancingSourceId).Metadata.DeleteBehavior = DeleteBehavior.Restrict;
            builder.HasOne(x => x.ProjectStatus)
                .WithMany().HasForeignKey(x => x.ProjectStatusId).Metadata.DeleteBehavior = DeleteBehavior.Restrict;

        }
    }

}
