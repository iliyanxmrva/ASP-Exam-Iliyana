using asp_exam_iliyana.Models;
using asp_exam_iliyana.Models.ViewModels;
using asp_exam_iliyana.Services;
using asp_exam_iliyana.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace asp_exam_iliyana.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;
        private readonly ICakeService _cakeService;

        public AdminController(UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<User> signInManager,
            IMapper mapper,
            ICakeService cakeService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _cakeService = cakeService;
        }

        public async Task<IActionResult> Index()
        {
            List<int> statistics = new List<int>();

            //Ammount of cakes
            var cakesCount = await _cakeService.CakesAmmountAsync();
            statistics.Add(cakesCount);

            //Ammount of users
            var usersCount = await _userManager.Users.CountAsync();
            statistics.Add(usersCount);

            return View(statistics);
        }

        public async Task<IActionResult> Cakes()
        {
            var getCakes = await _cakeService.GetAllCakesAsync();
            return View(getCakes);
        }

        public IActionResult ViewCake(Guid id)
        {
            return View();
        }

        public IActionResult EditCake(Guid id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddCake()
        {
            Cake cake = new Cake();
            return View(cake);
        }

        [HttpPost]
        public async Task<IActionResult> AddCake(Cake cake)
        {
            Cake newCake = new Cake(cake.Name, cake.Filling.Id, cake.Description, cake.Price, cake.ImageUrl);

            await _cakeService.AddCakeAsync(newCake);
            return View();
        }

        [HttpGet]
        public IActionResult AddCakeFillings()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCakeFillings(CakeFilling filling)
        {
            await _cakeService.AddFillingAsync(filling);
            return RedirectToAction("Cakes");
        }

        public async Task<IActionResult> DeleteCake(Guid id)
        {
            var cake = await _cakeService.GetCakeByIdAsync(id);

            if (cake == null)
            {
                return RedirectToAction("Cakes");
            }

            var result = await _cakeService.DeleteCakeAsync(cake);

            if (result == true)
            {
                return RedirectToAction("Cakes");
            }

            return NotFound();
        }

        public async Task<IActionResult> Users()
        {
            var users = await _userManager.Users.Select(u => _mapper.Map<UserViewModel>(u)).ToListAsync();
            return View(users);
        }

        public async Task<IActionResult> AssignRoleUser(Guid id, string[] selectedRoles)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var userRoles = await _userManager.GetRolesAsync(user);

            foreach (var role in userRoles)
            {
                if (!selectedRoles.Contains(role))
                {
                    await _userManager.RemoveFromRoleAsync(user, role);
                }
            }

            foreach (var role in selectedRoles)
            {
                if (!userRoles.Contains(role))
                {
                    await _userManager.AddToRoleAsync(user, role);
                }
            }

            userRoles = await _userManager.GetRolesAsync(user);
            var uvm = _mapper.Map<UserViewModel>(user);

            uvm.UserRoles = userRoles;
            uvm.AllRoles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();

            await _signInManager.RefreshSignInAsync(user);

            return View(uvm);
        }

        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                return RedirectToAction("Users");
            }

            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction("Users");
            }

            return NotFound();
        }

        public async Task<IActionResult> Roles()
        {
            var roles = await _roleManager.Roles.Select(r => _mapper.Map<IdentityRoleViewModel>(r)).ToListAsync();

            return View(roles);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            IdentityRoleViewModel vm = new IdentityRoleViewModel();
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(IdentityRoleViewModel roleViewModel)
        {
            var role = new IdentityRole(roleViewModel.Name);

            var result = await _roleManager.CreateAsync(role);

            return RedirectToAction("Roles");

        }

        [HttpGet]
        public async Task<IActionResult> EditRole(Guid id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());

            var vm = _mapper.Map<IdentityRoleViewModel>(role);

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(IdentityRoleViewModel roleViewModel, Guid id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            
            role.Name = roleViewModel.Name;

            var result = await _roleManager.UpdateAsync(role);

            if (result.Succeeded)
            {
                return RedirectToAction("Roles");
            }
            else
            {
                return View();
            }
        }

        public async  Task<IActionResult> DeleteRole(Guid id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());

            if (role == null)
            {
                return RedirectToAction("Roles");
            }

            var result = await _roleManager.DeleteAsync(role);

            if (result.Succeeded)
            {
                return RedirectToAction("Roles");
            }

            return NotFound();
        }
    }
}
