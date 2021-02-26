using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Parsing;
 

namespace WindowsFormsApp1.DOT
{
    class ControlDOT
    {
        private static int contador;
        private static String grafo;

        public static String getDOT(ParseTreeNode raiz) {
            grafo = "digraph G{";
            grafo += "node[label=\"" + escapar(raiz.ToString()) + "\"]; \n";
            contador = 1;
            recorrerAST("nodo0", raiz);
            grafo += "}";
            return grafo;
        }

        private static void recorrerAST(String padre, ParseTreeNode hijos) {
            foreach (ParseTreeNode hijo in hijos.ChildNodes)
            {
                String nombreHijo = "nodo" + contador.ToString();
                grafo += nombreHijo + "[label = \"" + escapar(hijo.ToString()) + "\"];\n";
                grafo += padre + "->" + nombreHijo + ";\n";
                contador ++;
                recorrerAST(nombreHijo, hijo);
            }
        
        }

        private static String escapar(String cadena) {
            cadena = cadena.Replace("\\", "\\\\");
            cadena = cadena.Replace("\"", "\\\"");
            return cadena;
        }
    }
}
