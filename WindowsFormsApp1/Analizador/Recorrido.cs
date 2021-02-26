using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;
using System.Windows.Forms;

namespace WindowsFormsApp1.Analizador
{
    class Recorrido
    {
        public static void resolverOperacion(ParseTreeNode root) {

            MessageBox.Show("El resultado es: " + expresion(root.ChildNodes.ElementAt(0)));

        }

        private static Double expresion(ParseTreeNode root) {

            switch (root.ChildNodes.Count)
            {
                case 1: // Nodo hoja
                    String[] numero = root.ChildNodes.ElementAt(0).ToString().Split(' ');
                    Console.WriteLine(numero[0]);
                    return Convert.ToDouble(numero[0]);

                case 3: // Nodo Binario 
                    switch (root.ChildNodes.ElementAt(1).ToString().Substring(0, 1))
                    {
                        case "+":
                            return expresion(root.ChildNodes.ElementAt(0)) + expresion(root.ChildNodes.ElementAt(2));
                        case "-":
                            return expresion(root.ChildNodes.ElementAt(0)) - expresion(root.ChildNodes.ElementAt(2));
                        case "*":
                            return expresion(root.ChildNodes.ElementAt(0)) * expresion(root.ChildNodes.ElementAt(2));
                        case "/":
                            return expresion(root.ChildNodes.ElementAt(0)) / expresion(root.ChildNodes.ElementAt(2));
                        default: // (E)
                            return expresion(root.ChildNodes.ElementAt(1));
                    }
            }
            return 0.0;
        }

    }
}
