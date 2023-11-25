using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeRogueLike.Entities
{
    //public class Enemy : Entity
    //{
    //    public Enemy()
    //    {

    //    }
    //    public char Symbol { get; set; }
    //    public int AttackRange { get; set; }
    //}

    public class Enemy : Entity
    {
        public Enemy()
        {
            Symbol = 'E';
            AttackRange = 1; // Дистанция атаки врага ближнего боя
        }

        public int AttackRange { get; set; }
    }

}
