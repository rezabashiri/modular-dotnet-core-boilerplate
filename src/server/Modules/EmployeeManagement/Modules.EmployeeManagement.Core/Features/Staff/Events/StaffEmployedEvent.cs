using Shared.Core.Domain;

namespace Modules.EmployeeManagement.Core.Features.Staff.Events;
public class StaffEmployedEvent : Event
{
    public Guid Id { get; }

    public string FullName { get; }

    public StaffEmployedEvent(Entities.StaffMember staffMember)
    {
        Id = staffMember.Id;
        FullName = $"{staffMember.Name} {staffMember.Family}";
        RelatedEntities = new[] { typeof(Entities.StaffMember) };
    }
}