using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laboro.Models;

public class ComprasModel
{
    [Key]
    [Display(Name = "Código")]
    public int idCompras { get; set; }

    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [Display(Name = "Data")]
    public DateTime Data { get; set; }

    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [Display(Name = "Quantidade")]
    [Range(0, 99999, ErrorMessage = "O campo {0} deve estar entre {1} e {2}.")]
    public int? Quantidade { get; set; }

    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [Display(Name = "Valor Unitario")]
     public double? ValorUnitario { get; set; }

    [Display(Name = "Valor Total")]
     public double? ValorTotal { get; set; }

    [ForeignKey("DespesaProduto")]
    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [Display(Name = "Despesa Produto")]
    public int? idDespesaProduto { get; set; }

    [Display(Name = "DespesaProdutos")]
    public DespesaProdutoModel DespesaProduto { get; set; }

    [ForeignKey("DespesaCategoria")]
    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [Display(Name = "Despesa Categoria")]
    public int? idDespesaCategoria { get; set; }

    [Display(Name = "DespesaCategoria")]
    public DespesaCategoriaModel DespesaCategoria { get; set; }    
}