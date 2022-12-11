using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laboro.Models;

public class PlantioModel
{
    [Key]
    [Display(Name = "Código")]
    public int idPlantio { get; set; }

    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [Display(Name = "Data Inicial")]
    public DateTime DataIni { get; set; }

    [Display(Name = "Data Final")]
    public DateTime DataFim { get; set; }

    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [Display(Name = "Quantidade de Mudas")]
    [Range(0, 99999, ErrorMessage = "O campo {0} deve estar entre {1} e {2}.")]
    public int QuantidadeMudas { get; set; }

    [ForeignKey("Lavoura")]
    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [Display(Name = "Lavoura")]
    public int? IdLavoura { get; set; }

    [Display(Name = "Lavoura")]
    public LavouraModel Lavoura { get; set; }
}