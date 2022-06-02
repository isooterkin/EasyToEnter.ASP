using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace EasyToEnter.ASP.Models.Dependence
{
    public class ModelWithId
    {
        [Key]
        [Display(Name = "Идентификатор")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("Id")]
        public int Id { get; set; }



        public string Json() => JsonConvert.SerializeObject(this, Formatting.None, new JsonSerializerSettings(){ ReferenceLoopHandling = ReferenceLoopHandling.Ignore});
    }
}