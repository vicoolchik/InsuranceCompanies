using AutoMapper;
using DAL.Interfaces;
using DAL.Models;
using DTO;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Concrete
{
   public  class PolicyDAL : IPolicy
    {
        private readonly IMapper _mapper;
        public PolicyDAL(IMapper mapper)
        {
            _mapper = mapper;
        }

        public PolicyDTO CreatePolicy(PolicyDTO policy)
        {
            using (var entites = new InsuranceCompaniesContext())
            {
                var policyInDB = _mapper.Map<Policy>(policy);
                entites.Policies.Add(policyInDB);
                entites.SaveChanges();
                return _mapper.Map<PolicyDTO>(policyInDB);
            }
        }

        public List<PolicyDTO> GetAllPolicies()
        {
            using (var entities = new InsuranceCompaniesContext())
            {
                var policies = entities.Policies.ToList();
                return _mapper.Map<List<PolicyDTO>>(policies);
            }
        }


        public PolicyDTO DeletePolicyByID(int id)
        {
            using (var entites = new InsuranceCompaniesContext())
            {
                var policyInDB = entites.Policies.SingleOrDefault(x => x.Id == id);
                if (policyInDB != null)
                {
                    entites.Policies.Remove(policyInDB);
                    entites.SaveChanges();
                    return _mapper.Map<PolicyDTO>(policyInDB);
                }
                return null;
            }
        }

        public PolicyDTO EditPolicyByID(PolicyDTO policy, int id)
        {
            using (var entites = new InsuranceCompaniesContext())
            {
                var policyInDB = _mapper.Map<Policy>(policy);
                policyInDB = entites.Policies.SingleOrDefault(x => x.Id == id);
                if (policyInDB != null)
                {
                    policyInDB.Price = policy.Price;
                    policyInDB.IssuedDate = policy.IssuedDate;
                    policyInDB.EndDate = policy.EndDate;
                    policyInDB.CompanyId = policy.CompanyId;
                    entites.SaveChanges();
                    return _mapper.Map<PolicyDTO>(policyInDB);
                }
                return null;
            }
        }

    }
}