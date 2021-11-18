using System.Collections.Generic;
using System.Linq;
using WorkAssignment.Models;
using WorkAssignment.XMLReader;

namespace WorkAssignment.Services
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDto> GetAll();
        CustomerDto GetByContactNumber(string number);
    }

    public class CustomerService : ICustomerService
    {
        private readonly IXmlReader _xmlReader;

        public CustomerService(IXmlReader xmlReader)
        {
            _xmlReader = xmlReader;
        }

        public IEnumerable<CustomerDto> GetAll()
        {
            return _xmlReader.Read();
        }

        public CustomerDto GetByContactNumber(string number)
        {
            return _xmlReader.Read().FirstOrDefault(customer => customer.ContactNumber == number);
        }
    }
}