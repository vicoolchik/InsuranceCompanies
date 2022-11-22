using InsuranceCompanies.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace InsuranceCompanies
{
	class Menu
	{

		private Company companyCommand = new Company();
		private Policy policyCommand = new Policy();

		public void runMenu()
		{
			showMenuOption();
		}


		private void showMenuOption()
		{
			char userInput = ' ';
			while (userInput != '0')
			{
				Console.Clear();
				Console.WriteLine("Welcome to the Insurance Companies\n");
				Console.WriteLine("Please select an option:\n");
				Console.WriteLine("1) Work with Company");
				Console.WriteLine("2) Work with Policy");
				Console.WriteLine("0) Exit");
				Console.Write("Your choice : ");

				userInput = Console.ReadKey().KeyChar;
				selectShowMenuOption(userInput);
			}
		}

		private void selectShowMenuOption(char userInput)
		{
			switch (userInput)
			{
				case '1':
					showCompaniesMenu();
					break;
				case '2':
					showPoliciesMenu();
					break;
				case '0':
					break;
				default:
					printDefaultSwitchStringMenu();
					break;
			}
		}

		private void showCompaniesMenu()
		{
			char userInput = ' ';
			while (userInput != '0')
			{
				Console.Clear();
				companyCommand.PrintAllCompaniesCommand();
				Console.WriteLine();
				Console.WriteLine("1) Create company");
				Console.WriteLine("2) Edit company");
				Console.WriteLine("3) Delete company");
				Console.WriteLine("0) Exit");
				Console.Write("Your choice : ");

				userInput = Console.ReadKey().KeyChar;
				selectCompaniesMenuOption(userInput);
			}
		}

		private void selectCompaniesMenuOption(char userInput)
		{
			switch (userInput)
			{
				case '1':
					AddCompanyMenu();
					break;
				case '2':
					ChangeCompanyMenu();
					break;
				case '3':
					DeleteCompanyMenu();
					break;
				case '0':
					break;
				default:
					printDefaultSwitchStringMenu();
					break;
			}
		}

		private void DeleteCompanyMenu()
		{
			Console.Clear();
			int? companyId = null;
			while (!(companyId is int)) companyId = TrySelectCompanyByIDMenu();

			companyCommand.DeleteCategoryCommand((int)companyId);
		}

		private int? TrySelectCompanyByIDMenu()
		{
			Console.Clear();
			companyCommand.PrintAllCompaniesCommand();

			int companyId;

			Console.Write("\nSelect the company id : ");

			bool success = int.TryParse(Console.ReadLine(), out companyId);
			return success ? (int?)companyId : (int?)null;
		}

		private void ChangeCompanyMenu()
		{
			int? companyId = null;
			while (!(companyId is int)) companyId = TrySelectCompanyByIDMenu();

			Console.Clear();
			Console.WriteLine("Enter a new name of the company : ");
			string companyName = Console.ReadLine();
			Console.WriteLine("Enter a new address of the company : ");
			string address = Console.ReadLine();
			Console.WriteLine("Enter a new phone of the company : ");
			string phone = Console.ReadLine();

			companyCommand.EditCategoryCommand((int)companyId, companyName, address, phone);
		}

		private void AddCompanyMenu()
		{
			Console.Clear();
			Console.WriteLine("Enter the name of the company : ");
			string companyName = Console.ReadLine();
			Console.WriteLine("Enter the address of the company : ");
			string address = Console.ReadLine();
			Console.WriteLine("Enter the phone of the company : ");
			string phone= Console.ReadLine();

			companyCommand.CreateCompanyCommand(companyName, address, phone);

		}

		private void showPoliciesMenu()
		{
			char userInput = ' ';
			while (userInput != '0')
			{
				Console.Clear();
				policyCommand.GetAllPoliciesCommand();
				Console.WriteLine();
				Console.WriteLine("1) Create policy");
				Console.WriteLine("2) Edit policy");
				Console.WriteLine("3) Delete policy");
				Console.WriteLine("0) Exit");
				Console.Write("Your choice : ");

				userInput = Console.ReadKey().KeyChar;
				selectPoliciesMenuOption(userInput);
			}
		}

		private void selectPoliciesMenuOption(char userInput)
		{
			switch (userInput)
			{
				case '1':
					CreatePoliciesMenu();
					break;
				case '2':
					EditPoliciesMenu();
					break;
				case '3':
					DeletePoliciesMenu();
					break;
				case '0':
					break;
				default:
					printDefaultSwitchStringMenu();
					break;
			}
		}

		private void DeletePoliciesMenu()
		{
			Console.Clear();
			int? policyId = null;
			while (!(policyId is int)) policyId = TrySelectPoliciesByIDMenu();

			policyCommand.DeletePolicyCommand((int)policyId);
		}

		private void CreatePoliciesMenu()
		{
			Console.Clear();
			Console.WriteLine("Enter the price of the policy : ");
			decimal price;
			decimal.TryParse(Console.ReadLine(), out price);
			Console.WriteLine("Enter the issued date of the policy : ");
			DateTime issuedDate = DateTime.Parse(Console.ReadLine());
			Console.WriteLine("Enter the end date of the policy : ");
			DateTime endDate = DateTime.Parse(Console.ReadLine());
			Console.WriteLine("Enter the company id  of the policy : ");
			int companyId;
			int.TryParse(Console.ReadLine(), out companyId);
			policyCommand.CreatePolicyCommand(price, issuedDate, endDate, companyId);
		}

		private void EditPoliciesMenu()
		{
			int? policyId = null;
			while (!(policyId is int)) policyId = TrySelectPoliciesByIDMenu();

			Console.Clear();
			Console.WriteLine("Enter new price of the policy : ");
			decimal price;
			decimal.TryParse(Console.ReadLine(), out price);
			Console.WriteLine("Enter new the issued date of the policy : ");
			DateTime issuedDate = DateTime.Parse(Console.ReadLine());
			Console.WriteLine("Enter new the end date of the policy : ");
			DateTime endDate = DateTime.Parse(Console.ReadLine());
			Console.WriteLine("Enter a new company id  of the policy : ");
			int companyId;
			int.TryParse(Console.ReadLine(), out companyId);

			policyCommand.EditPolicyCommand((int)policyId, price, issuedDate, endDate, companyId);
		}

		private int? TrySelectPoliciesByIDMenu()
		{
			Console.Clear();
			policyCommand.GetAllPoliciesCommand();

			int policyId;

			Console.Write("\nSelect the policy id : ");

			bool success = int.TryParse(Console.ReadLine(), out policyId);
			return success ? (int?)policyId : (int?)null;
		}

		private void printDefaultSwitchStringMenu()
		{
			Console.WriteLine("\nWrong command selected");
		}
	}
}

