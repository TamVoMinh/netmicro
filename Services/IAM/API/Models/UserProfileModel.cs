namespace Nmro.IAM.Models
{
    public class UserProfileModel : BaseEntityModel<long>
    {
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
