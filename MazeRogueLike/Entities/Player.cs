using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeRogueLike.Entities
{


    //public class Player : Entity
    //{
    //    public Player()
    //    {
    //        Symbol = 'P';
    //        IsDead = false;
    //    }

    //    public bool IsDead { get; set; }
    //}


    public class Player : Entity
    {
        public Player()
        {
            Symbol = 'P';
            IsDead = false;
        }

        public bool IsDead { get; set; }
    }


}
