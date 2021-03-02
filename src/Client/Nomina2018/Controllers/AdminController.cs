using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommonLayer;
using DtoLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Nomina2018.ViewModels;
using ServiceLayer;

namespace Nomina2018v1.Controllers
{
     [Authorize(Roles = "ADMIN")]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> logger;
        private readonly IUserService _userService;
        public AdminController(ILogger<AdminController> logger,IUserService userService)
        {

            this.logger = logger;
            _userService = userService;
        }

        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                RoleCreateDto identityRole = new RoleCreateDto
                {
                    Name = model.RoleName
                };

                var result = await _userService.CreateRole(identityRole);

                if (result.IsSuccess)
                {
                    return RedirectToAction("ListRoles", "Admin");
                }
                else
                {
                    
                    ModelState.AddModelError("", "No se pudo crear el Role");
                    throw new Exception("No se pudo crear el Role");

                }


            }

            return View(model);
        }

        public async Task<IActionResult> ListRoles()
        {
            List<RoleDto> rolesdto = new List<RoleDto>();

            rolesdto = await _userService.GetRoles();

            return View(rolesdto);
        }

        public async Task<IActionResult> EditRole(int id)
        {
            var role = await _userService.GetRoleByid(id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role con Id = {id} no fue encontrado";
                return View("NotFound");
            }


            var model = new EditRoleViewModel
            {
                Id = role.Id.ToString(),
                RoleName = role.Name
            };

            model.Users = await _userService.GetUsersInRoleAsync(id);

            return View(model);
        }

        public async Task<IActionResult> EditUsersInRole(int roleId)
        {
            ViewBag.roleId = roleId;

            var role = await _userService.GetRoleByid(roleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role con Id = {roleId} no fue encontrado";
                return View("NotFound");
            }

            var model = new List<UserRoleViewModel>();

            var users = await _userService.GetAllUsers();

            foreach (var user in users)
            {
                var userRoleViewModel = new UserRoleViewModel
                {
                    UserId = user.UsuarioId,
                    UserName = user.Alias
                };

                if (await _userService.IsInRoleAsync(user.UsuarioId, roleId))
                {
                    userRoleViewModel.IsSelected = true;
                }
                else
                {
                    userRoleViewModel.IsSelected = false;
                }

                model.Add(userRoleViewModel);
            }

            return View(model);
        }

        public IActionResult ListUsers()
        {

            return View();
        }
        [HttpGet]
        public async Task<string> DataListUsers()
        {
            var data = await _userService.GetAllUsers();



            return JsonConvert.SerializeObject(new { data});
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(int id)
        {
            var user = await _userService.GetUsuario(id);

            var userRoles = await _userService.GetRoles();

            var model = new EditUserViewModel
            {
                Id = id,
                UserName = user.Alias,
                Roles = userRoles,
                RoleId = await _userService.UserRoleAsync(id),
                Activo = await _userService.AccesoSistemaUsuario(id)
        };

            return PartialView("_EditUser", model);
        }

        [HttpPost]
        public async Task<string> EditUser(EditUserViewModel model)
        {
            var user = await _userService.GetUsuario(model.Id);


            if (user == null)
            {
                return JsonConvert.SerializeObject(new { status = "error", Message = "Ocurrio un error, los datos no se actualizaron", IsSuccess = false });
            }
            else
            {
 
                var userrole = new UsuarioRoleUpdate
                {
                    UserId = model.Id,
                    RoleId = model.RoleId
                };

                var AccesoUsuario = new UsuarioAccesoUpdateDto
                {
                    UserId = model.Id,
                    Activo = model.Activo
                };

                 var result = await _userService.InsertOrUpdateUsuarioRole(userrole,AccesoUsuario);


                return JsonConvert.SerializeObject(new { status = "error", Message = "Los Datos se han actualizado!", result.IsSuccess });

            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }


    }
}
