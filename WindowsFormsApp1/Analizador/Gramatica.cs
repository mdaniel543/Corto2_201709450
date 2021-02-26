using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Ast;
using Irony.Parsing;


namespace WindowsFormsApp1.Analizador
{
    class Gramatica: Grammar
    {
        public Gramatica() : base(caseSensitive: false)
        {
            #region ER
            RegexBasedTerminal Double = new RegexBasedTerminal("decimal", "[0-9]+[.][0-9]+");
            var numero = new NumberLiteral("numero");
            IdentifierTerminal id = new IdentifierTerminal("id");
            #endregion

            #region Terminales
            var mas = ToTerm("+");
            var menos = ToTerm("-");
            var por = ToTerm("*");
            var div = ToTerm("/");
            #endregion

            #region No Terminales
            NonTerminal S = new NonTerminal("S");
            NonTerminal E = new NonTerminal("E");
            //NonTerminal T = new NonTerminal("T");
            //NonTerminal F = new NonTerminal("F");
            #endregion

            #region Gramatica 
            // GRAMATICA AMBIGUA 

            S.Rule = E;

            E.Rule = E + mas + E
                    | E + menos + E
                    | E + por + E
                    | E + div + E
                    | numero
                    | id;


            // GRAMATICA NO AMBIGUA

            //S.Rule = E;

            //E.Rule = E + mas + T
            //        | E + menos + T
            //        | T;

            //T.Rule = T + por + F
            //        | T + div + F
            //        | F;

            //F.Rule = numero
            //        | id;

            #endregion

            #region Preferencias
            this.Root = S;
            #endregion
        }
    }
}
