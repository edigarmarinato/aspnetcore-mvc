using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auth.Models;

public class Camaradas_ColheitaModel
{
    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [Display(Name = "Data de Inicio do Contrato")]
    public DateTime DataIniContrato { get; set; }

    [Display(Name = "Data de Fim do Contrato")]
    public DateTime DataFimContrato { get; set; }

    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [Display(Name = "Valor")]
    [Range(0, 9999, ErrorMessage = "O campo {0} deve estar entre {1} e {2}.")]
    public double ValorDia { get; set; }

    [ForeignKey("Camaradas")]
    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [Display(Name = "Camaradas")]
    public int? idCamaradas { get; set; }

    [Display(Name = "Camaradas")]
    public CamaradasModel Camaradas { get; set; }

    [ForeignKey("Colheita")]
    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [Display(Name = "Colheita")]
    public int? idColheita { get; set; }

    [Display(Name = "Colheita")]
    public ColheitaModel Colheita { get; set; }
}