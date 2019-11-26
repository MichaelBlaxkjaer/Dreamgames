using Microsoft.EntityFrameworkCore;

namespace dreamgames.Data
{
    public class GameContext : DbContext
    {
        public GameContext(DbContextOptions<GameContext> options)
            : base(options)
        {

        }
    }
}