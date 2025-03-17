using backend.Domain.Pokemons.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace backend.Models
{
    public class PokemonModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public Guid Id { get; set; }  

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [StringLength(200)]
        public string Habilidade { get; set; }

        [Required]
        public TipoPokemon Tipo { get; set; }

        [Range(1, 100)]
        public int Nivel { get; set; }

        [ForeignKey("TreinadorId")]
        [JsonIgnore]
        public TreinadorModel Treinador { get; set; }

        public Guid TreinadorId { get; set; }  
    }
}
