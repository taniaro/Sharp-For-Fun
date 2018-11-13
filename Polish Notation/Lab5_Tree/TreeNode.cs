using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_Tree
{

    public class TreeNode
    {
        public bool isVariable; //чи є вузол назвою змінної (якщо ні - то він оператор)
        public bool isBinaryOperator;
        public bool isConstant;
        public int num; //для змінних - число яке вставляють для обчислень
        public int pos; //позиція в дереві
        public string value; //значення, що міститься в вузлі (назва змінної чи оператор)
        public TreeNode parent; //батьківський елемент (може бути лише оператором)
        public int chCount;

        static string[] bin_operators = { "+", "-", "*", "/"};
        static string[] un_operators = { "sin", "cos" };
        static string[] not_allowed = {"!", "@", "#", "$", "%", "^", "&", "(", ")",
                            "_", "=", ".", ",", "\"", "`", "|", "?"};

        public TreeNode(string value)
        {
            if (checkIfNotAllowedValue()) return;
            this.value = value;
            checkKind();
            parent = null;
            pos = 1;
            chCount = 0;
        }

        public TreeNode(string value, TreeNode parent)
        {
            if (parent.chCount == 2) return;
            if (parent.chCount == 1 && parent.isBinaryOperator == false) return;
            if (parent.isVariable) return;
            if (checkIfNotAllowedValue()) return;

            this.value = value;
            this.parent = parent;
            checkKind();
            checkIfConst();
            if (isConstant) num = Int32.Parse(value);
            pos = (parent.chCount == 0) ? parent.pos * 2 : parent.pos * 2 + 1;
            chCount = 0;
            parent.chCount++;
        }

        public void checkKind()
        {
            isVariable = !(un_operators.Any(o => o.Equals(value))
                || bin_operators.Any(o => o.Equals(value)));

            isBinaryOperator = bin_operators.Any(o => o.Equals(value));
        }

        public void checkIfConst()
        {
            int a;
            isConstant = Int32.TryParse(value, out a);
        }

        public bool checkIfNotAllowedValue()
        {
            return not_allowed.Any(a => a.Equals(value));
        }

        public void setNum(int n) { if (isVariable) num = n; }

        public string getVal() { return value; }
        
    }
}
