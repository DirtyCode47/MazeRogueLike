using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeRogueLike.Entities
{
    public class Player : Entity
    {
        public Player()
        {
            Symbol = 'P';
            IsDead = false;
        }
        public int AttackPower { get; set; } = 2; // Сила атаки игрока
        public int Health { get; set; } = 10; // Здоровье игрока
        public bool IsDead { get; set; }
    }
}
