using Auth.Data;
using Auth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static BCrypt.Net.BCrypt;

namespace Auth.Controllers;

[Authorize(Roles = "admin")]
public class UsuarioController : Controller

{
    private readonly AppDbContext _db;

    public UsuarioController(AppDbContext db)
    {
        _db = db;
    }

    [Authorize(Roles = "admin")]

    public IActionResult Index()
    {
        var usuarios = _db.Usuarios
            .AsNoTracking()
            .OrderBy(c => c.Nome)
            .ToList();
        return View(usuarios);
    }

    [HttpGet]
    public IActionResult Cadastrar()
    {
        var model = new UsuarioModel();
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Cadastrar(UsuarioModel usuario)
    {
        if (!ModelState.IsValid)
        {
            return View(usuario);
        }

        var existente = _db.Usuarios.Any(u => u.Email == usuario.Email);
        if (existente)
        {
            ModelState.AddModelError("Email", "Já existe um usuário cadastrado com este e-mail.");
            return View(usuario);
        }

        usuario.Senha = HashPassword(usuario.Senha, 10);
        await _db.Usuarios.AddAsync(usuario);
        if (_db.SaveChanges() > 0)
        {
            return RedirectToAction(nameof(Index));
        }
        else
        {
            ModelState.AddModelError(string.Empty,
                "Ocorreu um erro desconhecido ao cadastrar seus dados. Tente novamente mais tarde.");
            return View(usuario);
        }
    }

    [HttpGet]
    public IActionResult Alterar(int Id)
    {
        var usuario = _db.Usuarios.Find(Id);

        if (usuario is null)
        {
            return RedirectToAction("Index");
        }
        return View(usuario);
    }

    [HttpPost]
    public IActionResult Alterar(int id, UsuarioModel usuario)
    {
        var usuarioOriginal = _db.Usuarios.Find(id);
        if (usuarioOriginal is null)
        {
            return RedirectToAction("Index");
        }
        usuarioOriginal.Nome = usuario.Nome;
        usuarioOriginal.Email = usuario.Email;
        usuarioOriginal.Senha = usuarioOriginal.Senha;
        usuarioOriginal.IsAdmin = usuario.IsAdmin;
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Excluir(int Id)
    {
        var usuario = _db.Usuarios.Find(Id);
        if (usuario is null)
        {
            return RedirectToAction("Index");
        }
        return View(usuario);
    }

    [HttpPost]
    public IActionResult ProcessarExclusao(int idUsuario)
    {
        var usuarioOriginal = _db.Usuarios.Find(idUsuario);
        if (usuarioOriginal is null)
        {
            return RedirectToAction("Index");
        }
        _db.Usuarios.Remove(usuarioOriginal);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}