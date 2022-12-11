using Auth.Data;
using Auth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;
using static BCrypt.Net.BCrypt;

namespace Auth.Controllers;

[Authorize(Roles = "admin")]
public class ProdutoController : Controller
{
    private readonly AppDbContext _db;

    public ProdutoController(AppDbContext db)
    {
        _db = db;
    }

    [AllowAnonymous]
    public IActionResult Index()
    {
        var produtos = _db.Produtos
            .Include(p => p.Categoria)
            .AsNoTracking()
            .OrderBy(p => p.Nome)
            .ToList();
        return View(produtos);
    }

    [AllowAnonymous]
    private void CarregarCategorias(int? idCategoria = null)
    {
        var categorias = _db.Categorias.OrderBy(c => c.Nome).ToList();
        var categoriasSelectList = new SelectList(
            categorias, "Id", "Nome", idCategoria);
        ViewBag.Categorias = categoriasSelectList;
    }

    [HttpGet]
    [AllowAnonymous]
    public IActionResult Cadastrar()
    {
        CarregarCategorias();
        var produto = new ProdutoModel();
        return View(produto);
    }

    [HttpPost]
    [AllowAnonymous]
    public IActionResult Cadastrar(ProdutoModel produto)
    {
        if (!ModelState.IsValid)
        {
            CarregarCategorias(produto.IdCategoria);
            return View(produto);
        }
        _db.Produtos.Add(produto);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Alterar(int id)
    {
        var produto = _db.Produtos.Find(id);
        if (produto is null)
        {
            return RedirectToAction("Index");
        }
        CarregarCategorias(produto.IdCategoria);
        return View(produto);
    }

    [HttpPost]
    public IActionResult Alterar(int id, ProdutoModel produto)
    {
        var produtoOriginal = _db.Produtos.Find(id);
        if (produtoOriginal is null)
        {
            return RedirectToAction("Index");
        }
        if (!ModelState.IsValid)
        {
            CarregarCategorias(produto.IdCategoria);
            return View(produto);
        }
        produtoOriginal.Nome = produto.Nome;
        produtoOriginal.Estoque = produto.Estoque;
        produtoOriginal.Preco = produto.Preco;
        produtoOriginal.IdCategoria = produto.IdCategoria;
        _db.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Excluir(int id)
    {
        var produto = _db.Produtos.Find(id);
        if (produto is null)
        {
            return RedirectToAction("Index");
        }
        return View(produto);
    }

    [HttpPost]
    public IActionResult ProcessarExclusao(int id)
    {
        var produtoOriginal = _db.Produtos.Find(id);
        if (produtoOriginal is null)
        {
            return RedirectToAction("Index");
        }
        _db.Produtos.Remove(produtoOriginal);
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
}