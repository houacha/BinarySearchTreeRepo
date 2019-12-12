using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace BinaryTree
{
    class Nodes<T>:IEnumerable where T : IComparable
    {
        public T value;
        public Nodes<T> leftChildNodes;
        public Nodes<T> rightChildNodes;
        private string side;
        private int level;
        private string location;
        public Nodes()
        {
        }
        public IEnumerator GetEnumerator()
        {
            if (leftChildNodes != null)
            {
                foreach (var item in leftChildNodes)
                {
                    yield return item;
                }
            }
            yield return value;
            if (rightChildNodes != null)
            {
                foreach (var item in rightChildNodes)
                {
                    yield return item;
                }
            }
        }
        public int Level { get { return level; } set { level = value; } }
        public string Side { get { return side; } set { side = value; } }
        public string Location { get { return location; } set { location = value; } }
    }
}
