using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyNhaTro.EF.Model
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage ="Username không được để trống")]
        [StringLength(20, ErrorMessage ="Chiều dài tối đa của username là 20 kí tự")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [Range(6,int.MaxValue,ErrorMessage ="Mật khẩu phải chứa ít nhất 6 kí tự")]
        public int Password { get; set; }
        public bool isAdmin { get; set; } = false;
        public string Name { get; set; }
        public bool Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string SDT { get; set; }
        public virtual Customer Customer { get; set; }



    }
}
