


using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
//using ussdCallbackUrl.fintrakService;
using ussdCallbackUrl.fintrakService;

namespace ussdCallbackUrl.Controllers
{
    // you need to explicitly declare the parameters that the server will send to your app
    // the server returns phoneNumber, text, sessionId and serviceCode
    // this class acts as complex type to facilitate parameter binding
    // make getters and setters for the values you expect from the server


    public class ServerResponse
    {
        public string text { get; set; }
        public string phoneNumber { get; set; }
        public string sessionId { get; set; }
        public string serviceCode { get; set; }

    }

    [RoutePrefix("api/mobile")]
    public class MobileController : ApiController
    {
        //fintrakService.GeneralService client = new fintrakService.GeneralService();
        fintrakService.GeneralServiceClient client = new fintrakService.GeneralServiceClient();
        [Route("ussd")]
        // specify the actual route, your url will look like... localhost:8080/api/mobile/ussd...
        [HttpPost, ActionName("ussd")]
        // state that the method you intend to create is a POST

        public HttpResponseMessage ussd([FromBody]ServerResponse ServerResponse)
        {

            // declare a complex type as input parameter
            HttpResponseMessage rs;
            string response = null;
            string[] OurResponse = new string[] { };

            if (ServerResponse.text == null)
            {
                ServerResponse.text = " ";
            }

            OurResponse = ServerResponse.text.Split('*');
            int LengthOurResponse = OurResponse.Length;

            // loop through the server's text value to determine the next cause of action\

            switch (OurResponse[0])
            {
                case " ":
                    response = "CON  Welcome to Standard Chartered USSD Platform \n";
                    response += "1. Select Product \n";
                    response += "2. Check Eligibility \n";
                    // response += "3. Insurance \n";
                    break;

                case "3":

                    if (OurResponse.Length == 1)
                    {
                        response = "CON Please choose from the option below \n";
                        response += "1. Subscribe \n";
                        response += "2. Pay Premium \n";
                        response += "3. Log Claim \n";
                        response += "0 Back to Main Menu \n";
                    }
                    else if (OurResponse[0].ToString() == "3" && OurResponse[1].ToString() == "1" && OurResponse.Length == 2)
                    {
                        response = "CON Select from the Policy below \n";
                        response += "1. Vehicle Insurance \n";
                        response += "2. Individual Life Assurance \n";
                        response += "3. Loan Protection Insurance \n";
                        response += "4. Home Asset Insurance \n";
                        response += "0. Back to Menu \n";

                    }
                    else if (OurResponse[0].ToString() == "3" && OurResponse[1].ToString() == "1" && OurResponse.Length >= 3)
                    {

                        switch (OurResponse[2])
                        {
                            case "1":
                                if (OurResponse.Length == 3)
                                {
                                    response = "CON Your account will be debited with =N=5000.00 : \n";
                                    response += "1. Accept \n";
                                    response += "2. Decline \n";
                                }
                                else if (OurResponse.Length == 4)
                                {

                                    switch (OurResponse[3].ToString())
                                    {
                                        case "1":
                                            if (OurResponse.Length == 4)
                                            {
                                                response = "CON Select your Bank \n";
                                                response += "1. Access Bank \n";
                                                response += "2. Zenith Bank \n";
                                                response += "3. Guarantee Trust Bank \n";
                                                response += "4. First Bank \n";
                                                response += "5. Skye Bank \n";
                                            }

                                            break;
                                        case "2":
                                            response = "END Policy Declined.";
                                            break;
                                        default:
                                            break;
                                    }


                                }
                                else if (OurResponse.Length == 5)
                                {
                                    response = "CON Enter Bank Account \n";
                                }

                                else if (OurResponse.Length == 6)
                                {
                                    response = "END Your Subscription was successful : \n";
                                    response += "Thank you for using our ussd service";

                                }

                                break;
                            case "2":

                                if (OurResponse.Length == 3)
                                {
                                    response = "CON Your account will be debited with =N=3000.00 : \n";
                                    response += "1. Accept \n";
                                    response += "2. Decline \n";
                                }
                                else if (OurResponse.Length == 4)
                                {

                                    switch (OurResponse[3].ToString())
                                    {
                                        case "1":
                                            if (OurResponse.Length == 4)
                                            {
                                                response = "CON Select your Bank \n";
                                                response += "1. Access Bank \n";
                                                response += "2. Zenith Bank \n";
                                                response += "3. Guarantee Trust Bank \n";
                                                response += "4. First Bank \n";
                                                response += "5. Skye Bank \n";
                                            }

                                            break;
                                        case "2":
                                            response = "END Policy Declined.";
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                else if (OurResponse.Length == 5)
                                {
                                    response = "CON Enter Account No \n";
                                }

                                else if (OurResponse.Length == 6)
                                {
                                    response = "END Your Subscription was successful : \n";
                                    response += "Thank you for using our ussd service";

                                }

                                break;
                            case "3":

                                if (OurResponse.Length == 3)
                                {
                                    response = "CON Your account will be debited with =N=3500.00 : \n";
                                    response += "1. Accept \n";
                                    response += "2. Decline \n";
                                }
                                else if (OurResponse.Length == 4)
                                {

                                    switch (OurResponse[3].ToString())
                                    {
                                        case "1":
                                            if (OurResponse.Length == 4)
                                            {
                                                response = "CON Select your Bank \n";
                                                response += "1. Access Bank \n";
                                                response += "2. Zenith Bank \n";
                                                response += "3. Guarantee Trust Bank \n";
                                                response += "4. First Bank \n";
                                                response += "5. Skye Bank \n";
                                            }

                                            break;
                                        case "2":
                                            response = "END Policy Declined.";
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                else if (OurResponse.Length == 5)
                                {
                                    response = "CON Enter Account No \n";
                                }

                                else if (OurResponse.Length == 6)
                                {
                                    response = "END Your Subscription was successful : \n";
                                    response += "Thank you for using our ussd service";
                                }

                                break;
                            case "4":

                                if (OurResponse.Length == 3)
                                {
                                    response = "CON Your account will be debited with =N=4500.00 : \n";
                                    response += "1. Accept \n";
                                    response += "2. Decline \n";
                                }
                                else if (OurResponse.Length == 4)
                                {

                                    switch (OurResponse[3].ToString())
                                    {
                                        case "1":
                                            if (OurResponse.Length == 4)
                                            {
                                                response = "CON Select your Bank \n";
                                                response += "1. Access Bank \n";
                                                response += "2. Zenith Bank \n";
                                                response += "3. Guarantee Trust Bank \n";
                                                response += "4. First Bank \n";
                                                response += "5. Skye Bank \n";
                                            }

                                            break;
                                        case "2":
                                            response = "END Policy Declined.";
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                else if (OurResponse.Length == 5)
                                {
                                    response = "CON Enter Bank Account \n";
                                }

                                else if (OurResponse.Length == 6)
                                {
                                    response = "END Your Subscription was successful : \n";
                                    response += "Thank you for using our ussd service";

                                }

                                break;
                            case "0":
                                ServerResponse.text = "1";
                                response = "CON Please choose from the option below \n";
                                response += "1. Subscribe \n";
                                response += "2. Pay Premium \n";
                                response += "3. Log Claim \n";
                                response += "0 Back to Main Menu \n";
                                break;
                            default:
                                break;
                        }



                    }
                    else if (OurResponse[0].ToString() == "3" && OurResponse[1].ToString() == "2")
                    {

                        switch (OurResponse.Length)
                        {
                            case 2:
                                response = "CON Enter your Policy No : \n";
                                break;
                            case 3:
                                response = "CON Enter Account No : \n";
                                break;
                            case 4:
                                response = response = "CON Enter Amount : \n";
                                break;
                            case 5:
                                response = "END Your Premium Payment on policy " + OurResponse[1].ToString() + " : \n";
                                response += "Amount :=N=" + OurResponse[4].ToString() + ".00\n";
                                response += "is successful \n";
                                response += "Thank you for using our ussd service";
                                break;
                            default:
                                break;
                        }

                    }
                    else if (OurResponse[0].ToString() == "3" && OurResponse[1].ToString() == "3")
                    {

                        switch (OurResponse.Length)
                        {
                            case 2:
                                response = "CON Enter your Policy No : \n";
                                break;
                            case 3:
                                response = "CON Enter Claim Request Description : \n";
                                break;
                            case 4:
                                response = "END Your claim Request is : " + OurResponse[3].ToString() + " : \n";
                                response += "on Policy :" + OurResponse[1].ToString() + "\n";
                                response += "is successful we will get bact to you later\n";
                                response += "Thank you for using our ussd service";
                                break;
                            default:
                                break;
                        }


                    }
                    else if (OurResponse[0].ToString() == "3" && OurResponse[1].ToString() == "0")
                    {
                        ServerResponse.text = " ";
                        response = "CON  Welcome to FintrakSoftware USSD Platform \n";
                        response += "1. Insurance \n";
                        response += "2. Banking \n";
                    }

                    break;

                case "1":
                    if (OurResponse.Length == 1)
                    {

                        response = "CON Enter BVN \n";
                    }
                    else if (OurResponse.Length == 2)
                    {

                        response = "CON Enter Last name \n";
                    }
                    else if (OurResponse.Length == 3)
                    {

                        response = "CON Enter Email \n";
                    }
                    else if (OurResponse.Length == 4)
                    {
                        response = "CON Enter Product Code \n";
                    }
                    else if (OurResponse.Length == 5)
                    {

                        response = "CON Enter Product Name \n";
                    }
                    else if (OurResponse.Length == 6)
                    {
                        response = "CON Enter Phone number \n";
                    }
                    else if (OurResponse.Length == 7)
                    {

                        fintrakService.CreateAccountRequest Accountrequest = new fintrakService.CreateAccountRequest()
                        {
                            bvn = OurResponse[1].ToString(),
                            lastname = OurResponse[2].ToString(),
                            email = OurResponse[3].ToString(),
                            productCode = OurResponse[4].ToString(),
                            productName = OurResponse[5].ToString(),
                            phonenumber = OurResponse[6].ToString()
                        };

                       // fintrakService.GeneralServiceClient client = new fintrakService.GeneralServiceClient();

                        if (client.CreateAccountOnline(Accountrequest).responseCode == "0")
                        {
                            response = "END Your Account was successfully created;";
                        }
                        else
                        {
                            response = "END an error has occured";
                        }


                    }
                    break;

                case "2":

                    if (OurResponse.Length == 1)
                    {
                        response = "CON Select your option below \n";
                        response += "1.Transfer Funds - Same Bank \n";
                        response += "2.Transfer Funds - other Bank \n";
                        response += "3.Airtime \n";
                        response += "4.Check Balance \n";
                        response += "5.Loan Request \n";
                        response += "6.Account Opening \n";
                        response += "0.Back \n";
                    }
                    else if (OurResponse[0].ToString() == "2" && OurResponse[1].ToString() == "1")
                    {

                        switch (OurResponse.Length)
                        {
                            case 2:
                                response = "CON Please Enter Amount: \n";
                                break;
                            case 3:
                                response = "CON Please Enter Account No: \n";
                                break;
                            case 4:
                                response = "CON Please Enter your TFC PIN \n";
                                break;
                            case 5:
                                response = "END Your Fund was successfully transfered to \n";
                                response += "Account No :" + OurResponse[3].ToString() + "\n";
                                break;
                            default:
                                break;
                        }

                    }

                    else if (OurResponse[0].ToString() == "2" && OurResponse[1].ToString() == "2" && OurResponse.Length == 2)
                    {
                        response = "CON Please Select Bank \n";
                        response += "1. Access Bank \n";
                        response += "2. Zenith Bank \n";
                        response += "3. Guarantee Trust Bank \n";
                        response += "4. First Bank \n";
                        response += "5. Skye Bank \n";

                    }
                    else if (OurResponse[0].ToString() == "2" && OurResponse[1].ToString() == "2" && OurResponse.Length >= 3)
                    {

                        switch (OurResponse.Length)
                        {
                            case 3:
                                response = "Please Enter Amount: \n";
                                break;
                            case 4:
                                response = "Please Enter Account No \n";
                                break;
                            case 5:
                                response = "CON for your transfer to be successful \n";
                                response += "Please Enter your TFC PIN \n";
                                break;
                            case 6:
                                response = "END Your Fund was successfully transfered to \n";
                                response += "Bank Name :" + OurResponse[2].ToString() + "\n";
                                response += "Amount :" + OurResponse[3].ToString() + "\n";
                                response += "Account no :" + OurResponse[4].ToString() + "\n";
                                break;
                            default:
                                break;
                        }

                    }
                    else if (OurResponse[0].ToString() == "2" && OurResponse[1].ToString() == "3" && OurResponse.Length == 2)
                    {
                        response = "CON Please select from the option below \n";
                        response += "1. Your Phone \n";
                        response += "2. Other Phone \n";

                    }
                    else if (OurResponse[0].ToString() == "2" && OurResponse[1].ToString() == "3" && OurResponse.Length >= 3)
                    {
                        switch (OurResponse[2].ToString())
                        {
                            case "1":

                                if (OurResponse.Length == 3)
                                {
                                    response = "CON Please Enter Amount \n";
                                }
                                else if (OurResponse.Length == 4)
                                {
                                    response = "END Your Recharge was successful.\n";
                                }

                                break;
                            case "2":

                                if (OurResponse.Length == 3)
                                {
                                    response = "CON Please Enter Amount \n";
                                }
                                else if (OurResponse.Length == 4)
                                {
                                    response = "CON Please Enter Phone no \n";
                                }
                                else if (OurResponse.Length == 5)
                                {
                                    response = "END Recharge on phone no \n";
                                    response += OurResponse[4].ToString() + " \n ";
                                    response += "Amount " + OurResponse[3].ToString() + " was successful. \n";
                                }

                                break;
                            default:
                                break;
                        }
                    }
                    else if (OurResponse[0].ToString() == "2" && OurResponse[1].ToString() == "4")
                    {

                        switch (OurResponse.Length)
                        {
                            case 2:
                                response = "CON Please Enter your Account no: \n";
                                break;
                            case 3:
                                response = "END Your Account Balance is : =N=150,345.20 \n";
                                break;
                            default:
                                break;
                        }

                    }

                    else if (OurResponse[0].ToString() == "2" && OurResponse[1].ToString() == "5" && OurResponse.Length == 2)
                    {
                        response = "CON Select Product \n";
                        response += "1. Wealth Management OD \n";
                        //response += "2. Wealth Travel Loan \n";
                        //response += "3. Wealth Salad \n";
                        //response += "4. Wealth MDA Loans \n";
                        //response += "5. Wealth Easy Micro \n";
                        //response += "6. Wealth Easy SME \n";
                    }
                    else if (OurResponse[0].ToString() == "2" && OurResponse[1].ToString() == "5" && OurResponse.Length >= 3)
                    {
                        switch (OurResponse[2].ToString())
                        {
                            case "1":
                                if (OurResponse.Length == 3)
                                {
                                    response = "CON Please Enter Account no \n";

                                    
                                    

                                }

                                else if (OurResponse.Length == 4)
                                {
                                   // ussdCallbackUrl.fintrakService.GeneralServiceClient client = new ussdCallbackUrl.fintrakService.GeneralServiceClient();
                                    string Account = OurResponse[3].ToString();
                                    var result=client.GetAllDealsPerCustomer(Account);
                                    decimal Principalamount =Convert.ToDecimal(result.FirstOrDefault().PrincipalAmount);
                                    decimal amount = Principalamount * (0.75m);
                                    if (result == null)
                                    {
                                        response = "END You are not eligible for the loan \n";
                                    }
                                    response = "CON Your Eligibility amount: " + amount + " Rate:2% ,fee:0.5% " + " Enter Amount Required: \n";
                                    //response = "CON Enter Amount Required \n";

                                    
                                }
                                   
                               
                                else if (OurResponse.Length == 5)
                                {
                                    string Account = OurResponse[3].ToString();
                                    decimal AmountRequest = Convert.ToDecimal(OurResponse[4]);
                                    var result = client.GetAllDealsPerCustomer(Account);
                                    decimal Principalamount = Convert.ToDecimal(result.FirstOrDefault().PrincipalAmount);
                                    decimal amount = Principalamount * (0.75m);
                                    //response = "END You are not eligible for the loan";
                                    if (AmountRequest > amount)
                                    {
                                        response += "CON Your requested amount is above your eligibility. Enter Amount Required: \n";
                                        //response = "CON Enter Amount Required \n";
                                    }
                                }
                                else if (OurResponse.Length == 6)
                                {
                                    string Account = OurResponse[3].ToString();                                
                                    var result = client.GetCustomeCode(Account);
                                    
                                    fintrakService.LoanDetails loanservice = new fintrakService.LoanDetails()
                                    {
                                        AmountPaid = OurResponse[4].ToString(),
                                        Approved = "0",
                                        ApprovedAmount = OurResponse[4].ToString(),
                                        CategoryID = "601",
                                        CoyCode = "1",
                                        CustCode = result,
                                        DateCreated = DateTime.Now.ToShortDateString(),
                                        DateOfDisburse = DateTime.Now.ToShortDateString(),
                                        Disapprove = "0",
                                        EffectDate = DateTime.Now.ToShortDateString(),
                                        FirstpayDate = DateTime.Now.ToShortDateString(),
                                        FixedPrincipal = "0.00",
                                        FreqType = "Monthly",
                                        Installments = "1",
                                        InstalmentLeft = "1",
                                        InterestAmount = "0",
                                        LastInterestPaid = "0",
                                        LastprincipalPaid = "0",
                                        MaturityAmount = "0",
                                        OutstandingPrincipal = OurResponse[4].ToString(),
                                        pdTypeID = "701",
                                        PeriodicPay = "32",
                                        Principal = OurResponse[4].ToString(),
                                        PrincipalFreqType = "Monthly",
                                        PrincipalFrequency = "1",
                                        ProductAcctNo = "4200187" + new Random().Next(10000, 80000).ToString(),
                                        ProductCode = "042",
                                        ProductName = "Standard Chartered Asset Finance",
                                        Rate = "2",
                                        TempCam = "0",
                                        Tenor = "1",
                                        TerminalDate = "04/10/2020"
                                        
                                    };

                                    //ussdCallbackUrl.fintrakService.GeneralServiceClient clients = new ussdCallbackUrl.fintrakService.GeneralServiceClient();
                                    if (client.IsLoanAdded(loanservice) == true)
                                    {
                                        response = "END Your Loan request was successful";
                                    }
                                    else
                                    {
                                        response = "END an error has occured";
                                    }
                                
                                }
                               
                                break;
                            case "2":
                                if (OurResponse.Length == 3)
                                {
                                    response = "CON Please Enter Acctno \n";
                                }

                                else if (OurResponse.Length == 4)
                                {
                                    response = "CON Please Enter Loan Amount \n";
                                }
                                else if (OurResponse.Length == 5)
                                {
                                    fintrakService.LoanDetails loanservice = new fintrakService.LoanDetails()
                                    {
                                        AmountPaid = "300000",
                                        Approved = "0",
                                        ApprovedAmount = "1000000",
                                        CategoryID = "601",
                                        CoyCode = "1",
                                        CustCode = OurResponse[3].ToString(),
                                        DateCreated = DateTime.Now.ToShortDateString(),
                                        DateOfDisburse = "04/05/2018",
                                        Disapprove = "0",
                                        EffectDate = "05/24/2018",
                                        FirstpayDate = "04/05/2018",
                                        FixedPrincipal = "0.00",
                                        FreqType = "Monthly",
                                        Installments = "30",
                                        InstalmentLeft = "20",
                                        InterestAmount = "10000",
                                        LastInterestPaid = "5000",
                                        LastprincipalPaid = "20000",
                                        MaturityAmount = "60000",
                                        OutstandingPrincipal = "0.00",
                                        pdTypeID = "701",
                                        PeriodicPay = "32",
                                        Principal = OurResponse[4].ToString(),
                                        PrincipalFreqType = "Monthly",
                                        PrincipalFrequency = "33",
                                        ProductAcctNo = "4200187" + new Random().Next(10000, 80000).ToString(),
                                        ProductCode = "042",
                                        ProductName = "IBILE Travel Loan",
                                        Rate = "24",
                                        TempCam = "0",
                                        Tenor = "6",
                                        TerminalDate = "04/10/2018"
                                    };

                                    //ussdCallbackUrl.fintrakService.GeneralServiceClient clientservice = new ussdCallbackUrl.fintrakService.GeneralServiceClient();
                                    if (client.IsLoanAdded(loanservice) == true)
                                    {
                                        response = "END Your Loan request was successful";
                                    }
                                    else
                                    {
                                        response = "END an error has occured";
                                    }
                                }
                                break;
                            case "3":
                                if (OurResponse.Length == 3)
                                {
                                    response = "CON Please Enter Acctno \n";
                                }

                                else if (OurResponse.Length == 4)
                                {
                                    response = "CON Please Enter Loan Amount \n";
                                }

                                else if (OurResponse.Length == 5)
                                {
                                    fintrakService.LoanDetails loanservice = new fintrakService.LoanDetails()
                                    {
                                        AmountPaid = "300000",
                                        Approved = "0",
                                        ApprovedAmount = "1000000",
                                        CategoryID = "601",
                                        CoyCode = "1",
                                        CustCode = OurResponse[3].ToString(),
                                        DateCreated = DateTime.Now.ToShortDateString(),
                                        DateOfDisburse = "04/05/2018",
                                        Disapprove = "0",
                                        EffectDate = "05/24/2018",
                                        FirstpayDate = "04/05/2018",
                                        FixedPrincipal = "0.00",
                                        FreqType = "Monthly",
                                        Installments = "30",
                                        InstalmentLeft = "20",
                                        InterestAmount = "10000",
                                        LastInterestPaid = "5000",
                                        LastprincipalPaid = "20000",
                                        MaturityAmount = "60000",
                                        OutstandingPrincipal = "0.00",
                                        pdTypeID = "701",
                                        PeriodicPay = "32",
                                        Principal = OurResponse[4].ToString(),
                                        PrincipalFreqType = "Monthly",
                                        PrincipalFrequency = "33",
                                        ProductAcctNo = "4200187" + new Random().Next(10000, 80000).ToString(),
                                        ProductCode = "042",
                                        ProductName = "IBILE Salad",
                                        Rate = "24",
                                        TempCam = "0",
                                        Tenor = "6",
                                        TerminalDate = "04/10/2018"
                                    };

                                    //ussdCallbackUrl.fintrakService.GeneralServiceClient client = new ussdCallbackUrl.fintrakService.GeneralServiceClient();
                                    if (client.IsLoanAdded(loanservice) == true)
                                    {
                                        response = "END Your Loan request was successful";
                                    }
                                    else
                                    {
                                        response = "END an error has occured";
                                    }
                                }
                                break;

                            default:
                                break;
                        }
                    }

                    else if (OurResponse[0].ToString() == "2" && OurResponse[1].ToString() == "6" && OurResponse.Length == 2)
                    {
                        response = "CON Please select your account type \n";
                        response += "1. Savings \n";
                        response += "2. Current \n";
                    }
                    else if (OurResponse[0].ToString() == "2" && OurResponse[1].ToString() == "6" && OurResponse.Length >= 3)
                    {
                        switch (OurResponse[2].ToString())
                        {
                            case "1":
                                if (OurResponse.Length == 3)
                                {
                                    response = "CON Please Enter Preferred account name \n";
                                }
                                else if (OurResponse.Length == 4)
                                {
                                    response = "CON Please Enter your BVN \n";
                                }
                                else if (OurResponse.Length == 5)
                                {
                                    response = "CON Please Enter your phone no \n";
                                }
                                else if (OurResponse.Length == 6)
                                {
                                    response = "CON Please Enter your email \n";
                                }
                                else if (OurResponse.Length == 7)
                                {
                                    response = "END Your Savings account was successfully created";
                                }
                                break;
                            case "2":
                                if (OurResponse.Length == 3)
                                {
                                    response = "CON Please Enter Preferred account name \n";
                                }
                                else if (OurResponse.Length == 4)
                                {
                                    response = "CON Please Enter your BVN \n";
                                }
                                else if (OurResponse.Length == 5)
                                {
                                    response = "CON Please Enter your phone no \n";
                                }
                                else if (OurResponse.Length == 6)
                                {
                                    response = "CON Please Enter your email \n";
                                }
                                else if (OurResponse.Length == 7)
                                {
                                    response = "END Your Current account was successfully created";
                                }
                                break;

                            default:
                                break;
                        }
                    }

                    else if (OurResponse[0].ToString() == "2" && OurResponse[1].ToString() == "0")
                    {

                        ServerResponse.text = " ";
                        response = "CON  Welcome to FintrakSoftware USSD Platform \n";
                        response += "1. Insurance \n";
                        response += "2. Banking \n";

                    }

                    break;
                default:
                    response = "END invalid option";
                    break;
            }


            rs = Request.CreateResponse(HttpStatusCode.Created, response);
            // append your response to the HttpResponseMessage and set content type to text/plain, exactly what the server expects
            rs.Content = new StringContent(response, Encoding.UTF8, "text/plain");
            // finally return your response to the server

            return rs;
        }

    }



}