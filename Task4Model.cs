using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestOfTasks.Models
{
    public class Task4Model
    {
        public IEnumerable<Tuple<int[], int[]>> Divider(int n) 
        {
            int[] c = new int[n + 1];
            int[] l = new int[n + 1];
            int j = 0;
            int k = 0;
            c[0] = 1;
            c[1] = n;
            l[0] = 1;
            l[1] = 0;
            bool exit = false;

            while (!exit)
            {
                yield return new Tuple<int[], int[]>(c.ToArray(), l.ToArray());
                j = l[0];
                k = l[j];
                if (c[j] == 1)
                {
                    if (k == 0)
                    {
                        exit = true;
                        continue;
                    }
                    else
                    {
                        c[j] = 0;
                        c[1] = k * (c[k] - 1) + j - 1;
                        j = k;
                        k = l[k];
                    }
                    if (c[1] > 0)
                    {
                        l[0] = 1;
                        l[1] = j + 1;
                    }
                    else
                    {
                        l[0] = j + 1;
                    }
                    c[j] = 0;

                    c[j + 1] = c[j + 1] + 1;
                    if (k != j + 1)
                    {
                        l[j + 1] = k;
                    }
                    continue;
                }
                if (j > 1)
                {
                    c[1] = j * (c[j] - 1) - 1;
                    if (c[1] > 0)
                    {
                        l[0] = 1;
                        l[1] = j + 1;
                    }
                    else
                    {
                        l[0] = j + 1;
                    }
                    c[j] = 0;

                    c[j + 1] = c[j + 1] + 1;
                    if (k != j + 1)
                    {
                        l[j + 1] = k;
                    }
                    continue;
                }
                c[1] = c[1] - 2;
                c[2] = c[2] + 1;
                if (c[1] == 0)
                {
                    l[0] = 2;
                }
                if (k != 2)
                {
                    l[2] = l[1];
                }
                if (c[1] > 0 && k != 2)
                {
                    l[2] = l[1];
                    l[1] = 2;
                }
            }
        }
    }
}
