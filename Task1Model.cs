using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestOfTasks.Models
{
    public class Task1Model
    {
        public IEnumerable<string> GetStrings(string inputChars, int maxLevel, int charsToTakeCount)
        {
            if (inputChars != null)
            {
                IEnumerable<string> Recursion(string output, int currentLevel)
                {
                    if (currentLevel <= maxLevel)
                    {
                        yield return output;
                        for (int i = 0; i < charsToTakeCount; i++)
                        {
                            foreach (var item in Recursion(output + inputChars[i], currentLevel + 1))
                            {
                                yield return item;
                            }
                        }
                    }
                }
                return Recursion("", 0);
            }
            else
            {
                return new List<string>();
            }
        }
    }
}
