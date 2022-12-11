using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laboro.Models;

public class ColheitaModel
{
    [Key]
    [Display(Name = "Código")]
    public int idColheita { get; set; }

    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [Display(Name = "Data Inicial")]
    public DateTime DataIni { get; set; }

    [Display(Name = "Data Final")]
    public DateTime DataFim { get; set; }

    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [Display(Name = "Quantidade Produzida")]
    [Range(0, 999999, ErrorMessage = "O campo {0} deve estar entre {1} e {2}.")]
    public int QuantidadeProduzida { get; set; }

    [ForeignKey("Plantio")]
    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [Display(Name = "Plantio")]
    public int? idPlantio { get; set; }

    [Display(Name = "Plantio")]
    public PlantioModel Plantio { get; set; }

    [ForeignKey("Lavoura")]
    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [Display(Name = "Lavoura")]
    public int? IdLavoura { get; set; }

    [Display(Name = "Lavoura")]
    public LavouraModel Lavoura { get; set; }
}