using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TP3_EcoWatch.Controllers
{
    public class RolesController : Controller
    {

        private readonly RoleManager<IdentityRole> _rolemanager;
        public RolesController(RoleManager<IdentityRole> rolemanager) { 

            _rolemanager = rolemanager;
        
        }
        public IActionResult Index2()
        {
            var roles = _rolemanager.Roles;
            return View(roles);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [HttpGet]
        public IActionResult Create(IdentityRole role)
        {
            if (!_rolemanager.RoleExistsAsync(role.Name).GetAwaiter().GetResult())
            {
                _rolemanager.CreateAsync(new IdentityRole(role.Name)).GetAwaiter().GetResult();
            }
            {

            }
            return RedirectToAction("Index2");
        }
    }
}
