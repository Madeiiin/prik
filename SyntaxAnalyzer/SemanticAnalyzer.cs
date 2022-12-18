using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntaxAnalyzer
{
    class SemanticAnalyzer
    {
		private Dictionary<string, string> _initializedVariables = new Dictionary<string, string>();
        private Dictionary<string, string> _numberWithType = new Dictionary<string, string>();
        private List<string> operationsAssignments = new List<string>();
		private List<string> expression = new List<string>();
       		private List<string> operations =  new List<string> { "<>", "=", "<", "<=", ">", ">=", "+", "-", "or", "*", "/", "and", "not" };

        private Form1 _form;

        public SemanticAnalyzer(Dictionary<string, string> numberWithType, Dictionary<string, string> initializedVariables, List<string> operationsAssignments, List<string> expression, Form1 form)
        {
            _initializedVariables = initializedVariables;
            _numberWithType = numberWithType;
            this.operationsAssignments = operationsAssignments;
            this.expression = expression;
            _form = form;
        }

       public void StartSemanticAnalyzer()
        {
            if (!CheckInitialized())
            {
                _form.CatchError($"Не инициализированная переменная");
            }
            if (!CheckDiv())
            {
                _form.CatchError($"Нельзя делить integer переменные");
            }
			if (!CheckAssignment())
			{
                _form.CatchError($"Переменной задается не верный тип");
            }
        }

        public bool CheckAssignment()
		{
            foreach (var item in operationsAssignments)
            {
                string[] itemArr = item.Split(' ');
                string type = "";
                string id = itemArr[0];
                if (_initializedVariables.ContainsKey(id))
                {
                    type = _initializedVariables[id];
                }
				if (id == "let")
				{
                    id = itemArr[1];
                    type = _initializedVariables[id];
                }

                for (int i = 1; i < itemArr.Length; i++)
                {
					if (_numberWithType.ContainsKey(itemArr[i]) || itemArr[i] == "true" || itemArr[i] == "false")
					{
                        if( ((itemArr[i] == "true" || itemArr[i] == "false") && type != "$" /*bool*/ ) || (_numberWithType[itemArr[i]] != type))
                        {
                            return false;
						}
					}
                    else if (_initializedVariables.ContainsKey(itemArr[i]))
					{
						if (_initializedVariables[itemArr[i]] != type)
						{
                            return false;
                        }
					}
                }
            }
            return true;
        }

        public bool CheckDiv()
		{
            foreach (var item in operationsAssignments)
            {
                string[] itemArr = item.Split(' ');
                string type = "";
                string id = itemArr[0];
                if (_initializedVariables.ContainsKey(id))
				{
                    type = _initializedVariables[id];
                }
                
                for (int i = 1; i < itemArr.Length; i++)
                {
                    if (itemArr[i] == "/" && (type == "%" || type == "$") /*int bool*/)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public bool CheckInitialized()
        {
            foreach (var item in operationsAssignments)
            {
                string[] itemArr = item.Split(' ');
                for (int i = 0; i < itemArr.Length; i++)
                {
                    if (!_initializedVariables.ContainsKey(itemArr[i])
                        && !_numberWithType.ContainsKey(itemArr[i]) 
                        && itemArr[i] != "="
                        && !operations.Contains(itemArr[i])
                        && itemArr[i] != "true"
                        && itemArr[i] != "false")
                    {
                        return false;
                    }
                }
            }

            foreach (var item in expression)
            {
                string[] itemArr = item.Split(' ');
                for (int i = 0; i < itemArr.Length; i++)
                {
                    if (!_initializedVariables.ContainsKey(itemArr[i])
                        && !_numberWithType.ContainsKey(itemArr[i])
                        && !operations.Contains(itemArr[i])
                        && itemArr[i] != "true"
                        && itemArr[i] != "false")
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
