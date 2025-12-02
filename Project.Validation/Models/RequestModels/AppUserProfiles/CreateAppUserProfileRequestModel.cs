using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Validation.Models.RequestModels.AppUserProfiles
{
    public class CreateAppUserProfileRequestModel
    {
        public int AppUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
