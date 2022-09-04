
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DefaultTemplate.DataAccess.Config.Common;
using DefaultTemplate.DataAccess.Entities;
using DefaultTemplate.DataAccess.Entities.Project;

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

    public class DevelopmentStageEntityConfig : BaseEntityConfig<DevelopmentStageEntity>
    {
        protected override void Config(EntityTypeBuilder<DevelopmentStageEntity> builder)
        {
            builder.ToTable("DevelopmentStages");
            builder.HasOne(x => x.StageName)
                .WithMany().HasForeignKey(x => x.StageNameId).Metadata.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
    
    public class DevelopmentStepEntityConfig : BaseEntityConfig<DevelopmentStepEntity>
    {
        protected override void Config(EntityTypeBuilder<DevelopmentStepEntity> builder)
        {
            builder.ToTable("DevelopmentSteps");
            builder.HasOne(x => x.StageName)
                .WithMany().HasForeignKey(x => x.StageNameId).Metadata.DeleteBehavior = DeleteBehavior.Restrict;
            builder.HasOne(x => x.Stage)
                .WithMany().HasForeignKey(x => x.StageId).Metadata.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
    
    public class WorkStepEntityConfig : BaseEntityConfig<WorkStepEntity>
    {
        protected override void Config(EntityTypeBuilder<WorkStepEntity> builder)
        {
            builder.ToTable("WorkSteps");
            builder.HasOne(x => x.StageName)
                .WithMany().HasForeignKey(x => x.StageNameId).Metadata.DeleteBehavior = DeleteBehavior.Restrict;
            
            builder.HasOne(x => x.Stage)
                .WithMany().HasForeignKey(x => x.StageId).IsRequired(false).Metadata.DeleteBehavior = DeleteBehavior.Restrict;
            builder.HasOne(x => x.Step)
                .WithMany().HasForeignKey(x => x.StepId).IsRequired(false).Metadata.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
