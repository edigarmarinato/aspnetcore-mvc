using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auth.Models;

public class LavouraModel
{
    [Key]
    [Display(Name = "Código")]
    public int idLavoura { get; set; }

    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [StringLength(20, ErrorMessage = "O campo {0} comporta até {1} caracteres apenas.")]
    [Display(Name = "Tipo de Lavoura")]
    public string Tipo { get; set; }
}