using AutoMapper;
using Catalogue.Core.Interfaces;
using Catalogue.DAL.Model;
using Catalogue.DAL.UnitOfWork;
using Catalogue.Models.Response;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalogue.Core.Services
{
    public class OrderService : IOrderService
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public IEnumerable<OrderResponseModel> SearchOrderAsync(string customerId, string query)
        {
            IQueryable<Orders> order = null;

            var temp = unitOfWork.OrderRepository.Get(x =>
                        x.Items.Where(item => item.Name.Contains(query)
                        || item.UPC.ToString().StartsWith(query)).Count() > 0)
                .Include(x => x.Items)
                .Include(x => x.User);

            order = temp;

            if(customerId != "manager")
            {
               order = order.Where(x => x.User.CustomerId == customerId);
            }
            
            if (order == null)
                throw new System.Exception("Order is not found");

            var result = mapper.Map<IEnumerable<OrderResponseModel>>(order.ToList());
            return result;
        }
    }
}