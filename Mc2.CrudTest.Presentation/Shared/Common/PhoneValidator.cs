using PhoneNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Common
{
    public class PhoneValidator
    {
        public static void MobileValidate(string telephoneNumber, string countryCode)
        {
            PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
            try
            {
                /*string telephoneNumber = "03336323900";
                string countryCode = "PK";*/
                PhoneNumbers.PhoneNumber phoneNumber = phoneUtil.Parse(telephoneNumber, countryCode);

                bool isMobile = false;
                bool isValidNumber = phoneUtil.IsValidNumber(phoneNumber); // returns true for valid number    

                // returns trueor false w.r.t phone number region  
                bool isValidRegion = phoneUtil.IsValidNumberForRegion(phoneNumber, countryCode);

                string region = phoneUtil.GetRegionCodeForNumber(phoneNumber); // GB, US , PK    

                var numberType = phoneUtil.GetNumberType(phoneNumber); // Produces Mobile , FIXED_LINE    

                string phoneNumberType = numberType.ToString();

                if (!string.IsNullOrEmpty(phoneNumberType) && phoneNumberType == "MOBILE")
                {
                    isMobile = true;
                }

                var originalNumber = phoneUtil.Format(phoneNumber, PhoneNumberFormat.E164); // Produces "+923336323997"    

                var data = new ValidatePhoneNumberModel
                {
                    FormattedNumber = originalNumber,    
                        IsMobile = isMobile,    
                        IsValidNumber = isValidNumber,    
                        IsValidNumberForRegion = isValidRegion,    
                        Region = region
                    };
                ResultData returnResult = new ResultData()
                {
                    Data = data,
                    StatusCode = HttpStatusCode.OK,
                    StatusMessage = "Success"
                };
            }
            catch (NumberParseException ex)
            {

                String errorMessage = "NumberParseException was thrown: " + ex.Message.ToString();


               


            }
        }
    }

    internal class ResultData
    {
        public ResultData()
        {
        }

        public ValidatePhoneNumberModel Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string StatusMessage { get; set; }
    }

    internal class ValidatePhoneNumberModel
    {
        public string FormattedNumber { get; set; }
        public bool IsMobile { get; set; }
        public bool IsValidNumber { get; set; }
        public bool IsValidNumberForRegion { get; set; }
        public string Region { get; set; }
    }
}
