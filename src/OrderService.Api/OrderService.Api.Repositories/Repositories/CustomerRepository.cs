﻿using Microsoft.EntityFrameworkCore;
using OrderService.Api.Database;
using OrderService.Api.Domain;
using OrderService.Api.Domain.Filter;
using OrderService.Api.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Api.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private OSContext context;

        public CustomerRepository(OSContext context)
        {
            this.context = context;
        }

        public Customer Create(Customer model)
        {
            var result = this.context.Customers.Add(model);
            this.context.SaveChanges();
            return result.Entity;
        }

        public bool Delete(Func<Customer, bool> func)
        {
            var model = this.Get(func);
            var result = this.context.Customers.Remove(model);
            this.context.SaveChanges();
            return result.State == EntityState.Detached;
        }

        public Customer Get(Func<Customer, bool> func)
        {
             var customer = this.context.Customers.FirstOrDefault(func);
             if (customer != null)
             {
                 customer.Orders = this.context.Orders.Where(x => x.CustomerId == customer.Id).ToList();
             }

             return customer;
        }

        public IEnumerable<Customer> Search(CustomerFilter filter)
        {
            var queryable = this.context.Customers.AsQueryable();

            if (!string.IsNullOrEmpty(filter.DocumentNumber))
            {
                queryable = queryable.Where(x => x.DocumentNumber.ToLower().Contains(filter.DocumentNumber.ToLower()));
            }

            if (!string.IsNullOrEmpty(filter.Name))
            {
                queryable = queryable.Where(x => x.Name.ToLower().Contains(filter.Name.ToLower()));
            }

            return queryable.Skip((filter.Page - 1) * filter.PageSize).Take(filter.PageSize).ToList();
        }

        public Customer Update(Customer model)
        {
            var result = this.context.Customers.Update(model);
            this.context.SaveChanges();
            return result.Entity;
        }
    }
}
