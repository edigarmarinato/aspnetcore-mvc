using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Auth.Models;

namespace Auth.Models;

public class CamaradasModel
{
    [Key]
    [Display(Name = "Código")]
    public int idCamaradas { get; set; }

    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [StringLength(30, ErrorMessage = "O campo {0} comporta até {1} caracteres apenas.")]
    [Display(Name = "Nome")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [StringLength(45, ErrorMessage = "O campo {0} comporta até {1} caracteres apenas.")]
    [Display(Name = "Sobrenome")]
    public string Sobrenome { get; set; }

    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [StringLength(14, ErrorMessage = "O campo {0} comporta até {1} caracteres apenas.")]
    [Display(Name = "CPF")]
    public string CPF { get; set; }

    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [Display(Name = "Data de Nascimento")]
    public DateTime DataNascimento { get; set; }
}