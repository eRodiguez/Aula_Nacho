using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Motor_Gráfico
{
    internal class Eventos
    {
        //Variables del metodo textBox1_KeyDown
        int n;
        TextBox[] boxs1;
        TextBox[] boxs2;
        public Eventos(int ns, TextBox[]bxs1, TextBox[] bxs2)
        {
            n = ns;
            boxs1 = bxs1;
            boxs2 = bxs2;
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode >= Keys.D0 || e.KeyCode <= Keys.D9)
            {
                if (e.KeyCode >= Keys.NumPad0 || e.KeyCode <= Keys.NumPad9)
                {
                    Enfocar(boxs1, boxs2);
                }
            }
        }

        public void Enfocar(TextBox[] bxs1, TextBox[] bxs2)
        {
            switch (n)
            {
                case 0:
                    bxs1[0].Focus();
                    n--;
                    break;
                case 1:
                    bxs2[0].Focus();
                    n--;
                    break;
                case 2:
                    bxs1[1].Focus();
                    n--;
                    break;
                case 3:
                    bxs2[1].Focus();
                    n--;
                    break;
                case 4:
                    bxs1[2].Focus();
                    n--;
                    break;
                case 5:
                    bxs2[2].Focus();
                    n--;
                    break;
                case 6:
                    bxs1[3].Focus();
                    n--;
                    break;
                case 7:
                    bxs2[3].Focus();
                    n--;
                    break;
                case 8:
                    bxs1[4].Focus();
                    n--;
                    break;
                default:
                    break;
            }
        }
    }
}
