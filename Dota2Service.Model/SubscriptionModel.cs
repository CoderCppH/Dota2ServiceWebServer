using System.Text.Json.Serialization;

namespace Dota2Service.Model
{
    public class SubscriptionModel
    {
        public int Id { get; set; }
        public DateTime DateStartSubscription { get; set; }
        public DateTime DateFinishSubscription { get; set; }
        public string Token { get; set; } = null;
        public int UserId { get; set; }
        [JsonIgnore]
        public UserModel User { get; set; }

    }
}
