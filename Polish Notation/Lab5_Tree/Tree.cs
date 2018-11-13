using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_Tree
{
    public enum kinds
    {
        constant,
        variable,
        binoper,
        unoper
    }
    public class Tree
    {
        List<TreeNode> tree;
        string plNote;
        string variables;
        List<string> vars;
        List<int> stack;

        public Tree()
        {
            tree = new List<TreeNode>();
            vars = new List<string>();
            stack = new List<int>();
        }

        public string getPlnote() { return plNote; }
        //-------------------Для введення дерева--------------------//
        public void Enter(string exp) 
        {
            tree.Clear();
            try
            {
                var e = exp.Split(' ');
                TreeNode root = new TreeNode(e[0]);
                tree.Add(root);
                int fl = 0;
                int j = 1;
                //обхід зліва
                passSubtree(e, ref j, ref fl, 0, false);

                //обхід справа
                if (j < e.Length)
                {
                    fl = tree.Count - 1;
                    passSubtree(e, ref j, ref fl, tree.Count - 1, false);
                }

                fillFreeOperators();
                Console.WriteLine("The tree was successfully added!");

            } catch(Exception e)
            {
                Console.WriteLine("There is some problems with arguments, the results may be different");
            }
        }

        private void passSubtree(string[] e, ref int j, ref int fl, int endsign, bool insert)
        {
            int i = 1;
            while (j < e.Length)
            {
                if (fl < endsign) break;

                if (tree[fl].isVariable)
                    fl--;

                if ((tree[fl].isBinaryOperator && tree[fl].chCount == 2)
                    || (!(tree[fl].isBinaryOperator) && tree[fl].chCount == 1))
                    fl--;

                if (fl < endsign) break;

                if ((tree[fl].isBinaryOperator && tree[fl].chCount < 2)
                    || (!(tree[fl].isBinaryOperator) && tree[fl].chCount < 1 && !(tree[fl].isVariable)))
                {
                    TreeNode tmp = new TreeNode(e[j], tree[fl]);
                    if (tmp.value != null)
                    {
                        if (insert)
                        {
                            tree.Insert(fl+i, tmp);
                            i++;
                        }
                        else
                            tree.Add(tmp);
                        j++;
                        fl++;
                    }
                    else
                    {
                        Console.WriteLine("There was some problems with arguments, so it was fixed");
                        break;
                    }
                }

            }
        }

        private void fillFreeOperators()
        {
            for (int i = 0; i < tree.Count; i++)
            {
                if((tree[i].isBinaryOperator && tree[i].chCount < 2)
                    || (!(tree[i].isBinaryOperator) && !(tree[i].isVariable) && tree[i].chCount < 1))
                {
                    var tmp = new TreeNode("1", tree[i]);
                    tree.Insert(i + 1, tmp);
                    if ((tree[i].isBinaryOperator && tree[i].chCount < 2))
                        tree.Insert(i + 1, tmp);
                }
            }

        }

        //-------------------Для виведення дерева/змінних-------------------//
        public void Vars()
        {
            if (vars.Count == 0)
            {
                Console.WriteLine("The tree is clear");
                return;
            }
            variables = "";
            foreach(var s in vars)
               variables += s + " ";
            Console.WriteLine($"The variables: {variables}");
        }

        private bool checkUniqueVariable(TreeNode e)
        {
            bool b = false;
            if (e.isVariable && e.isConstant == false && variableMatchCheck(e))
                b = true;
            return b;
        }

        private bool variableMatchCheck(TreeNode e)
        {
            bool b = true;
            foreach(var v in vars)
                if (e.value == v)
                    b = false;
            return b;
        }

        public void Print(bool forCounting)
        {
            if(tree.Count == 0)
            {
                Console.WriteLine("The tree is clear");
                return;
            }
            vars.Clear();
            try
            {
                if (!forCounting)
                {
                    plNote = "";
                    foreach (var t in tree)
                    {
                        plNote += t.value + " ";
                        if (checkUniqueVariable(t))
                            vars.Add(t.value);
                    }
                }
                else
                {
                    plNote = "";
                    foreach (var t in tree)
                    {
                        if (t.isVariable)
                            plNote += t.num + " ";
                        else
                            plNote += t.value + " ";
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("There are some problems");
            }
        }

        private int findByTreePos(int pos)
        {
            int a = -1;
            for (int i = 0; i < tree.Count; i++)
                if (tree[i].pos == pos)
                    a = i;
            return a;
        }

        //-------------------Для обчислення виразів--------------------//
        public void Comp(string nums)
        {
            if (tree.Count == 0)
            {
                Console.WriteLine("The tree is clear");
                return;
            }
            Print(false);
            try
            {
                stack.Clear();
                var n = nums.Split(' ');
                int i = 0;
                if (nums.Length > 0)
                {
                    do
                    {
                        for (int j = 0; j < tree.Count; j++)
                        {
                            if (tree[j].value.Equals(vars[i]) && tree[j].isVariable)
                                tree[j].num = Int32.Parse(n[i]);
                        }
                        i++;
                    }
                    while (i < nums.Length - 1);
                }
                Print(true);
                Console.WriteLine(plNote);

                for (int j = tree.Count - 1; j >= 0; j--)
                {
                    kinds mykind = parseKind(tree[j]);
                    switch (mykind)
                    {
                        case kinds.constant:
                            stack.Add(tree[j].num);
                            break;
                        case kinds.variable:
                            stack.Add(tree[j].num);
                            break;
                        case kinds.unoper:
                            doOperation1(tree[j]);
                            break;
                        case kinds.binoper:
                            doOperation2(tree[j]);
                            break;
                        default:
                            Console.WriteLine("An error occured");
                            break;
                    }
                }

                Console.WriteLine($"Result: {stack.ElementAt(0)}");
            } catch(Exception e)
            {
                Console.WriteLine("Something went wrong");
            }
        }

        private kinds parseKind(TreeNode t)
        {
            if (t.isBinaryOperator && !t.isVariable)
                return kinds.binoper;
            if (!t.isBinaryOperator && !t.isVariable)
                return kinds.unoper;
            if (!t.isBinaryOperator && t.isVariable && t.isConstant)
                return kinds.constant;
            else return kinds.variable;
        }

        private void doOperation1(TreeNode t)
        {
            string o = t.value;
            switch(o)
            {
                case "cos":
                    double res = Math.Cos(stack[stack.Count - 1]);
                    stack.RemoveAt(stack.Count - 1);
                    stack.Add((int)res);
                    break;
                case "sin":
                    double res2 = Math.Sin(stack[stack.Count - 1]);
                    stack.RemoveAt(stack.Count - 1);
                    stack.Add((int)res2);
                    break;
                default:
                    Console.WriteLine("An error occured");
                    break;
            }
        }

        private void doOperation2(TreeNode t)
        {
            string o = t.value;
            switch(o)
            {
                case "+":
                    int res1 = stack[stack.Count - 1] + stack[stack.Count - 2];
                    stack.RemoveAt(stack.Count - 1);
                    stack.RemoveAt(stack.Count - 1);
                    stack.Add(res1);
                    break;
                case "-":
                    int res2 = stack[stack.Count - 1] - stack[stack.Count - 2];
                    stack.RemoveAt(stack.Count - 1);
                    stack.RemoveAt(stack.Count - 1);
                    stack.Add(res2);
                    break;
                case "*":
                    int res3 = stack[stack.Count - 1] * stack[stack.Count - 2];
                    stack.RemoveAt(stack.Count - 1);
                    stack.RemoveAt(stack.Count - 1);
                    stack.Add(res3);
                    break;
                case "/":
                    int res4 = stack[stack.Count - 1] / stack[stack.Count - 2];
                    stack.RemoveAt(stack.Count - 1);
                    stack.RemoveAt(stack.Count - 1);
                    stack.Add(res4);
                    break;
                default:
                    break;
            }
        }

        //-------------------Для об'єднання дерев--------------------//
        public void Join(string exp)
        {
            var e = exp.Split(' ');
            List<int> leaves = new List<int>();
            foreach(var t in tree)
                if (t.chCount == 0)
                    leaves.Add(t.pos);
            Random rnd = new Random();
            int tmp = rnd.Next(0, leaves.Count);
            int p = leaves[tmp];
            int tpos = findByTreePos(p);

            TreeNode tm = tree[tpos].parent;
            tm.chCount = tm.chCount - 1;
            tree.RemoveAt(tpos);

            TreeNode tnode = new TreeNode(e[0], tm);
            tree.Insert(tpos, tnode);
            int fl = tpos;
            int j = 1;
            //обхід зліва
            passSubtree(e, ref j, ref fl, 0, true);

            //обхід справа
            if (j < e.Length)
            {
                fl = tree.Count - 1;
                passSubtree(e, ref j, ref fl, tree.Count - 1, true);
            }

            fillFreeOperators();
            Print(false);
            Console.WriteLine(getPlnote());

        }

        public void Clear()
        {
            tree.Clear();
            plNote = "";
            vars.Clear();
            stack.Clear();
        }
       
    }
}
