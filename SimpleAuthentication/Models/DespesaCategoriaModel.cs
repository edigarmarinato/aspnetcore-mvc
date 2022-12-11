using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auth.Models;

public class DespesaCategoriaModel
{
    [Key]
    [Display(Name = "Código")]
    public int idDespesaCategoria { get; set; }

    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [StringLength(30, ErrorMessage = "O campo {0} comporta até {1} caracteres apenas.")]
    [Display(Name = "Despesa")]
    public string Nome { get; set; }
}