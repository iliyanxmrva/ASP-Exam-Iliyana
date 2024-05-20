using asp_exam_iliyana.Models;
using asp_exam_iliyana.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace asp_exam_iliyana.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ICakeService _cakeService;
        private readonly SignInManager<User> _signInManager;

        public OrdersController(ICakeService cakeService, SignInManager<User> signInManager)
        {
            _cakeService = cakeService;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Index(Guid CakeId)
        {
            var cake = await _cakeService.GetCakeByIdAsync(CakeId);
            var userId = _signInManager.Context.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var newOrder = new Order(userId, CakeId);

            return View();
        }
    }
}
