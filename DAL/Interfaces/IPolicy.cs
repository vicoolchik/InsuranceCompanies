using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IPolicy
    {
        List<PolicyDTO> GetAllPolicies();
        PolicyDTO CreatePolicy(PolicyDTO policy);
        PolicyDTO DeletePolicyByID(int id);
        PolicyDTO EditPolicyByID(PolicyDTO policy, int id);

    }
}
