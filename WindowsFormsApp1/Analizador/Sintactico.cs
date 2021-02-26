using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Ast;
using Irony.Parsing;
using WindowsFormsApp1.DOT;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Diagnostics;

namespace WindowsFormsApp1.Analizador
{
    class Sintactico : Grammar
    {
        public static ParseTreeNode analizar(String cadena) {
            Gramatica gramatica = new Gramatica();
            LanguageData language = new LanguageData(gramatica);
            Parser parser = new Parser(language);
            ParseTree arbol = parser.Parse(cadena);
            ParseTreeNode raiz = arbol.Root;
            if (raiz == null)
            {
                return null;
            }
            generarImagen(raiz);
           
            return raiz;
        }
        private static void generarImagen(ParseTreeNode raiz) {
            String grafoDOT = ControlDOT.getDOT(raiz);

            Console.WriteLine(grafoDOT);

            String rdot = "AST.dot";
            String rpng = "AST.png";
            System.IO.File.WriteAllText(rdot, grafoDOT);
            ProcessStartInfo startInfo = new ProcessStartInfo("dot.exe");
            startInfo.Arguments = "-Tpng " + rdot + " -o " + rpng + "";
            Process.Start(startInfo);
            //abrirgrafo();
        }
        public static void abrirgrafo()
        {
            if (File.Exists("AST.png"))
            {
                try
                {
                    System.Diagnostics.Process.Start("AST.png");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR" + ex);
                }
            }
        }
    }
}
