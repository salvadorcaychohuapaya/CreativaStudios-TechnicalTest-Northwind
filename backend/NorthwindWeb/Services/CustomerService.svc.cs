using NorthwindWeb.Data;
using NorthwindWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace NorthwindWeb.Services
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CustomerService
    {
        private readonly NorthwindRepository _repository = new NorthwindRepository();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
                   UriTemplate = "GetCustomersByCountry?country={country}&pageNumber={pageNumber}&pageSize={pageSize}")]
        public List<Customer> GetCustomersByCountry(string country, string pageNumber, string pageSize)
        {
            int page = string.IsNullOrEmpty(pageNumber) ? 1 : int.Parse(pageNumber);
            int size = string.IsNullOrEmpty(pageSize) ? 10 : int.Parse(pageSize);

            var customers = _repository.GetCustomersByCountry(country, page, size);
            return new List<Customer>(customers);
        }
    }
}
