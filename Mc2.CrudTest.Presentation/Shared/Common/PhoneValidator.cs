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
        public static ValidateResult MobileValidate(long telephoneNumber, string countryCode) {

            var validateResult=PhoneValidate(telephoneNumber.ToString(),countryCode);
            if (!validateResult.IsValidNumber)
            {
                return new ValidateResult { IsValid = false, StatusMessage = "phone Number is not valid" };
            }
            if (!validateResult.IsMobile)
            {
                return new ValidateResult { IsValid = false, StatusMessage = "phone Number is not mobile" };
            }
            return new ValidateResult { IsValid = true, StatusMessage = "phone Number is correct" };
        }
        public static ValidatePhoneNumberModel PhoneValidate(string telephoneNumber, string countryCode)
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
                return data;
                //ResultData returnResult = new ResultData()
                //{
                //    Data = data,
                //    StatusCode = HttpStatusCode.OK,
                //    StatusMessage = "Success"
                //};
            }
            catch (NumberParseException ex)
            {

         
                var data = new ValidatePhoneNumberModel
                {
                    FormattedNumber = "0000000",
                    IsMobile = false,
                    IsValidNumber = false,
                    IsValidNumberForRegion = false,
                    Region = ex.Message
                };
                return data;
            }
        }
    }

    public class ValidateResult
    {
        

        public bool IsValid { get; set; }
        public string StatusMessage { get; set; }
    }

    public class ValidatePhoneNumberModel
    {
        public string FormattedNumber { get; set; }
        public bool IsMobile { get; set; }
        public bool IsValidNumber { get; set; }
        public bool IsValidNumberForRegion { get; set; }
        public string Region { get; set; }
    }
}
