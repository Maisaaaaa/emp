using Dapper;
using EmployeeInfo.Model.Data;
using EmployeeInfo.Model.db;
using EmployeeInfo.Model.dto;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Data;


namespace EmployeeInfo.repo
{
    public class EmpolyeeRepo : IEmployeeRepo
    {
        private readonly DapperDBContext context;
        String EmployeeTableName = nameof(EmployeeDetails);
        public EmpolyeeRepo(DapperDBContext context)
        {
            this.context = context;

        }

        public async Task<EmployeeDetails> Create(empolyee employee)
        {
            string result = $"Insert into {EmployeeTableName} (Name,EmpCode,Role)VALUES('{employee.Name}','{employee.EmpCode}','{employee.Role}')";


            using (var connect = this.context.CreateConnection())
            {
                try
                {
                    var created = await connect.ExecuteAsync(result);
                    if (created >= 1)
                    {
                        var createdEmp = await GetAsync(employee.EmpCode);
                        return createdEmp;

                    }
                    else return null;

                }
                catch (Exception ex)
                {
                    return null;
                }
            }

        }
        public async Task<EmployeeDetails> GetAsync(string Empcode)
        {
            string result = $"select * from {EmployeeTableName} where Empcode='{Empcode}'";
            using (var connect = this.context.CreateConnection())
            {
                try
                {
                    var employee = await connect.QueryFirstOrDefaultAsync<EmployeeDetails>(result);
                    return employee;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public async Task<String> Delete(string Empcode)
        {
            string result = $"DELETE FROM {EmployeeTableName} where Empcode='{Empcode}'";
            using (var connect = this.context.CreateConnection())
            {
                try
                {
                    var employee = await connect.ExecuteAsync(result);
                    if (employee == 1)
                    {
                        return "Employee Deleted";
                    }
                    else
                    {
                        return "Employee not found";
                    }
                }
                catch (Exception ex)
                {

                    return null;
                }
            }
        }

        public async Task<EmployeeDetails> UpdateRole(string Role, string Empcode)
        {
            string result = $"UPDATE   {EmployeeTableName} set Role='{Role}' where Empcode = '{Empcode}'";
            using (var connect = this.context.CreateConnection())
            {
                try
                {
                    var employee = await connect.ExecuteAsync(result);
                    if (employee == 1)
                    {
                        return await GetAsync(Empcode);
                    }
                    else
                        return null;
                }
                catch (Exception ex)
                {

                    return null;
                }
            }
        }


    }
}
