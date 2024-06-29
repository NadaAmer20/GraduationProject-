using System.Collections.Generic;

namespace GraduationProject.DTO.DTOAccount
{
    public class LoginResponseModel
    {
        public string Token { get; set; }
        public List<string> Roles { get; set;}
        }
}
