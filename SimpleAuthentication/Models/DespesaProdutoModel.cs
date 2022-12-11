using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laboro.Models;

public class DespesaProdutoModel
{
    [Key]
    [Display(Name = "Código")]
    public int idDespesaProduto { get; set; }

    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [Display(Name = "Produto")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [Display(Name = "Estoque")]
    public bool ItemEstoque { get; set; }

    [ForeignKey("DespesaCategoria")]
    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [Display(Name = "DespesaCategoria")]
    public int? idDespesaCategoria { get; set; }

    [Display(Name = "DespesaCategoria")]
    public DespesaCategoriaModel DespesaCategoria { get; set; }
}