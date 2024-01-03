using EmployeeAPIProject.Models;
using EmployeeAPIProject.Repositories;

namespace EmployeeAPIProject.Services;

public class EmployeeStatusService : IEmployeeStatusService
{
    private readonly IEmployeeStatus _employeeStatusRepository;
    private readonly IEmployee _employeeRepository;
    public EmployeeStatusService(IEmployeeStatus employeeStatusRepository,IEmployee employeeRepository)
    {
        _employeeStatusRepository = employeeStatusRepository;
        _employeeRepository = employeeRepository;
    }

    public void Change(Guid id, Employee statusChangeRequest)
    {
        var employee = _employeeRepository.Get(id);
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

    public IEnumerable<EmployeeStatus> Get()
    {
        return _employeeStatusRepository.Get();
    }

    public EmployeeStatus Get(Guid id)
    {
        return _employeeStatusRepository.Get(id);
    }
}
