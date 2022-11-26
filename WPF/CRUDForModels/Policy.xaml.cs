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
    /// Interaction logic for Policy.xaml
    /// </summary>
    public partial class Policy : Window
    {
        public Policy()
        {
            InitializeComponent();
            GetPolicy();

            AddNewPolicyGrid.DataContext = NewPolicy;
        }

        static IMapper Mapper = SetupMapper();
        PolicyDTO NewPolicy = new PolicyDTO();
        PolicyDTO selectedPolicy = new PolicyDTO();

        private static IMapper SetupMapper()
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg => cfg.AddMaps(typeof(PolicyDAL).Assembly)
                );
            return config.CreateMapper();
        }

        private void GetPolicy()
        {
            var dal = new PolicyDAL(Mapper);

            var policiesList = dal.GetAllPolicies();
            PolicyDG.ItemsSource = policiesList;
        }

        private void AddPolicy(object s, RoutedEventArgs e)
        {
            var dal = new PolicyDAL(Mapper);

            NewPolicy = dal.CreatePolicy(NewPolicy);

            GetPolicy();
            NewPolicy = new PolicyDTO();
            AddNewPolicyGrid.DataContext = NewPolicy;
        }

        private void DeletePolicy(object s, RoutedEventArgs e)
        {
            var policyToBeDeleted = (s as FrameworkElement).DataContext as PolicyDTO;

            var dal = new PolicyDAL(Mapper);
            dal.DeletePolicy(policyToBeDeleted);
            GetPolicy();
        }

        private void UpdatePolicyForEdit(object s, RoutedEventArgs e)
        {
            selectedPolicy = (s as FrameworkElement).DataContext as PolicyDTO;
            UpdatePolicyGrid.DataContext = selectedPolicy;
        }

        private void UpdatePolicy(object s, RoutedEventArgs e)
        {
            var dal = new PolicyDAL(Mapper);
            dal.EditPolicy(selectedPolicy);
            GetPolicy();
        }
    }
}

