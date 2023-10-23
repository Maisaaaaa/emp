using EmployeeInfo.Model.db;
using EmployeeInfo.Model.dto;

namespace EmployeeInfo.repo
{
    public interface IEmployeeRepo
    {
        Task<EmployeeDetails> GetAsync(string EmpCode);
        Task<EmployeeDetails> Create(empolyee employee);
        Task<String> Delete(string Empcode);
        Task<EmployeeDetails> UpdateRole(string Role, string Empcode);
    }
}
