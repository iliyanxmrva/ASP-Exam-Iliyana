using System.ComponentModel.DataAnnotations;

namespace asp_exam_iliyana.Models.ViewModels
{
    public class IdentityRoleViewModel
    {
        public Guid? Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
