using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityQuest.Services
{
    public static class LevelCalculator
    {
        public static int CalculateLevel(int totalExp, out int expIntoCurrentLevel, out int expToNextLevel)
        {
            int level = 1;
            int requiredExp = 100;
            expIntoCurrentLevel = totalExp;

            while (expIntoCurrentLevel >= requiredExp)
            {
                level++;
                expIntoCurrentLevel -= requiredExp;
                requiredExp += 10;
            }

            expToNextLevel = requiredExp;

            return level;
        }
    }
}
