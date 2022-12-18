using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntaxAnalyzer
{
    public static class DataTable
    {
        public static List<string> GetServlceWords()
        {
            return new List<string>()
            {
                "program",
                "var",
                "begin",
                "end.",
                "do",
                "while",
                "end_else",
                "if",
                "then",
                "else",
                "for",
                "let",
                "input",
                "loop",
                "false",
                "%",
                "!",
                "$",
                "true"            };
        }

        public static List<string> GetSeparators()
        {
            return new List<string>()
            {
                "=",
                "or",
                "-",
                "+",
                "<=", 
                "<>", 
                "<", 
                ">=",
                ">", 
                "*",
                "/",
                "and",
                "not",
                ";",
                ":",
                ",",
                "{",
                "}",
                "(",
                ")",
                "#",
                " "
            };
        }





















































        public static List<string> GetServiceWords()
        {
            return new List<string>()
            {
                "program",
                "var",
                "begin",
                "end.",
                "do",
                "while",
                "end_else",
                "if",
                "then",
                "else",
                "for",
                "let",
                "input",
                "loop",
                "output",
                "false",
                "%",
                "!",
                "$", 
                "true",
                "'"
            };
        }
    }


   
}
