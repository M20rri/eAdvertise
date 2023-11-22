using Microsoft.AspNetCore.Identity;

namespace eAdvertise.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public void UltraData(string firstname, string lastname, bool isActive)
        {
            Firstname = firstname;
            LastName = lastname;
            Active = isActive;
        }

        public string Firstname { get; private set; }
        public string LastName { get; private set; }
        public bool Active { get; private set; }
    }
}
