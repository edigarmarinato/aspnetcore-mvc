using Auth.Data;
using Auth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Auth.Controllers;

[Authorize(Roles = "admin")]
public class CamaradasController : Controller
{
    private readonly AppDbContext _db;

    public CamaradasController(AppDbContext db)
    {
        _db = db;
    }

    [AllowAnonymous]
    public IActionResult Index()
    {
        var camaradas = _db.Camaradas
            .AsNoTracking()
            .OrderBy(c => c.Nome)
            .ToList();
        return View(camaradas);
    }

    [HttpGet]
    public IActionResult Cadastrar()
    {
        var camarada = new CamaradasModel();
        return View(camarada);
    }

    [HttpPost]
    public IActionResult Cadastrar(CamaradasModel camarada)
    {
        if (!ModelState.IsValid)
        {
            return View(camarada);
        }
        _db.Camaradas.Add(camarada);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Alterar(int id)
    {
        var camarada = _db.Camaradas.Find(id);
        if (camarada is null)
        {
            return RedirectToAction("Index");
        }
        return View(camarada);
    }

    [HttpPost]
    public IActionResult Alterar(int id, CamaradasModel camarada)
    {
        var camaradaOriginal = _db.Camaradas.Find(id);
        if (camaradaOriginal is null)
        {
            return RedirectToAction("Index");
        }

        if (!ModelState.IsValid)
        {
            return View(camarada);
        }

        camaradaOriginal.Nome = camarada.Nome;
        camaradaOriginal.Sobrenome = camarada.Sobrenome;
        camaradaOriginal.CPF = camarada.CPF;
        camaradaOriginal.DataNascimento = camarada.DataNascimento;
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Excluir(int id)
    {
        var camarada = _db.Camaradas.Find(id);
        if (camarada is null)
        {
            return RedirectToAction("Index");
        }
        return View(camarada);
    }

    [HttpPost]
    public IActionResult ProcessarExclusao(int id)
    {
        var camaradaOriginal = _db.Camaradas.Find(id);
        if (camaradaOriginal is null)
        {
            return RedirectToAction("Index");
        }
        _db.Camaradas.Remove(camaradaOriginal);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}