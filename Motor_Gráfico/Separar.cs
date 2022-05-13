using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_Gráfico
{
    internal class Separar
    {
        public int[] Digits(int num)
        {
            int[] digits;
            int nDigits;
            if (num == 0)
            {
                nDigits = 5;
                digits = new int[nDigits];
                return digits;
            }
            else
            {
                nDigits = 1 + Convert.ToInt32(Math.Floor(Math.Log10(num)));
                //Console.WriteLine("El número de cifras es: " + nDigits.ToString());
                digits = new int[nDigits];

                for (int i = nDigits - 1; i != -1; i--)
                {
                    digits[i] = (int)(num % 10);
                    num = num / 10;
                }
                return digits;
            }
        }
    }
}
