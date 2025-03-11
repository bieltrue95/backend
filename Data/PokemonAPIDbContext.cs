using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data
{
    public class PokemonAPIDbContext : DbContext
    {

        public PokemonAPIDbContext(DbContextOptions<PokemonAPIDbContext> options) : base(options) 
        {

        }
           public DbSet<TreinadorModel> Treinadores { get; set; }
           public DbSet<PokemonModel> Pokemons { get; set; }
    }
}
