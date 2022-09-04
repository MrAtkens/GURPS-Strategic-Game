using AutoMapper;
using DefaultTemplate.DataAccess.Entities.Enums;
using DefaultTemplate.DataAccess.Repositories.Base;
using DefaultTemplate.Domain.Models.Enums;

namespace DefaultTemplate.DataAccess.Repositories.Enums;

public class DocumentVersionStatusRepository : EnumRepository<EDocumentVersionStatus, DocumentVersionStatusEntity>
{
    public DocumentVersionStatusRepository(GbimContext gbimContext, IMapper mapper) : base(gbimContext, mapper)
    {
    }

    protected override void Update(EDocumentVersionStatus model, DocumentVersionStatusEntity entity)
    {
        entity.Name = model.Name;
    }
}