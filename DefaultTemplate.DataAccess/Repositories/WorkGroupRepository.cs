using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using DefaultTemplate.DataAccess.Entities.Workgroups;
using DefaultTemplate.DataAccess.Repositories.Base;
using DefaultTemplate.Domain.Models.WorkGroups;
using DefaultTemplate.Domain.Services.ContextService;
using DefaultTemplate.Domain.Services.WorkGroups;

namespace DefaultTemplate.DataAccess.Repositories;

public class WorkGroupRepository : BaseRepository<WorkGroup, WorkGroupEntity, WorkGroupQuery>, IWorkGroupRepository
{
    private readonly DbSet<WorkGroupMemberEntity> _membersDbSet;

    public WorkGroupRepository(GbimContext context, IMapper mapper, IContextService contextService) : base(context, mapper, contextService)
    {
        _membersDbSet = context.Set<WorkGroupMemberEntity>();
    }

    protected override Expression<Func<WorkGroup, object>>[] IncludeAggregated()
    {
        return new Expression<Func<WorkGroup, object>>[]
        {
            x => x.Members,
            x => x.Members.Select(y => y.Employee),
            x => x.Members.Select(y => y.Employee.FullName),
            x => x.Members.Select(y => y.Name),
            x => x.Members.Select(y => y.BussinessUnit),
            x => x.Members.Select(y => y.PostType),
        };
    }

    protected override void Update(WorkGroupEntity entity, WorkGroup model)
    {
        entity.WorkStepId = model.WorkStepId;
        entity.LinkedTypeId = model.LinkedTypeId;
        entity.LinkedId = model.LinkedId;

        var existsMembers = _membersDbSet.Where(m => m.WorkGroupId == entity.Id).ToArray();
        var members = model.Members;

        var membersForAdd = members?.Where(x => true).Select(x => new WorkGroupMemberEntity
        {
            Id = Guid.NewGuid(),
            WorkPlaceId = x.WorkPlaceId,
            Order = x.Order,
            WorkGroupId = model.Id,
            CreateById = _contextService.CurrentUser.Id,
            ModifiedById = _contextService.CurrentUser.Id,
            CreatedDate = DateTimeOffset.Now,
            ModifiedDate = DateTimeOffset.Now,
        }).ToArray();

        var membersForRemove = existsMembers.Where(x => !members!.Any(y => y.WorkPlaceId == x.WorkPlaceId)).ToArray();
        var membersForUpdate = existsMembers.Where(x => members!.Any(y => y.Id == x.Id));

        if (membersForAdd?.Any() == true)
            _membersDbSet.AddRange(membersForAdd);

        if (membersForRemove?.Any() == true)
            _membersDbSet.RemoveRange(membersForRemove);

        foreach (var member in membersForUpdate)
        {
            var existMember = existsMembers.FirstOrDefault(x => x.Id == member.Id);
            existMember!.Order = member.Order;
            existMember.ModifiedDate = DateTimeOffset.Now;
            existMember.ModifiedById = _contextService.CurrentUser.Id;
        }
    }
}