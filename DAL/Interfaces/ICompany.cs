using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface ICompany
    {
        List<CompanyDTO> GetAllCompanies();
        CompanyDTO CreateCompany(CompanyDTO company);
        CompanyDTO DeleteCompanyByID(int id);
        CompanyDTO EditCompanyByID(CompanyDTO company, int id);

    }
}
