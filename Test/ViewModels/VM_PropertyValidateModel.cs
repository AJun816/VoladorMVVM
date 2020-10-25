using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;
using VoladorMVVM.Validatetion;

namespace Test.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class VM_PropertyValidateModel:PropertyValidateModel
    {
        [Required(ErrorMessage = "必填项")]
        [StringLength(6, ErrorMessage = "请输入正确的姓名")]
        public string Name { get; set; }

        [Required(ErrorMessage = "必填项")]
        [StringLength(5, ErrorMessage = "请输入正确的性别")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "必填项")]
        [Range(18, 100, ErrorMessage = "年龄应在18-100岁之间")]
        public int MinAge { get; set; }
    }
}
