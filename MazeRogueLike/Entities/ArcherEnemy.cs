// В файле ArcherEnemy.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeRogueLike.Entities
{
    public class ArcherEnemy : Enemy
    {
        public ArcherEnemy()
        {
            Symbol = 'A';
            AttackPower = 1; // Сила атаки врага лучника
            Health = 3; // Здоровье врага лучника
            AttackRange = 3; // Дистанция атаки врага лучника
        }

        public int AttackPower { get; set; }
        public int Health { get; set; }
        public int AttackRange { get; set; }
    }
}