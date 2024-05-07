using FluentAssertions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Modules.EmployeeManagement.Core.Features.Staff.Commands;
using Shared.Core.Exceptions;
using Xunit;

namespace Modules.EmployeeManagement.IntegrationTests.Staff.Command
{
    public class EmployeeStaffTests : BaseTest
    {
        private readonly IMediator _mediator;
        public EmployeeStaffTests()
        {
            _mediator = ServicieProvider.GetService<IMediator>();
        }


        [Fact]
        public async Task Handle_EmployStaffNewStaff_ShouldInsertInDataBase()
        {
            var newEmployee = await _mediator.Send(new EmployStaffCommand("123456", "Reza", "Bashiri", DateTime.Now));

            newEmployee.Data.Should().NotBeEmpty();
        }

        [Fact]
        public async Task Handle_EmpityRequiredFields_ShouldThrowException()
        {
            await Assert.ThrowsAnyAsync<CustomValidationException>(() => _mediator.Send(new EmployStaffCommand("", "", "", DateTime.Now)));

        }
    }
}