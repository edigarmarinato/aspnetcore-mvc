using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laboro.Models;

public class DespesaProduto_PlantioModel
{

    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [Display(Name = "Quantidade")]
    [Range(0, 99999, ErrorMessage = "O campo {0} deve estar entre {1} e {2}.")]
    public int? Quantidade { get; set; }

    [Display(Name = "Estoque")]
    public bool ItemEstoque { get; set; }

    [ForeignKey("DespesaProduto")]
    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [Display(Name = "Despesa Produto")]
    public int? idDespesaProdutos { get; set; }

    [Display(Name = "DespesaProduto")]
    public DespesaProdutoModel DespesaProduto { get; set; }

    [ForeignKey("Plantio")]
    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [Display(Name = "Plantio")]
    public int? IdPlantio { get; set; }

    [Display(Name = "Plantio")]
    public TerrenoModel Plantio { get; set; }
}