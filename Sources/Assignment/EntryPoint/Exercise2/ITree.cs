using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint.Exercise2Folder
{
    public interface KDTree<T>
    {
        bool IsEmpty { get; }
        T Value { get; }
        KDTree<T> Left { get; set; }
        KDTree<T> Right { get; set; }
    }

    public class Node<T> : KDTree<T>
    {
        public bool IsEmpty
        {
            get
            {
                return false;
            }
        }

        public KDTree<T> Left
        { get; set; }

        public KDTree<T> Right
        { get; set; }

        public T Value
        { get; set; }

        public Node(KDTree<T> Left, KDTree<T> Right, T Value)
        {
            this.Left = Left;
            this.Right = Right;
            this.Value = Value;
        }
    }

    public class Empty<T> : KDTree<T>
    {
        public bool IsEmpty
        {
            get
            {
                return true;
            }
        }

        public KDTree<T> Left
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public KDTree<T> Right
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public T Value
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
