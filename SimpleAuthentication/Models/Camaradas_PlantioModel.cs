using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laboro.Models;

public class Camaradas_PlantioModel
{
    [ForeignKey("Camaradas")]
    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [Display(Name = "Camaradas")]
    public int? IdCamaradas { get; set; }

    [Display(Name = "Camaradas")]
    public CamaradasModel Camaradas { get; set; }

    [ForeignKey("Plantio")]
    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [Display(Name = "Plantio")]
    public int? IdPlantio { get; set; }

    [Display(Name = "Plantio")]
    public TerrenoModel Plantio { get; set; }

    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório")]
    [Display(Name = "Data de Inicio do Contrato")]
    public DateTime DataIniContrato { get; set; }

    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório")]
    [Display(Name = "Data de Fim do Contrato")]
    public DateTime DataFimContrato { get; set; }

    [Display(Name = "Valor")]
    public double? ValorDia { get; set; }
}