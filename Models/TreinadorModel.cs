using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace backend.Models
{
    public class TreinadorModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public Guid Id { get; set; } 

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DataCadastro { get; set; }

        [JsonIgnore]
        public ICollection<PokemonModel> Pokemons { get; set; }
    }
}
