using Microsoft.EntityFrameworkCore;
using OrderService.Api.Controllers.Model;
using OrderService.Api.Database;
using OrderService.Api.Domain;
using OrderService.Api.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Api.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private OSContext context;

        public EmployeeRepository(OSContext context)
        {
            this.context = context;
        }

        public Employee Create(Employee model)
        {
            var result = this.context.Employees.Add(model);
            this.context.SaveChanges();
            return result.Entity;
        }

        public bool Delete(Func<Employee, bool> func)
        {
            var model = this.Get(func);
            var result = this.context.Employees.Remove(model);
            this.context.SaveChanges();
            return result.State == EntityState.Deleted;
        }

        public Employee Get(Func<Employee, bool> func)
        {
            return this.context.Employees.FirstOrDefault(func);
        }

        public IEnumerable<Employee> Search(EmployeeFilter filter)
        {
            var queryable = this.context.Employees.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Name))
            {
                queryable = queryable.Where(x => x.Name.ToLower().Contains(filter.Name.ToLower()));
            }

            if (!string.IsNullOrEmpty(filter.DocumentNumber))
            {
                queryable = queryable.Where(x => x.DocumentNumber.ToLower().Contains(filter.DocumentNumber.ToLower()));
            }

            if (filter.Gender.HasValue)
            {
                queryable = queryable.Where(x => x.Gender == filter.Gender.Value);
            }

            if (filter.BeginBirthDate.HasValue)
            {
                queryable = queryable.Where(x => filter.BeginBirthDate.Value >= x.BirthDate);
            }

            if (filter.EndBirthDate.HasValue)
            {
                queryable = queryable.Where(x => x.BirthDate <= filter.EndBirthDate.Value);
            }

            return queryable.AsEnumerable();
        }

        public Employee Update(Employee model)
        {
            var result = this.context.Employees.Update(model);
            this.context.SaveChanges();
            return result.Entity;
        }
    }
}
