using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestOfTasks.Models
{
    public class Task3Model
    {

        public IEnumerable<int[]> Dualist(int n, int s)
        {
            int[] b = new int[s];
            int t = n - s;
            int j = 0;
            for (int i = 0; i < s; i++)
            {
                b[i] = i + n - s;
            }
            bool exit = false;
            while (!exit)
            {
                yield return b.Reverse().ToArray();
                if (j < s)
                {
                    b[j] = b[j] - 1;
                    if (b[j] <= j)
                    {
                        j = j + 1;
                        continue;
                    }
                    else
                    {
                        while (j > 0)
                        {
                            b[j - 1] = b[j] - 1;
                            j = j - 1;
                        }
                        continue;
                    }
                }
                else
                {
                    exit = true;
                }
            }
        }
    }
}
