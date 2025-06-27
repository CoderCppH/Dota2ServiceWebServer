using System.Text.Json.Serialization;

namespace Dota2Service.Model
{
    public class RoleModel
    {
        public int Id { get; set; }
        public string NameRole { get; set; } = null;
        public int AccessStatus { get; set; }
        [JsonIgnore]
        public ICollection<UserModel> Users { get; set; }
    }
}
