using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyToEnter.ASP.Dependence
{
    public class ModelWithId
    {
        [Key]
        [Display(Name = "Идентификатор")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}