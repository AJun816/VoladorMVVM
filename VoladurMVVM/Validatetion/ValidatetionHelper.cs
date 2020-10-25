using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoladorMVVM.Validatetion
{
    public class ValidatetionHelper
    {
        public static ValidResult IsValid(object value)
        {
            ValidResult result = new ValidResult();
            try
            {
                ValidationContext validationContext = new ValidationContext(value);
                var results = new List<ValidationResult>();
                var isValid = Validator.TryValidateObject(value, validationContext, results, true);

                if (!isValid)
                {
                    result.IsVaild = false;
                    result.ErrorMembers = new List<ErrorMember>();
                    foreach (var item in results)
                    {
                        result.ErrorMembers.Add(new ErrorMember()
                        {
                            ErrorMessage = item.ErrorMessage,
                            ErrorMemberName = item.MemberNames.FirstOrDefault()
                        });
                    }
                }
                else
                {
                    result.IsVaild = true;
                }
            }
            catch (Exception ex)
            {
                result.IsVaild = false;
                result.ErrorMembers = new List<ErrorMember>();
                result.ErrorMembers.Add(new ErrorMember()
                {
                    ErrorMessage = ex.Message,
                    ErrorMemberName = "Internal error"
                });

            }
            return result;
        }
    }

    //返回的错误集合类
    public class ValidResult
    {
        public List<ErrorMember> ErrorMembers { get; set; }
        public bool IsVaild { get; set; }
    }

    //返回的错误信息成员
    public class ErrorMember
    {
        public string ErrorMessage { get; set; }
        public string ErrorMemberName { get; set; }
    }
}
