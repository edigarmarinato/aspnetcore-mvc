using Auth.Data;
using Auth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Auth.Controllers;

public class CadastrosController : Controller
{
    public IActionResult Cadastro()
    {
        return View("Cadastro");
    }
}