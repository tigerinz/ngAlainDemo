using System.ComponentModel.DataAnnotations;

namespace ngAlainDemo.Models
{
    
    public class User 
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string avatar { get; set; }
    }

    public class LoginRequest
    {
       // [Required(ErrorMessage="邮箱不能为空")]
        //[EmailAddress(ErrorMessage="邮箱格式不正确")]
       // public string email{get;set;}
        [Required(ErrorMessage="用户名不能为空")]
        public string userName{get;set;}

        [Required(ErrorMessage="密码不能为空")]
        public string password { get; set; }
    }

    public class LoginResponse 
    {
        public string token { get; set; }
        public User user { get; set; }
      //  public string username { get; set; }
      //  public string email { get; set; }
       // public string avatar { get; set; }
    }

}