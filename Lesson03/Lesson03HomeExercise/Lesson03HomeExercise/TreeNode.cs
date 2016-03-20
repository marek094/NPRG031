using System;
using System.Collections.Generic;

namespace Lesson03HomeExercise
{
    public class TreeNode
    {
        private int value;

        /// <summary>
        /// variable parent currently unused
        /// </summary>
        private TreeNode parent;
        private TreeNode left;
        private TreeNode right;

        public TreeNode() {}

        private TreeNode(int _value) { value = _value; }

        public int Value {
            get { return value; }
        }

        public void TestInit()
        {
            value = 50;
            this.Left = new TreeNode(10);
            this.Right = new TreeNode(100);
        }

        /// <summary>
        /// Properta ukazující na rodiče ve stromu.
        /// Propertu si lze představit jako dvě metody, jednu pro Get a druhou pro Set.
        ///  <example>
        /// <code>
        /// TreeNode x = Parent;
        /// - zde se volá get. Lze nahradit metodou GetParent();
        /// 
        /// Parent = new TreeNode();
        /// - zde se volá set. Lze nahradit metodou SetParent(new TreeNode());
        /// </code>
        /// </example>
        /// </summary>
        public TreeNode Parent
        {
            get { return parent; }
            private set { parent = value; }
        }

        public TreeNode Left
        {
            get { return left; }
            private set
            {
                left = value;
                if (value != null)
                    value.Parent = this;
            }
        }

        public TreeNode Right
        {
            get { return right; }
            private set
            {
                right = value;
                if (value != null)
                    value.Parent = this;
            }
        }

        /// <summary>
        /// Prints tree by levels
        /// </summary>
        public void Print()
        {
            var items = new Queue<TreeNode>();
            items.Enqueue(this);
            items.Enqueue(null);

            while (items.Count > 1)
            {
                TreeNode act = items.Dequeue();
                if (act == null)
                {
                    Console.WriteLine();
                    items.Enqueue(null);
                }
                else
                {
                    Console.Write(act.Value + " ");
                    if (act.Left != null) items.Enqueue(act.Left);
                    if (act.Right != null) items.Enqueue(act.Right);
                }
            }

            Console.WriteLine();
            Console.WriteLine();
        }


        public void Add(int item)
        {
            var act = FindBefore(item);
            var child = new TreeNode(item);
            if (item < act.Value)
            {
                if (act.Left != null) throw new Exception("Error in left-side insert.");
                act.Left = child;
            }
            else if (act.Value < item)
            {
                if (act.Left != null) throw new Exception("Error in right-side insert.");
                act.Right = child;
            }
            else
            {
                // Is already in set
            }

            return;
        }

        /// <summary>
        /// Metoda, která vrátí TreeNode se zadanou hodnotou, jinak null.
        /// </summary>
        /// <param name="value">Hodnota, kterou hledáme.</param>
        /// <returns>Vrátí TreeNode, který jako Value má zadanou hodnotu. Pokud takový TreeNode neexistuje, vrátí null.</returns>
        public TreeNode Find(int value)
        {
            var ptr = FindBefore(value);
            return (ptr.Value == value ? ptr : null);
        }

        /// <summary>
        /// Vrátí informaci o tom, zda je zadaná hodnota ve stromu.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(int value)
        {
            var ptr = FindBefore(value);
            return ptr.Value == value;
        }

        /// <summary>
        /// Odstranění prvku ze stromu.
        /// Je zde několik možných implementací, nepožaduji žádnou konkrétní.
        /// 
        /// Je potřeba si rozmyslet několik věcí:
        /// - odstranit všechny výskyty, nebo jen jeden (explicitně napsat při odevzdání, který to bude mazat),
        /// - Skutečně odstraním prvek, nebo jej nějak označím?
        ///     - Pokud si vyberete jen označení:
        ///         - jaké bude označení?
        ///         - Správně implementovat Find a Contains.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>True => odstraněno, False => nic neodstraněno (není ve stromu).</returns>
        public bool Remove(int value)
        {
            var act = Find(value);
            if (act == null) return false;

            if (act.Left == null)
            {
                if (act.Parent.Left == act) act.Parent.Left = act.Right;
                else act.Parent.Right = act.Left;
            }
            else
            {
                // find lower bound
                var del = act.Left.FindBefore(value);
                act.value = del.Value;
                if (del == act.Left)
                {
                    act.Left = act.Left.Right;
                }
                else
                {
                    del.Parent.Right = del.Left;
                }
            }

            return true;
        }

        private TreeNode FindBefore(int value)
        {
            TreeNode prev = null, act = this;
            while (act != null)
            {
                prev = act;
                if (act.Value < value) act = act.Right;
                else if (value < act.Value) act = act.Left;
                else return act;
            }
            return prev;
        }
    }
}