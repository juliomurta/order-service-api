﻿using Microsoft.EntityFrameworkCore;
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
    public class OrderRepository : IOrderRepository
    {
        private OSContext context;

        public OrderRepository(OSContext context)
        {
            this.context = context;
        }

        public Order Create(Order model)
        {
            var result = this.context.Orders.Add(model);
            this.context.SaveChanges();
            return result.Entity;
        }

        public bool Delete(Func<Order, bool> func)
        {
            var model = this.Get(func);
            var result = this.context.Orders.Remove(model);
            this.context.SaveChanges();
            return result.State == EntityState.Deleted;
        }

        public Order Get(Func<Order, bool> func)
        {
            return this.context.Orders.FirstOrDefault(func);
        }

        public IEnumerable<Order> Search(OrderFilter filter)
        {
            var queryable = this.context.Orders.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Description))
            {
                queryable = queryable.Where(x => x.Description.ToLower().Contains(filter.Description.ToLower()));
            }

            if (filter.EmployeeId != Guid.Empty)
            {
                queryable = queryable.Where(x => x.EmployeeId == filter.EmployeeId);
            }

            if (filter.CustomerId != Guid.Empty)
            {
                queryable = queryable.Where(x => x.CustomerId == filter.CustomerId);
            }

            return queryable.AsEnumerable();
        }

        public Order Update(Order model)
        {
            var result = this.context.Orders.Update(model);
            this.context.SaveChanges();
            return result.Entity;
        }
    }
}