using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using WorkAssignment.Service.Models;

namespace WorkAssignment.Service.XMLReader
{
    public interface IXmlReader
    {
        IEnumerable<CustomerDto> ReadAll();
        CustomerDto ReadByNumber(string contactNumber);
    }

    public class XmlReader : IXmlReader
    {
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _environment;


        public XmlReader(IConfiguration configuration, IHostingEnvironment environment)
        {
            _configuration = configuration;
            _environment = environment;
        }

        public IEnumerable<CustomerDto> ReadAll()
        {
            var filePath = _environment.WebRootPath + _configuration["XML:Path"];
            var xmlDoc = XDocument.Load(filePath);

            var customerDtos = new List<CustomerDto>();


            if (xmlDoc.Root != null)
                customerDtos = xmlDoc.Root.Elements("contact").Select(element => new CustomerDto
                {
                    ContactNumber = element.Element("no")?.Value,
                    Salutation = element.Element("gender")?.Value,
                    FirstName = element.Element("firstName")?.Value,
                    LastName = element.Element("surname")?.Value,
                    Email = element.Element("email")?.Value,
                    Language = element.Element("languageCode")?.Value,
                    LoyaltyProgram = bool.Parse(element.Element("loyaltyProgram")?.Value),
                    DiscountType = element.Element("MarketingDescription")?.Value,
                    Birthday = !string.IsNullOrEmpty(element.Element("dateOfBirth")?.Value)
                        ? DateTime.ParseExact(element.Element("dateOfBirth")?.Value, "yyyy-m-d", null)
                        : (DateTime?)null
                }).ToList();
            return
            customerDtos;
        }

        public CustomerDto ReadByNumber(string contactNumber)
        {
            var filePath = _environment.WebRootPath + _configuration["XML:Path"];
            var xmlDoc = XDocument.Load(filePath);

            var customerDtos = new List<CustomerDto>();
      


            if (xmlDoc.Root != null)
                customerDtos = xmlDoc.Root.Elements("contact").Select(element => new CustomerDto
                {
                    ContactNumber = element.Element("no")?.Value,
                    Salutation = element.Element("gender")?.Value,
                    FirstName = element.Element("firstName")?.Value,
                    LastName = element.Element("surname")?.Value,
                    Email = element.Element("email")?.Value,
                    Language = element.Element("languageCode")?.Value,
                    LoyaltyProgram = bool.Parse(element.Element("loyaltyProgram")?.Value),
                    DiscountType = element.Element("MarketingDescription")?.Value,
                    Birthday = !string.IsNullOrEmpty(element.Element("dateOfBirth")?.Value)
                        ? DateTime.ParseExact(element.Element("dateOfBirth")?.Value, "yyyy-m-d", null)
                        : (DateTime?)null
                }).ToList();
            return customerDtos.SingleOrDefault(x => x.ContactNumber == contactNumber);
        }
    }
}