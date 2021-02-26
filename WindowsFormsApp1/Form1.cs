using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Analizador;
using Irony.Ast;
using Irony.Parsing;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ParseTreeNode resultado = Sintactico.analizar(textBox1.Text);
            if (resultado != null)
            {
                textBox2.Text = "Entrada correcta";
                pictureBox1.Image = Image.FromFile(Path.Combine(Application.StartupPath, "AST.png"));
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                Recorrido.resolverOperacion(resultado);
            }
            else
            {
                textBox2.Text = "Entrada incorrecta";
            }
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
