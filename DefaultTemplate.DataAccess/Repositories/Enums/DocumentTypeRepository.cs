using AutoMapper;
using DefaultTemplate.DataAccess.Entities.Enums;
using DefaultTemplate.DataAccess.Repositories.Base;
using DefaultTemplate.Domain.Models.Documents;

namespace DefaultTemplate.DataAccess.Repositories.Enums;

public class DocumentTypeRepository : EnumRepository<EDocumentType, DocumentTypeEnumEntity>
{
    public DocumentTypeRepository(GbimContext gbimContext, IMapper mapper) : base(gbimContext, mapper)
    {
    }
    
    protected override void Update(EDocumentType model, DocumentTypeEnumEntity entity)
    {
        entity.Name = model.Name;
    }
}