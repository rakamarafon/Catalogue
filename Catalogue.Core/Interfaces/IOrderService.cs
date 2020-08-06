using Catalogue.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalogue.Core.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<OrderResponseModel> SearchOrderAsync(string customerId, string query);
    }
}
