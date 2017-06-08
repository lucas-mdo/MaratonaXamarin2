using Newtonsoft.Json;

namespace MaratonaApp.Model
{
    /// <summary>
    /// Usuário
    /// </summary>
    public class User
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }
    }
}
