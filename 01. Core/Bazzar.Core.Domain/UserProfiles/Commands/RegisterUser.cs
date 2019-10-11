using System;
using System.Collections.Generic;
using System.Text;

namespace Bazzar.Core.Domain.UserProfiles.Commands
{
    public class RegisterUser
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
    }
}
