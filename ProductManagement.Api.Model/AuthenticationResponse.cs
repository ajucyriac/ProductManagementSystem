using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Api.Model
{
    public class AuthenticationResponse
    {
        //public int Id { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string EmailAddress { get; set; }
        public string Token { get; set; }

        public AuthenticationResponse(UserDetails user, string token)
        {
            //Id = user.UserId;
            //FirstName = user.FirstName;
            //LastName = user.LastName;
            //EmailAddress = user.EmailAddress;
            Token = token;
        }
    }
}
