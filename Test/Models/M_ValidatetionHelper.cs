using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;

namespace Test.Models
{
    [AddINotifyPropertyChangedInterface]
    public class M_ValidatetionHelper
    {
        [Required(ErrorMessage = "{0}必须填写，不能为空")]
        [DisplayName("姓名")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0}必须填写，不能为空")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "邮件格式不正确")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0}必须填写，不能为空")]
        [Range(18, 100, ErrorMessage = "年满18岁小于100岁方可申请")]
        public int Age { get; set; }

        [Required(ErrorMessage = "{0}手机号不能为空")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "{0}请输入正确的手机号")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "{0}薪资不能低于本省最低工资2000")]
        [Range(typeof(decimal), "20000.00", "9999999.00", ErrorMessage = "请填写正确信息")]
        public decimal Salary { get; set; }
    }
}
