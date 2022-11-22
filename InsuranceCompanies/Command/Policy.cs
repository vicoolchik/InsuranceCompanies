using AutoMapper;
using DAL.Concrete;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;


namespace InsuranceCompanies.Command
{
    class Policy
    {
        static IMapper Mapper = SetupMapper();

        private static IMapper SetupMapper()
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg => cfg.AddMaps(typeof(PolicyDAL).Assembly)
                );
            return config.CreateMapper();
        }

        internal void CreatePolicyCommand(decimal price, DateTime issuedDate, DateTime endDate, int companyId)
        {
            var dal = new PolicyDAL(Mapper);

            var policy = new PolicyDTO
            {
                Price = price,
                IssuedDate = issuedDate,
                EndDate = endDate,
                CompanyId = companyId,
            };
            policy = dal.CreatePolicy(policy);
            Console.WriteLine($"New policy ID : {policy.Id}");
        }


        internal void GetAllPoliciesCommand()
        {
            var dal = new PolicyDAL(Mapper);

            var policyInDB = dal.GetAllPolicies();

            Console.WriteLine($"\n|{"Id",-3}|{"IssuedDate",-30}|{"EndDate",-30}|{"Price",-10}|\n");
            foreach (var policy in policyInDB)
            {
                Console.WriteLine(policy.ToString());
            }
        }

        internal void EditPolicyCommand(int Id, decimal price, DateTime issuedDate, DateTime endDate, int companyId)
        {
            var dal = new PolicyDAL(Mapper);

            var policy = new PolicyDTO
            {
                Price = price,
                IssuedDate = issuedDate,
                EndDate = endDate,
                CompanyId = companyId,
            };
            policy = dal.EditPolicyByID(policy, Id);
            Console.WriteLine($"Edited policy ID : {(policy != null ? $"{ policy.Id}" : "null")}");
        }

        internal void DeletePolicyCommand(int Id)
        {
            var dal = new PolicyDAL(Mapper);
            var policy = dal.DeletePolicyByID(Id);

            Console.WriteLine($"Edited policy ID : {(policy != null ? $"{policy.Id}" : "null")}");
        }
    }
}
