


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
                    break;               

                case "1":
                  
                    if (OurResponse.Length == 1)
                    {

                        response = "CON Select Product \n";
                        response += "1. Wealth Management OD \n";
                    }
                    else if (OurResponse.Length == 2)
                    {

                        response = "CON Please Enter Account no \n";
                    }
                    else if (OurResponse.Length == 3)
                    {


                        string Account = OurResponse[2].ToString();
                        var result = client.GetAllDealsPerCustomer(Account);
                        decimal Principalamount = Convert.ToDecimal(result.FirstOrDefault().PrincipalAmount);
                        decimal amount = Principalamount * (0.75m);
                        if (result == null)
                        {
                            response = "END You are not eligible for the loan \n";
                        }
                        response = "CON Your Eligibility amount: " + amount + " Rate:2% ,fee:0.5% " + " Enter Amount Required: \n";
                        //response = "CON Enter Amount Required \n";

                    }
                    else if (OurResponse.Length == 4)
                    {
                        string Account = OurResponse[2].ToString();
                        decimal AmountRequest = Convert.ToDecimal(OurResponse[3]);
                        var result = client.GetAllDealsPerCustomer(Account);
                        decimal Principalamount = Convert.ToDecimal(result.FirstOrDefault().PrincipalAmount);
                        decimal amount = Principalamount * (0.75m);
                        //response = "END You are not eligible for the loan";
                        if (AmountRequest > amount)
                        {
                            response = "CON Your requested amount is above your eligibility. Enter Amount Required: \n";
                            
                        }
                        response = "CON Enter Amount Required Again \n";
                    }
                    else if (OurResponse.Length == 5)
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
                            response = "END Your Loan request has been submitted";
                        }
                        else
                        {
                            response = "END an error has occured";
                        }
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