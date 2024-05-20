using asp_exam_iliyana.Models.ViewModels;
using asp_exam_iliyana.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace asp_exam_iliyana.Controllers
{
    public class CakesController : Controller
    {
        private readonly ICakeService _cakeService;
        private readonly IMapper _mapper;

        public CakesController(ICakeService cakeService, IMapper mapper)
        {
            _cakeService = cakeService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var cakes = await _cakeService.GetAllCakesAsync();

            return View(cakes);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var cake = await _cakeService.GetCakeByIdAsync(id);
            return View(cake);
        }

    }
}
