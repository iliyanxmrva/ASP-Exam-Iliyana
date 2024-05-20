using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace asp_exam_iliyana.Models.ViewModels
{
    public class UserViewModel
    {
        public Guid? Id { get; set; }
        public string? Email { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public IList<string>? AllRoles { get; set; }
        public IList<string>? UserRoles { get; set; }
    }
}
