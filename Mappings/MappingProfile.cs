using asp_exam_iliyana.Models;
using asp_exam_iliyana.Models.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace asp_exam_iliyana.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterViewModel, User>();

            CreateMap<Cake, CakeViewModel>();

            CreateMap<User, UserViewModel>();

            CreateMap<IdentityRole, IdentityRoleViewModel>();
        }
    }
}
