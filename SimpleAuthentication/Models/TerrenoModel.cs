using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Laboro.Models;

public class TerrenoModel
{
    [Key]
    [Display(Name = "Código")]
    public int idTerreno { get; set; }

    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [StringLength(30, ErrorMessage = "O campo {0} comporta até {1} caracteres apenas.")]
    [Display(Name = "Nome")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [StringLength(30, ErrorMessage = "O campo {0} comporta até {1} caracteres apenas.")]
    [Display(Name = "Localização")]
    public string Localizacao { get; set; }

    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [Display(Name = "Tamanho")]
    public float Tamanho { get; set; }
}