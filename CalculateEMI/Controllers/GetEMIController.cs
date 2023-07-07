using Microsoft.AspNetCore.Mvc;

namespace CalculateEMI.Controllers.Models
{
    [Route("api/[controller]")]
    public class GetEMIController : Controller
    {
        
        [HttpPost(Name = "GetEMI")]
        public IActionResult getEMI([FromBody] Loan details)
        {   
            StreamReader sr = new StreamReader("Data/error.json");
            string error = sr.ReadToEnd();
            
            if(details == null) return new JsonResult(error[0]){StatusCode = 400};
            if(details.Principal < 1 || details.Principal > 10000000) 
            {   
                return  new JsonResult(error[1]){StatusCode = 400};}
            if(details.rate < 0 || details.rate > 999) return  new JsonResult("Error : Please Enter Valid Rate"){StatusCode = 400};
            if(details.installments < 1 || details.installments > 2000 ) return  new JsonResult("Error : Please Enter Valid Number of Installments"){StatusCode = 400};
            float r = details.rate / (12 * 100); // one month interest
            int t = details.installments; // one month period
            if(r == 0){ //If we are giving loan to him on ZER0 INTREST.
                details.EMI = (details.Principal)/t;
            }
            else{
                //If any Error happens in the calcultaion then we will be returning the BAD request.
                try {details.EMI = (details.Principal * r * (double)Math.Pow(1 + r, t))/ (double)(Math.Pow(1 + r, t) - 1);
                } catch(Exception){
                    return new JsonResult("Error : Something Went Wrong! Pleae Try Again."){StatusCode = 400};
                }
            }
            //Sending Data to MongoDB
            //Making the EMI as the 2 digit value
            details.EMI = Math.Round(details.EMI,2);
            //checking if any data is present Already.
            return new JsonResult(details);

        }

        // [HttpPost(Name = "GetUserByID")]
        // public IActionResult get([FromBody] LoanUsers user)
        // {
        //         return new ObjectResult("This is the result.");
        // }


        // //
        // // Validating fucntions for the class parameters
        // // name
        // // age
        // // pan
        // // aadhar
        // // email
        // // mobile etc
        // // 
        // private Boolean ValidateName(string name) 
        // {
        //     if(name.Length <= 0 || name == null || name.Length >20){ 
        //         return false;
        //     }
        //     Boolean hasnumber = name.All(char.IsDigit);
        //     if(hasnumber) return false;
        //     if(!((name[0]>='A' && name[0] <='Z') || (name[0]>='a' && name[0] <='z'))) return false;
        //     return true;
        // }

        // private Boolean ValidateAge(int age)
        // {
        //     if(age<=0 || age>126) return false;
        //     if(age.Equals(typeof(int))) return false;
        //     return true;
        // }

        // private Boolean ValidateEmail(String? email)
        // {
        //     if(email == null || email.Length <=0 || !email.Contains("@gmail.com")) return false;
        //     if((email[0]>='A' && email[0] <='Z')) return false;
        //     return true;
        // }

        // private Boolean ValidatePan(String? pan)
        // {
        //     if(pan == null || pan.Length == 0 ) return false;
        //     System.Text.RegularExpressions.Regex validate = new System.Text.RegularExpressions.Regex("^[a-zA-Z]){5}([0-9]){4}([A-Z]){1}$");
        //     return validate.IsMatch(pan)? true : false;
        // }
        // private Boolean ValidateAadhar(long aadhar)
        // {
        //     if(aadhar<=0 || aadhar >=1000000000000 || aadhar<=99999999999) return false;
        //     return true;
        // } 

        // private Boolean ValidatePin(int pincode)
        // {
        //     return true;
        // }
    }
}