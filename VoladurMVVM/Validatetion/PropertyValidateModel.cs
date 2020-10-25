using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoladorMVVM.Validatetion
{
    public abstract class PropertyValidateModel : IDataErrorInfo
    {
        //检查对象错误 
        public string Error { get { return null; } }

        //检查属性错误  
        public string this[string columnName]
        {
            get {
                var validationResults = new List<ValidationResult>();

                if (Validator.TryValidateProperty(
                        GetType().GetProperty(columnName).GetValue(this)
                        , new ValidationContext(this)
                        {
                            MemberName = columnName
                        }
                        , validationResults))
                    return null;

                return validationResults.First().ErrorMessage;
            }
        }
    }
}
