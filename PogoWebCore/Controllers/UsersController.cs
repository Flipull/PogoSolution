using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace PogoWebCore.Controllers
{
    public class UsersController : Controller
    {
        private static string ROLENAME = "Editorial";
        private readonly PogoContext _context;
        private readonly PogoRole _editorialRole;

        public UsersController(PogoContext context)
        {
            _context = context;
            try
            {
                _editorialRole = _context.Roles.Where(r => r.Name == ROLENAME)
                    .First();
            }
            catch
            {
                Problem("Identity Defaults Invalid", statusCode: 301);
            }

        }
        // GET: Users

        private List<PogoUser> GetEditorialUsers()
        {
            var editor_user_ids =
                (from ur in _context.UserRoles
                 where ur.RoleId == _editorialRole.Id
                 select ur.UserId).ToList();

            var _editorialUsers =
                _context.Users.Where(u => editor_user_ids.Contains(u.Id))
                .ToList();

            return _editorialUsers;
        }
        public IActionResult Index()
        {
            return View(GetEditorialUsers());
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            var error_list = new List<string>();
            ViewBag.Errors = error_list;
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string email, string password,
                                                [FromServices] UserManager<PogoUser> userManager)
        {
            var error_list = new List<string>();
            ViewBag.Errors = error_list;

            string corrected_email;
            try
            {
                corrected_email = new MailAddress(email).Address;
            }
            catch (FormatException)
            {
                error_list.Add("Incorrect Email");
                return View();
            }

            var new_user =
                new PogoUser
                {
                    UserName = corrected_email,//necessary for login-process?!
                    NormalizedUserName = corrected_email.ToUpperInvariant(),//necessary for login-process?!
                    Email = corrected_email,
                    NormalizedEmail = corrected_email.ToUpperInvariant(),
                    //LockoutEnabled = false,
                    EmailConfirmed = true,
                    //SecurityStamp = Guid.NewGuid().ToString()
                };
            var result = await userManager.CreateAsync(new_user, password);
            if (result.Succeeded)
            {
                var role_result = await userManager.AddToRoleAsync(new_user, ROLENAME);
                if (role_result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    foreach (var error in role_result.Errors)
                    {
                        error_list.Add(error.Description);
                    }
                }

            }
            else
            {
                foreach (var error in result.Errors)
                {
                    error_list.Add(error.Description);
                }
            }

            return View();
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pogoUser = GetEditorialUsers().FirstOrDefault(u => u.Id == id);
            if (pogoUser == null)
            {
                return NotFound();
            }

            return View(pogoUser);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pogoUser = GetEditorialUsers().FirstOrDefault(u => u.Id == id);
            _context.Users.Remove(pogoUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PogoUserExists(int id)
        {
            return GetEditorialUsers().Any(u => u.Id == id);
        }
    }
}
