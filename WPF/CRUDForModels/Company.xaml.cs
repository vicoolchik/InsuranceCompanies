using AutoMapper;
using DAL.Concrete;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF.CRUDForModels
{
    /// <summary>
    /// Interaction logic for Company.xaml
    /// </summary>
    public partial class Company : Window
    {
        public Company()
        {
            InitializeComponent();
            GetCompany();

            AddNewCompanyGrid.DataContext = NewCompany;
        }

        static IMapper Mapper = SetupMapper();
        CompanyDTO NewCompany = new CompanyDTO();
        CompanyDTO selectedCompany = new CompanyDTO();

        private static IMapper SetupMapper()
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg => cfg.AddMaps(typeof(CompanyDAL).Assembly)
                );
            return config.CreateMapper();
        }

        private void GetCompany()
        {
            var dal = new CompanyDAL(Mapper);

            var companiesList = dal.GetAllCompanies();
            CompanyDG.ItemsSource = companiesList;
        }

        private void AddCompany(object s, RoutedEventArgs e)
        {
            var dal = new CompanyDAL(Mapper);

            NewCompany = dal.CreateCompany(NewCompany);

            GetCompany();
            NewCompany = new CompanyDTO();
            AddNewCompanyGrid.DataContext = NewCompany;
        }

        private void DeleteCompany(object s, RoutedEventArgs e)
        {
            var companyToBeDeleted = (s as FrameworkElement).DataContext as CompanyDTO;

            var dal = new CompanyDAL(Mapper);
            dal.DeleteCompany(companyToBeDeleted);
            GetCompany();
        }

        private void UpdateCompanyForEdit(object s, RoutedEventArgs e)
        {
            selectedCompany = (s as FrameworkElement).DataContext as CompanyDTO;
            UpdateCompanyGrid.DataContext = selectedCompany;
        }

        private void UpdateCompany(object s, RoutedEventArgs e)
        {
            var dal = new CompanyDAL(Mapper);
            dal.EditCompany(selectedCompany);
            GetCompany();
        }
    }
}
