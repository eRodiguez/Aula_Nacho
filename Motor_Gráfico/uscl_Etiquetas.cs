using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Motor_Gráfico
{
    public partial class uscl_Etiquetas : UserControl
    {
        //Instaciación de librerias
        Separar separar = new Separar();
        //Variables principales
        Label[] lbls1, lbls2;
        string name;
        bool ultimo = false;
        int[] arr1, arr2;
        int posX, posY, w, h;
        public uscl_Etiquetas(Label[] lbs1, Label[] lbs2, int[] a1, int[] a2)
        {
            lbls1 = lbs1;
            lbls2 = lbs2;
            arr1 = a1;
            arr2 = a2;
            //Solo por casos practictos para el
            //desarrollo del codigo se va a usar
            //una función para llenar los arreglos
            arr1 = Llenar_Arreglo(arr1, 6, 10000, 99999);
            arr2 = Llenar_Arreglo(arr2, 6, 100, 999);
            
            InitializeComponent();
            Ejecutar();
        }
        //Metodos Temporales
        public int[] Llenar_Arreglo(int[] arr, int length, int x, int y)
        {
            arr = new int[length];
            Random rand = new Random();
            for (int i = 0; i < length; i++)
            {
                arr[i] = rand.Next(x, y);
            }
            return arr;
        }

        //Recibe un arreglo de etiquetas
        //Recibe un arreglo que contiene números

        //Funciones principales
        public void Ejecutar()
        {
            lbls1 = Ver_etiqueta_Arriba(lbls1, pnl_labels);
            lbls2 = Ver_etiqueta_Abajo(lbls2, pnl_labels);
        }

        //Variables Ver_etiqueta_Arriba
        int[] ax1;
        public Label[] Ver_etiqueta_Arriba(Label[] labels, Panel pnl)
        {
            //Aqui se implementa una funcion
            //que limpia las etiquetas actuales para mostrar las siguientes
            if (pnl.Controls.Count > 0)
            {
                name = "lbl_Ar";
                Ocultar_anterior(arr1, name, pnl);
            }
            //Se separa el arreglo para construir la etiqueta
            //Varibles del metodo
            int g = 0;
            ax1 = Digitos(arr1, ax1, g);
            //Se construllen las etiquetas
            labels = new Label[ax1.Length];
            posX = 140;
            posY = 20;
            h = 25;
            w = 20;
            name = "lbl_Ar";

            for (int i = 0; i < ax1.Length; i++)
            {
                Label label = new Label();
                LblMlt_estilo(label, i, arr1, arr2, name, pnl);
                labels[i] = label;
            }
            ultimo = true;
            return labels;
        }

        //Variables Ver_etiqueta_Abajo
        int[] ax2;
        int n = 0;
        public Label[] Ver_etiqueta_Abajo(Label[] labels, Panel pnl)
        {
            //Aqui se implementa una funcion
            //que limpia las etiquetas actuales para mostrar las siguientes
            if (pnl.Controls.Count > 0 && arr2 != null)
            {
                name = "lbl_Ab";
                Ocultar_anterior(arr2, name, pnl);
            }
            //Se separa el arreglo para construir la etiqueta
            //Varibles del metodo
            int j = 0;
            ax2 = Digitos(arr1, ax2, j);
            //Se construllen las etiquetas
            labels = new Label[ax2.Length];
            posX = 140;
            posY = 20;
            h = 25;
            w = 20;
            name = "lbl_Ab";

            for (int i = 0; i < ax2.Length; i++)
            {
                Label label = new Label();
                LblMlt_estilo(label, i, arr1, arr2, name, pnl);
                labels[i] = label;
            }
            ultimo = false;
            return labels;
        }

        //Estilo de la etiqueta
        public void LblMlt_estilo(Label mlt, int i, int[] arr1, int[] arr2, string nm, Panel pnl)
        {
            mlt.BackColor = Color.DeepSkyBlue;
            mlt.BorderStyle = BorderStyle.FixedSingle;
            mlt.Location = new Point(posX, posY);
            mlt.Size = new Size(w, h);
            mlt.Name = nm + i.ToString();
            mlt.Font = new Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            mlt.BringToFront();
            posX -= mlt.Width;
            if (ultimo)
            {
                string signo = "X";
                Lbl_text(mlt, i, arr2, signo);
            }
            else
            {
                mlt.Text = arr1[i].ToString();

            }
            pnl.Controls.Add(mlt);
        }

        public void Lbl_text(Label lbl, int i, int[] arr2, string sign)
        {
            if (n == 0)
            {
                lbl.Size = new Size(lbl.Width + 30, lbl.Height);
                lbl.Text = arr2[i].ToString() + sign;
            }
            else
            {
                lbl.Text = arr2[i].ToString();
            }
            n++;
        }

        //Metodos

        //Varibles de Digitos
        //a1 es el arreglo que contiene el número a separar
        //ax1 es el arreglo auxilia que guarda el numero separado
        public int[] Digitos(int[] a1, int[] ax1, int j)
        {
            ciclo:
                if (j < a1.Length)
                {
                    a1 = separar.Digits(ax1[j++]);
                    goto ciclo;
                }
            return a1;
        }

        public void Ocultar_anterior(int[] arr, string nm, Panel pnl)
        {
            for (int j = 0; j < arr.Length; j++)
            {
                pnl.Controls.OfType<Label>().Where(c => c.Name == nm + j.ToString()).
                ToList().ForEach(c => pnl.Controls.Remove(c));
            }
        }

        public void Imprimi_arr(int[] arr, string ttl)
        {
            MessageBox.Show(ttl);
            string toDisplay = string.Join(Environment.NewLine, arr);
            MessageBox.Show(toDisplay);
        }
    }
}
