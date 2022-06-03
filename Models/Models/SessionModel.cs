using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EasyToEnter.ASP.Models.Models
{
    [Display(Name = "Сессия")]
    public class SessionModel
    {
        [Key]
        [Display(Name = "Сессия")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName(nameof(Id))]
        public Guid Id { get; set; }



        [Required(ErrorMessage = "Укажите срок жизни.")]
        [Display(Name = "Срок жизни")]
        [JsonPropertyName(nameof(LifeSpan))]
        public int LifeSpan { get; set; }
        
        
        
        [Display(Name = "Пользователь")]
        [Required(ErrorMessage = "Укажите пользователя.")]
        [JsonPropertyName(nameof(PersonId))]
        public int PersonId { get; set; }
        [ForeignKey(nameof(PersonId))]
        [Display(Name = "Пользователь")]
        [JsonPropertyName(nameof(PersonModel))]
        public PersonModel? PersonModel { get; set; }
    }
}