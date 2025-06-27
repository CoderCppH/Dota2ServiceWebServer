using System.Text.Json.Serialization;

namespace Dota2Service.Model
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = null;
        public string Lastname { get; set; } = null;
        public string Email { get; set; } = null;
        public string Phone { get; set; } = null;
        [JsonIgnore]
        public string Password { get; set; } = null;
        public DateTime DateCreated { get; set; }
        [JsonIgnore]
        public string Token { get; set; } = null;
        public int RoleId { get; set; }
        [JsonIgnore]
        public RoleModel Role { get; set; }
        [JsonIgnore]
        public List<SubscriptionModel> Subscriptions { get; set; }

    }
}
