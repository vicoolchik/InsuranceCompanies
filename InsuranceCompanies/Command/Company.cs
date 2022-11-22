using AutoMapper;
using DAL.Concrete;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceCompanies.Command
{
    internal class Company
    {
        static IMapper Mapper = SetupMapper();

        private static IMapper SetupMapper()
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg => cfg.AddMaps(typeof(CompanyDAL).Assembly)
                );


            return config.CreateMapper();
        }

        internal void CreateCompanyCommand(string name, string address, string phone)
        {
            var dal = new CompanyDAL(Mapper);

            var company = new CompanyDTO
            {
                Name = name,
                Address = address,
                Phone= phone
            };
            company = dal.CreateCompany(company);
            Console.WriteLine($"New company ID : {company.Id}");
        }


        internal void PrintAllCompaniesCommand()
        {
            var dal = new CompanyDAL(Mapper);

            var companyList = dal.GetAllCompanies();

            Console.WriteLine($"\n|{"ID",-3}|{"Company Name",-10}|{"Phone",-18}|{"Address",-50}|\n");
            foreach (var company in companyList)
            {
                Console.WriteLine(company.ToString());
            }
        }

        internal void EditCategoryCommand(int Id, string name, string address, string phone)
        {
            var dal = new CompanyDAL(Mapper);

            var company = new CompanyDTO
            {
                Name = name,
                Address = address,
                Phone = phone
            };
            company = dal.EditCompanyByID(company, Id);
            Console.WriteLine($"Edited category ID : {(company != null ? $"{ company.Id}" : "null")}");
        }

        internal void DeleteCategoryCommand(int Id)
        {
            var dal = new CompanyDAL(Mapper);
            var company = dal.DeleteCompanyByID(Id);

            Console.WriteLine($"Edited category ID : {(company != null ? $"{company.Id}" : "null")}");
        }
    }
}

