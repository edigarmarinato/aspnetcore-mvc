using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auth.Models;

public class Terreno_PlantioModel
{
    [ForeignKey("Terreno")]
    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [Display(Name = "Terreno")]
    public int? IdTerreno { get; set; }

    [Display(Name = "Terreno")]
    public TerrenoModel Terreno { get; set; }

    [ForeignKey("Plantio")]
    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [Display(Name = "Plantio")]
    public int? IdPlantio { get; set; }

    [Display(Name = "Plantio")]
    public TerrenoModel Plantio { get; set; }
}