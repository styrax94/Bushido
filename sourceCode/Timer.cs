using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bushido
{
    public class Timer
    {
        bool timerIsFinished;
        int limit;
        int count = 0;
        float addCount = 1f;
        float currentCount = 0f;
        public void startTimer(int limit)
        {
            timerIsFinished = false;
            this.limit = limit;
        }

        public void update(GameTime gameTime)
        {
            currentCount += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (currentCount >= addCount)
            {
                count++;
                currentCount -= addCount;

            }
            if (count >= limit)
            {
                timerIsFinished = true;
                count = 0;
            }
        }

        public bool checkTimer
        {
            get { return timerIsFinished; }
        }
    }
}
