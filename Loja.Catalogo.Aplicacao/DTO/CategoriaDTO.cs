using System.ComponentModel.DataAnnotations;

namespace Loja.Catalogo.Aplicacao.DTO
{
    public class CategoriaDTO
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Codigo { get; set; }
    }
}