using EmployeeAPIProject.Models;
using EmployeeAPIProject.Repositories;

namespace EmployeeAPIProject.Services
{
    public class EmployeeStatusService : IEmployeeStatusService
    {
        private readonly IEmployeeStatus _employeeStatusService;
        private readonly IEmployee _employeeRepository;
        public EmployeeStatusService(IEmployeeStatus employeeStatusService,IEmployee employeeRepository)
        {
            _employeeStatusService = employeeStatusService;
            _employeeRepository = employeeRepository;
        }

        public void ChangeStatus(Guid id, Employee statusChangeRequest)
        {
            var employee = _employeeRepository.GetEmployee(id);
            if (employee != null)
            {
                employee.EmployeeStatus.StatusId = statusChangeRequest.EmployeeStatus.StatusId;
                employee.StatusChangeChoice = statusChangeRequest.StatusChangeChoice;
                employee.StatusChangeDate = statusChangeRequest.StatusChangeChoice.ToLower() == "later"
                    ? statusChangeRequest.StatusChangeDate
                    : DateTime.Now;
                // Store the reason and additional property
                employee.StatusChangeReason = statusChangeRequest.StatusChangeReason;
                employee.StatusId = statusChangeRequest.StatusId;
                _employeeRepository.save();
            }

        }

        public IEnumerable<EmployeeStatus> GetEmployeeStatus()
        {
            return _employeeStatusService.GetEmployeeStatus();
        }
      
    }
}
