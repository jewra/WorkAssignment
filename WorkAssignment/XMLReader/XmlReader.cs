using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using WorkAssignment.Models;

namespace WorkAssignment.XMLReader
{
    public interface IXmlReader
    {
        IEnumerable<CustomerDto> Read();
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

        public IEnumerable<CustomerDto> Read()
        {
            var filePath = _environment.WebRootPath + _configuration["XML:Path"];
            var xmlDoc = XDocument.Load(filePath);

            var customers = new List<CustomerDto>();


            if (xmlDoc.Root != null)
                customers = xmlDoc.Root.Elements("contact").Select(element => new CustomerDto
                {
                    ContactNumber = element.Element("no")?.Value,
                    Salutation = GetGender(element.Element("gender")?.Value),
                    FirstName = element.Element("firstName")?.Value,
                    LastName = element.Element("surname")?.Value,
                    Email = element.Element("email")?.Value,
                    Language = element.Element("languageCode")?.Value == "DES"? "de":"eng",
                    LoyaltyProgram = bool.Parse(element.Element("loyaltyProgram")?.Value),
                    DiscountType = element.Element("discountType")?.Value,
                    Birthday = !string.IsNullOrEmpty(element.Element("dateOfBirth")?.Value)
                        ? DateTime.ParseExact(element.Element("dateOfBirth")?.Value, "yyyy-m-d", null)
                        : (DateTime?)null
                }).ToList();
            return customers;
        }

        private string GetGender(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "na";
            }

            switch (value.ToLower())
            {
                case "female":
                    return "ms";
                case "male":
                    return "mr";
                default:
                    return "na";
            }
        }
    }
}