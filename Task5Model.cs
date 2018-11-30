using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestOfTasks.Models
{
    public class Task5Model
    {
        public IEnumerable<string> ПажилаяЦапЦарапка(int n)
        {
            int j = 0;
            int m = 0;

            int[] a = new int[n];
            int[] b = Enumerable.Range(0, n).Select(el => 1).ToArray();
            int[] d = Enumerable.Range(0, n).Select(el => 1).ToArray();
            bool exit = false;
            bool MoveUpPart = true;

            while (!exit)
            {
                MoveUpPart = true;

                yield return String.Join("", a);

                j = n - 1;
                while (a[j] == d[j])
                {
                    d[j] = 1 - d[j];
                    j--;
                }

                if (j == 0)
                {
                    exit = true;
                    MoveUpPart = false;
                }
                else if (d[j] == 0)
                {
                    if (a[j] == b[j] - 1)
                    {
                        a[j] = b[j];
                        m = a[j] + 1;
                        b = FillB(b, j, m);
                        MoveUpPart = false;
                    }
                    else if (a[j] == b[j])
                    {
                        a[j] = 0;
                        m = b[j];
                        b = FillB(b, j, m);
                        MoveUpPart = false;
                    }
                    else
                    {
                        a[j] = a[j] + 1;
                        MoveUpPart = false;
                    }
                }

                if(MoveUpPart)
                {
                    if (a[j] == 0)
                    {
                        a[j] = b[j];
                        m = a[j] + 1;
                        b = FillB(b, j, m);
                    }
                    else if (a[j] == b[j])
                    {
                        a[j] = b[j] - 1;
                        m = b[j];
                        b = FillB(b, j, m);
                    }
                    else
                    {
                        a[j] = a[j] - 1;
                    }
                }
            }          
        }

        private int[] FillB(int[] b,int j,int m)
        {
            for (int k = j + 1; k < b.Length; k++)
            {
                b[k] = m;
            }
            return b;
        }

    }
}
