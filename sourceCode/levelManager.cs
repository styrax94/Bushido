using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bushido
{
    public static class levelManager
    {
        /*        public static bool trainLevel = false;
        public static bool levelOne = false;
        public static bool levelTwo = false;
        public static bool levelThree = false;

        public static bool trainLevelIsFinished = false;
        public static bool levelOneIsFinished = false;
        public static bool levelTwoIsFinished = false;
        public static bool levelThreeIsFinished = false;

        public static void changeLevelStatus()
        {
            if (levelOneIsFinished)
            {
                levelOne = false;
            }
            if (levelTwoIsFinished)
            {
                levelTwo = false;
            }
            if (levelThreeIsFinished)
            {
                levelThree = false;
            }
            if (trainLevelIsFinished)
            {
                trainLevel = false;
            }
        }
        */


        public enum levels
        {
            trainLevel,
            levelOne,
            levelTwo,
            levelThree,
            none
        }

        public static levels levelIndicator = levels.none;

    }

      
}
