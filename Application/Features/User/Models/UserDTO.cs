using Microsoft.AspNetCore.Http;

namespace Application.Features.User.Models
{
    public class UserDTO : GlobalModels.GlobalModelWithName
    {

        public string? Name { get; set; }

     

        public string? phoneNumber1 { get; set; }

        public string? phoneNumber2 { get; set; }



        public long StreetId { get; set; }  

    }
}
