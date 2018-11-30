using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestOfTasks.Models
{
    public class CryptArithmetic
    {
        private int[] assinged;

        private char[] chars;

        private List<string> wordsBeforeEquals;
        private List<string> wordsAfterEquals;

        private int[] numValues;
        private int topc;

        private char? operation;

        public CryptArithmetic()
        {
            InitFields();
        }

        private void InitFields()
        {
            assinged = new int[11];
            chars = new char[11];
            numValues = new int[11];
            wordsBeforeEquals = null;
            wordsAfterEquals = null;
            topc = 0;
            operation = null;
        }

        private double ApplyOperation(double a, double b)
        {
            switch (operation.Value)
            {
                case '+':
                    {
                        return a + b;
                    }
                case '-':
                    {
                        return a - b;
                    }
                case '*':
                    {
                        return a * b;
                    }
                case '/':
                    {
                        return a / b;
                    }
                default:
                    throw new InvalidOperationException("Неизвестный символ");
            }
        }

        private void SetOperation(string equation)
        {
            if(equation.Contains('*'))
            {
                operation = '*';
                return;
            }
            if (equation.Contains('/'))
            {
                operation = '/';
                return;
            }
            if (equation.Contains('+'))
            {
                operation = '+';
                return;
            }
            if (equation.Contains('-'))
            {
                operation = '-';
                return;
            }
        }

        public Tuple<char[], int[]> SolveEquation(string equation)
        {
            SetOperation(equation);

            var allwords = equation.Split('=');

            if(allwords.Count() != 2)
            {
                throw new ArgumentOutOfRangeException("Было больше знаков равно чем 1");
            }

            wordsBeforeEquals = allwords[0].Split('*','/','+','-').Select(el => el).ToList();
            wordsAfterEquals = allwords[1].Split('*', '/', '+', '-').Select(el => el).ToList();

            List<string> words = new List<string>();

            words.AddRange(wordsBeforeEquals);
            words.AddRange(wordsAfterEquals);

            int flag = 0;
            bool exit = false;

            for (int k = 0; k < words.Count; k++)
            {
                for (int i = 0; i < words[k].Length; i++)
                {
                    for (int j = 0; !exit && j <= topc; j++)
                    {
                        if (words[k][i] != chars[j])
                        {
                            flag = 1;
                        }
                        else
                        {
                            flag = 0;
                            exit = true;
                        }
                    }
                    exit = false;
                    if (flag == 1)
                    {
                        chars[topc++] = words[k][i];
                    }
                }
            }

            try
            {
                if (Solve(0, assinged))
                {
                    return new Tuple<char[], int[]>(chars, numValues);
                }
                else
                {
                    return null;
                }
            }
            catch (StackOverflowException)
            {
                return null;
            }
            catch(InvalidOperationException)
            {
                return null;
            }
        }

        bool Solve(int ind, int[] temp1)
        {
            int[] temp2 = new int[10];
            for (int i = 0; i < 10; i++)
            {
                if (temp1[i] == 0)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        temp2[j] = temp1[j];
                    }
                    temp2[i] = 1;
                    numValues[ind] = i;
                    if (ind == (topc - 1))
                    {
                        if (Verify())
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (Solve(ind + 1, temp2))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private double[] GetNumbersFromWords(List<string> words)
        {
            char ch;
            int in1;
            double[] numbers = new double[words.Count];
            for (int k = 0; k < words.Count; k++)
            {
                int power = 1;
                int i = words[k].Length - 1;
                while (i >= 0)
                {
                    ch = words[k][i];
                    in1 = 0;
                    bool exit = false;
                    while (!exit && in1 != topc)
                    {
                        if (chars[in1] == ch)
                        {
                            exit = true;
                        }
                        else
                        {
                            in1++;
                        }
                    }
                    numbers[k] += power * numValues[in1];
                    power *= 10;
                    i--;
                }
            }
            return numbers;
        }

        private bool Verify()
        {
            return GetNumbersFromWords(wordsBeforeEquals).Aggregate((a, b) => ApplyOperation(a, b))
                == GetNumbersFromWords(wordsAfterEquals).Aggregate((a, b) => ApplyOperation(a, b));
        }
    }
}
