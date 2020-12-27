using OrderService.Api.Domain;
using OrderService.Api.Domain.Filter;
using OrderService.Api.Repositories.Interface;
using OrderService.Api.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderService.Api.Service
{
    public class OsService : IOrderService
    {
        private IOrderRepository orderRepository;

        public OsService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public Order Create(Order model)
        {
            this.ValidateModelParams(model);
            return this.orderRepository.Create(model);
        }

        public Order Update(Order model)
        {
            this.ValidateModelParams(model);
            return this.orderRepository.Update(model);
        }

        public bool Delete(Func<Order, bool> func)
        {
            return this.orderRepository.Delete(func);
        }

        public Order Get(Func<Order, bool> func)
        {
            return this.orderRepository.Get(func);
        }

        public IEnumerable<Order> Search(OrderFilter filter)
        {
            return this.orderRepository.Search(filter);
        }

        private void ValidateModelParams(Order model)
        {
            if (model.EmployeeId == Guid.Empty)
            {
                throw new ArgumentException("Não é possível salvar uma Ordem de Serviço sem funcionário.");
            }

            if (model.CustomerId == Guid.Empty)
            {
                throw new ArgumentException("Não é possível salvar uma Ordem de Serviço sem cliente.");
            }

            if (model.Start >= model.Finish)
            {
                throw new ArgumentException("Hora de início não pode ser maior ou igual a hora de término da Ordem de Serviço.");
            }
        }
    }
}
