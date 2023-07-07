using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingSystem
{
    public class CreateAccountResponse
    {
        public string AccountNumber { get; set; } = null!;
        public string BankName { get; set; } = null!;
        public string BranchName { get; set; } = null!;
        public string IFSC { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string FathersName { get; set; } = null!;
        public string AccountType { get; set; } = null!;
        public string AadharNumber { get; set; } = null!;
        public string? PanNumber { get; set; }
        public string Email { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string AddressLine { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string DOB { get; set; }
        public double Balance { get; set; }
        public string Phone { get; set; } = null!;

        public CreateAccountResponse(AccountDetails accountDetails, string BankName, string BranchName)
        {
            this.AccountNumber = accountDetails.AccountNumber;
            this.IFSC = accountDetails.IFSC;
            this.BankName = BankName;
            this.BranchName = BranchName;
            this.Name = accountDetails.Name;
            this.FathersName = accountDetails.FathersName;
            this.AccountType = accountDetails.AccountType;
            this.AadharNumber = accountDetails.AadharNumber;
            // Validating if User is linking Pan to account
            if (accountDetails.PanNumber != null)
                this.PanNumber = accountDetails.PanNumber;
            this.Email = accountDetails.Email;
            this.Gender = accountDetails.Gender;
            this.AddressLine = accountDetails.Address.AddressLine;
            this.City = accountDetails.Address.City;
            this.State = accountDetails.Address.State;
            this.PostalCode = accountDetails.Address.PostalCode;
            this.Country = accountDetails.Address.Country;
            this.Phone = accountDetails.Phone;
            this.DOB = accountDetails.DOB.ToString("G");
            this.Balance = accountDetails.Balance;
        }
    }
}