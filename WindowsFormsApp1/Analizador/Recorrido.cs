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
        public static String C3D = "";
        public static Boolean id = false;
        public static string temporal;
        public static int cont = 0;
        public static void resolverOperacion(ParseTreeNode root) {

            MessageBox.Show("El resultado es: " + expresion(root.ChildNodes.ElementAt(0)));
            Program.consola.Append(C3D);

        }

        private static object expresion(ParseTreeNode root) {

            switch (root.ChildNodes.Count)
            {
                case 1: // Nodo hoja
                    if (root.ChildNodes.ElementAt(0).ToString().Split(' ')[1].ToLower().Equals("(id)"))
                    {
                        id = true;
                        return root.ChildNodes.ElementAt(0).ToString().Split(' ')[0].ToLower();
                    }
                    else {
                        String[] numero = root.ChildNodes.ElementAt(0).ToString().Split(' ');
                        Console.WriteLine(numero[0]);
                        return Convert.ToDouble(numero[0]);
                    }
                    

                case 3: // Nodo Binario
                    object x = expresion(root.ChildNodes.ElementAt(0));
                    object y = expresion(root.ChildNodes.ElementAt(2));
                    switch (root.ChildNodes.ElementAt(1).ToString().Substring(0, 1))
                    {
                        case "+":
                            if (id)
                            {
                                temporal = "t" + cont;
                                cont++;
                                C3D += temporal + "=" + x + "+" + y + "  \n";
                                return temporal;
                            }
                            return Convert.ToDouble(x) + Convert.ToDouble(y);
                        case "-":
                            if (id)
                            {
                                temporal = "t" + cont;
                                cont++;
                                C3D += temporal + "=" + x + "-" + y + "  \n";
                                return temporal;
                            }
                            return Convert.ToDouble(x) - Convert.ToDouble(y);
                        case "*":
                            if (id)
                            {
                                temporal = "t" + cont;
                                cont++;
                                C3D += temporal + "=" + x + "*" + y + "  \n";
                                return temporal;
                            }
                            return Convert.ToDouble(x) * Convert.ToDouble(y);
                        case "/":
                            if (id)
                            {
                                temporal = "t" + cont;
                                cont++;
                                C3D += temporal + "=" + x + "/" + y + "  \n";
                                return temporal;
                            }
                            return Convert.ToDouble(x) / Convert.ToDouble(y);
                        default: // (E)
                            return expresion(root.ChildNodes.ElementAt(1));
                    }
            }
            return 0.0;
        }

    }
}
