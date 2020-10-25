using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;
using Test.Models;
using VoladorMVVM.Command;
using VoladorMVVM.Validatetion;

namespace Test.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class VM_ValidatetionHelper
    {
        public string Bt1 { get; set; } = "注册";
        public M_ValidatetionHelper Employee { get; set; }
        public List<ErrorMember> ErrorMembers { get; set; }

        public VoladorCommand BtCommand => new VoladorCommand(obj =>
        {
            Employee = new M_ValidatetionHelper()
            {
                Name = "",
                Email = "",
                Age = 11,
                Phone = "123455111111",
                Salary = 2001
            };


            var result = ValidatetionHelper.IsValid(Employee);
            if (!result.IsVaild)
            {
                ErrorMembers = result.ErrorMembers;
            }
        });
    }
}
