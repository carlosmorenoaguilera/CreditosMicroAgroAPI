using System.ComponentModel.DataAnnotations;

namespace CreditosMicroAgroAPI.Controllers
{
    public class UserAuthRequest
    {
        [Required]
        public string UserName
        {
            get;
            set;
        }
        [Required]
        public string Password
        {
            get;
            set;
        }
    }
}