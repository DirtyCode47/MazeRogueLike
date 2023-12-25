// В файле MeleeEnemy.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeRogueLike.Entities
{
    public class MeleeEnemy : Enemy
    {
        public MeleeEnemy()
        {
            Symbol = 'E';
            AttackPower = 2; // Сила атаки врага ближнего боя
            Health = 5; // Здоровье врага ближнего боя
        }

        public int AttackPower { get; set; }
        public int Health { get; set; }
    }
}