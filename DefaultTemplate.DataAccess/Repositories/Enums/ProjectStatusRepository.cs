using AutoMapper;
using DefaultTemplate.DataAccess.Entities.Enums;
using DefaultTemplate.DataAccess.Repositories.Base;
using DefaultTemplate.Domain.Models.Enums;


namespace DefaultTemplate.DataAccess.Repositories.Enums
{
    public class ProjectStatusRepository : EnumRepository<EProjectStatus, ProjectStatusEntity>
    {
        public ProjectStatusRepository(GbimContext gbimContext, IMapper mapper) : base(gbimContext, mapper)
        {
        }

        protected override void Update(EProjectStatus model, ProjectStatusEntity entity)
        {
            entity.Name = model.Name;
        }
    }
}
