using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auth.Models;

public class ReceitaModel
{
    [Key]
    [Display(Name = "Código")]
    public int idReceita { get; set; }

    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [Display(Name = "Data")]
    public DateTime DataVenda { get; set; }

    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [Display(Name = "Quantidade")]
    [Range(0, 99999, ErrorMessage = "O campo {0} deve estar entre {1} e {2}.")]
    public int? Quantidade { get; set; }

    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [Display(Name = "Valor Unitario")]
     public double? ValorUnitario { get; set; }

    [Display(Name = "Valor Total")]
     public double? ValorTotal { get; set; }

    [ForeignKey("Lavoura")]
    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [Display(Name = "Lavoura")]
    public int? idLavoura { get; set; }

    [Display(Name = "Lavoura")]
    public LavouraModel Lavoura { get; set; } 
}