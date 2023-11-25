using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeRogueLike.Entities
{
    //public class Arrow : Entity
    //{
    //    private readonly int targetX;
    //    private readonly int targetY;

    //    public Arrow(int startX, int startY, int targetX, int targetY)
    //    {
    //        X = startX;
    //        Y = startY;
    //        SetSymbol(targetX - startX, targetY - startY);
    //    }

    //    // Устанавливаем символ в зависимости от направления стрелы
    //    private void SetSymbol(int deltaX, int deltaY)
    //    {
    //        if (deltaX != 0)
    //        {
    //            Symbol = '-';
    //        }
    //        else if (deltaY != 0)
    //        {
    //            Symbol = '|';
    //        }
    //    }

    //    public void Move()
    //    {
    //        if (X != targetX)
    //        {
    //            X += Math.Sign(targetX - X);
    //        }

    //        if (Y != targetY)
    //        {
    //            Y += Math.Sign(targetY - Y);
    //        }
    //    }
    //}

    public class Arrow : Entity
    {
        private readonly int targetX;
        private readonly int targetY;

        public Arrow(int startX, int startY, int targetX, int targetY)
        {
            X = startX;
            Y = startY;
            SetSymbol(targetX - startX, targetY - startY);
        }

        // Устанавливаем символ в зависимости от направления стрелы
        private void SetSymbol(int deltaX, int deltaY)
        {
            if (deltaX != 0)
            {
                Symbol = '-';
            }
            else if (deltaY != 0)
            {
                Symbol = '|';
            }
        }

        public void Move()
        {
            if (X != targetX)
            {
                X += Math.Sign(targetX - X);
            }

            if (Y != targetY)
            {
                Y += Math.Sign(targetY - Y);
            }
        }
    }


}
