using ECommerce.Operation.Authorize;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Service.Controllers;

public class UserController
{
    [AdminAuthorize]
    [HttpPost("AddAdmin")]
    public IActionResult AddAdmin()
    {
        // Sadece adminler tarafından erişilebilen metot
    }

    [HttpPost("CreateUser")]
    public IActionResult CreateUser()
    {
        // Herhangi bir kullanıcı tarafından erişilebilen metot
    }
}
