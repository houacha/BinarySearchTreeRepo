using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace BinaryTree
{
    class BinarySearchTree<T>:IEnumerable where T : IComparable
    {
        private Nodes<T> root;
        private int level;
        public BinarySearchTree()
        {
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return root.GetEnumerator();
        }
        public void Add(T value)
        {
            Nodes<T> current;
            if (root == null)
            {
                root = new Nodes<T>();
                SetInfo(root, value, 0, "root");
                return;
            }
            current = root;
            level = 0;
            Check(value, current);
        }
        private void Check(T value, Nodes<T> current)
        {
            if (current.leftChildNodes != null && value.CompareTo(current.value) < 0)
            {
                level++;
                current = current.leftChildNodes;
            }
            else if (current.rightChildNodes != null && value.CompareTo(current.value) >= 0)
            {
                level++;
                current = current.rightChildNodes;
            }
            if (value.CompareTo(current.value) >= 0 && current.rightChildNodes == null)
            {
                level++;
                current.rightChildNodes = new Nodes<T>();
                SetInfo(current.rightChildNodes, value, level, current.Side + ", right");
            }
            else if (current.leftChildNodes == null && value.CompareTo(current.value) < 0)
            {
                level++;
                current.leftChildNodes = new Nodes<T>();
                SetInfo(current.leftChildNodes, value, level, current.Side + ", left");
            }
            else
            {
                Check(value, current);
            }
        }
        private void SetInfo(Nodes<T> current, T value, int level, string side)
        {
            current.value = value;
            current.Level = level;
            current.Side = side;
            current.Location = "Level: " + current.Level + "\nSide: " + current.Side;
        }
        public List<string> Search(T value)
        {
            Nodes<T> current;
            List<string> locations = new List<string>();
            current = root;
            locations = SearchCheck(value, current, locations);
            return locations;
        }
        private List<string> SearchCheck(T value, Nodes<T> current, List<string> locations)
        {
            if (value.CompareTo(current.value) > 0 && current.rightChildNodes != null && value.Equals(current.value) == false)
            {
                current = current.rightChildNodes;
                locations = SearchCheck(value, current, locations);
            }
            else if (value.CompareTo(current.value) < 0 && current.leftChildNodes != null && value.Equals(current.value) == false)
            {
                current = current.leftChildNodes;
                locations = SearchCheck(value, current, locations);
            }
            else if (value.Equals(current.value) == true)
            {
                locations.Add(current.Location);
                if (current.leftChildNodes != null || current.rightChildNodes != null)
                {
                    current = current.rightChildNodes;
                    SearchCheck(value, current, locations);
                }
            }
            return locations;
        }
    }
}
