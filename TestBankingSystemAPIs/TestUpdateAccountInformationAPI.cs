using Xunit;
using Microsoft.AspNetCore.Mvc;
namespace BankingSystem
{
    public class TestUpdateAccountInformationAPI
    {
        private readonly UpdatedAccountInformationApi _updatedAccountInformation;
        public TestUpdateAccountInformationAPI()
        {
            _updatedAccountInformation = new UpdatedAccountInformationApi();
            Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Testing");
            Environment.SetEnvironmentVariable("ACCOUNTCOLLECTION", "accounts");
            Environment.SetEnvironmentVariable("BRANCHCOLLECTION", "branch");
            Environment.SetEnvironmentVariable("BANKCOLLECTION", "bank");
            Environment.SetEnvironmentVariable("CLIENT", "mongodb://localhost:27017");
            Environment.SetEnvironmentVariable("DATABASE", "BankingSystemLF");
        }

        ///
        /// 
        /// AccountNumber Validations & Verification tests
        /// ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓
        ///
        ///
        [Fact]
        public void UpdatedAccountInformation_EverythingCorrect_ReturnsOk()
        {
            ///Arrange 
            string AccountNumber = "716447224623";
            UpdatedAccountInformationRequest UpdateInformation = new UpdatedAccountInformationRequest(){AccountNumber = AccountNumber, AddressLine = "Near Vijuliya"};
            UpdateInformation.AccountNumber = AccountNumber;
            ///Act
            var Result = _updatedAccountInformation.GetUpdatedAccountInformation(UpdateInformation, AccountNumber);
            var UpdatedResult = Result as ObjectResult;
            ///Assert
            Assert.NotNull(UpdatedResult);
            Assert.Equal(200, UpdatedResult.StatusCode);
        }

        [Fact]
        public void UpdateAccountInformation_AccountNumberAsNull_ReturnsError()
        {
            ///Arrange 
            string AccountNumber = null!;
            UpdatedAccountInformationRequest UpdateInformation = new UpdatedAccountInformationRequest(){AccountNumber = AccountNumber};
            ///Act
            var Result = _updatedAccountInformation.GetUpdatedAccountInformation(UpdateInformation, AccountNumber);
            var UpdatedResult = Result as ObjectResult;
            ///Assert
            Assert.NotNull(UpdatedResult);
            Assert.Equal(new{Error = "Please Provide Your Account Number"}, UpdatedResult.Value);
        }

        [Fact]
        public void UpdatedAccountInformation_IncorrectAccountNumber_ReturnsError()
        {
            ///Arrange 
            string AccountNumber = "716447&%&%$3";
            UpdatedAccountInformationRequest UpdateInformation = new UpdatedAccountInformationRequest(){AccountNumber = AccountNumber};
            UpdateInformation.AccountNumber = AccountNumber;
            ///Act
            var Result = _updatedAccountInformation.GetUpdatedAccountInformation(UpdateInformation, AccountNumber);
            var UpdatedResult = Result as ObjectResult;
            ///Assert
            Assert.NotNull(UpdatedResult);
            Assert.Equal(new {Error = "Account Number is Not Valid"}, UpdatedResult.Value);
        }

        [Fact]
        public void UpdatedAccountInformation_UnKnownAccountNumber_ReturnsNotFound()
        {
            ///Arrange 
            string AccountNumber = "716447224603";
            UpdatedAccountInformationRequest UpdateInformation = new UpdatedAccountInformationRequest(){AccountNumber = AccountNumber, AccountType = "", PostalCode = "", City = "", State = "", Phone = ""};
            UpdateInformation.AccountNumber = AccountNumber;
            ///Act
            var Result = _updatedAccountInformation.GetUpdatedAccountInformation(UpdateInformation, AccountNumber);
            var UpdatedResult = Result as ObjectResult;
            ///Assert
            Assert.NotNull(UpdatedResult);
            Assert.Equal(404, UpdatedResult.StatusCode);
            Assert.Equal(new {Error = "Account Number "+UpdateInformation.AccountNumber+"'s User Doesn't Exists."}, UpdatedResult.Value);
        }
        [Fact]
        public void UpdatedAccountInformation_Existing_Details_ReturnsError()
        {
            ///Arrange 
            string AccountNumber = "716447224623";
            UpdatedAccountInformationRequest UpdateInformation = new UpdatedAccountInformationRequest(){AccountNumber = AccountNumber, AccountType = "savings"};
            UpdateInformation.AccountNumber = AccountNumber;
            ///Act
            var Result = _updatedAccountInformation.GetUpdatedAccountInformation(UpdateInformation, AccountNumber);
            var UpdatedResult = Result as ObjectResult;
            ///Assert
            Assert.NotNull(UpdatedResult);
            Assert.Equal(new {Error = "Please Enter Something to Update, EveryThing looks Same"}, UpdatedResult.Value);
        }
        [Fact]
        public void UpdatedAccountInformation_IncorrectAccountType_ReturnsError()
        {

            ///Arrange 
            string AccountNumber = "716447224623";
            UpdatedAccountInformationRequest UpdateInformation = new UpdatedAccountInformationRequest(){AccountNumber = AccountNumber, AccountType = "savin"};
            UpdateInformation.AccountNumber = AccountNumber;
            ///Act
            var Result = _updatedAccountInformation.GetUpdatedAccountInformation(UpdateInformation, AccountNumber);
            var UpdatedResult = Result as ObjectResult;
            ///Assert
            Assert.NotNull(UpdatedResult);
            Assert.Equal(new {Error = "Account Type "+UpdateInformation.AccountType+" is Not Valid. We Only Offer Savings, Current & Salary"}, UpdatedResult.Value);
        }

        

        [Fact]
        public void UpdatedAccountInformation_IncorrectAddressLine_ReturnsError()
        {
            ///Arrange 
            string AccountNumber = "716447224623";
            UpdatedAccountInformationRequest UpdateInformation = new UpdatedAccountInformationRequest(){AccountNumber = AccountNumber, AccountType = "savings", AddressLine = "jgasdf&^$#$&^$#", City = "", State ="", PostalCode = "", Phone = ""};
            UpdateInformation.AccountNumber = AccountNumber;
            ///Act
            var Result = _updatedAccountInformation.GetUpdatedAccountInformation(UpdateInformation, AccountNumber);
            var UpdatedResult = Result as ObjectResult;
            ///Assert
            Assert.NotNull(UpdatedResult);
            Assert.Equal(new {Error = "Address Line: "+UpdateInformation.AddressLine+" is INVALID!"}, UpdatedResult.Value);
        }

           

        [Fact]
        public void UpdatedAccountInformation_IncorrectCity_ReturnsError()
        {

            ///Arrange 
            string AccountNumber = "716447224623";
            UpdatedAccountInformationRequest UpdateInformation = new UpdatedAccountInformationRequest(){AccountNumber = AccountNumber, AccountType = "savings", AddressLine = null, City = "@hhf#@"};
            UpdateInformation.AccountNumber = AccountNumber;
            ///Act
            var Result = _updatedAccountInformation.GetUpdatedAccountInformation(UpdateInformation, AccountNumber);
            var UpdatedResult = Result as ObjectResult;
            ///Assert
            Assert.NotNull(UpdatedResult);
            Assert.Equal(new {Error = "Address City: "+UpdateInformation.City+" is INVALID!"}, UpdatedResult.Value);
        }

        [Fact]
        public void UpdatedAccountInformation_IncorrectState_ReturnsError()
        {

            ///Arrange 
            string AccountNumber = "716447224623";
            UpdatedAccountInformationRequest UpdateInformation = new UpdatedAccountInformationRequest(){AccountNumber = AccountNumber, State ="47653@@@"};
            UpdateInformation.AccountNumber = AccountNumber;
            ///Act
            var Result = _updatedAccountInformation.GetUpdatedAccountInformation(UpdateInformation, AccountNumber);
            var UpdatedResult = Result as ObjectResult;
            ///Assert
            Assert.NotNull(UpdatedResult);
            Assert.Equal(new {Error = "Address State: "+UpdateInformation.State+" is INVALID!"}, UpdatedResult.Value);
        }

        [Fact]
        public void UpdatedAccountInformation_InCorrectPostalCode_ReturnsError()
        {
            ///Arrange 
            string AccountNumber = "716447224623";
            UpdatedAccountInformationRequest UpdateInformation = new UpdatedAccountInformationRequest(){AccountNumber = AccountNumber, PostalCode = "^&%$#@$"};
            UpdateInformation.AccountNumber = AccountNumber;
            ///Act
            var Result = _updatedAccountInformation.GetUpdatedAccountInformation(UpdateInformation, AccountNumber);
            var UpdatedResult = Result as ObjectResult;
            ///Assert
            Assert.NotNull(UpdatedResult);
            Assert.Equal(new {Error = "Not A Valid Postal Code"}, UpdatedResult.Value);
        }


        [Fact]
        public void UpdatedAccountInformation_IncorrectPhone_ReturnsError()
        {

            ///Arrange 
            string AccountNumber = "716447224623";
            UpdatedAccountInformationRequest UpdateInformation = new UpdatedAccountInformationRequest(){AccountNumber = AccountNumber, Phone = "34f"};
            UpdateInformation.AccountNumber = AccountNumber;
            ///Act
            var Result = _updatedAccountInformation.GetUpdatedAccountInformation(UpdateInformation, AccountNumber);
            var UpdatedResult = Result as ObjectResult;
            ///Assert
            Assert.NotNull(UpdatedResult);
            Assert.Equal(new {Error = " "+UpdateInformation.Phone+" is Not a Valid Phone Number"}, UpdatedResult.Value);
        }

    }
}