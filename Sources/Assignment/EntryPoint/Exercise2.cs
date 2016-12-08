using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntryPoint.Exercise2Folder;

namespace EntryPoint
{
    public class Exercise2
    {
        public KDTree<Vector2> Tree = new Empty<Vector2>() as KDTree<Vector2>;
        public List<List<Vector2>> SelectedSpecialBuildings = new List<List<Vector2>>();
        public List<Tuple<Vector2, float>>  HousesAndDistances = new List<Tuple<Vector2, float>>();
        public Vector2[] SpecialBuildings = new Vector2[50];
        public List<Vector2> Test = new List<Vector2>();
        public int Counter = 0;

        public KDTree<Vector2> Insert(Vector2 Vector, KDTree<Vector2> Tree, int Depth)
        {
            if (Tree.IsEmpty)
            {
                return new Node<Vector2>(new Empty<Vector2>(), new Empty<Vector2>(), Vector);
            }

            if ((Depth % 2) == 0)
            {

                if (Vector.X <= Tree.Value.X)
                {
                    return new Node<Vector2>(Insert(Vector, Tree.Left, Depth + 1), Tree.Right, Tree.Value);

                }
                else
                {
                    return new Node<Vector2>(Tree.Left, Insert(Vector, Tree.Right, Depth + 1), Tree.Value);
                }
            }
            else
            {
                if (Vector.Y <= Tree.Value.Y)
                {
                    return new Node<Vector2>(Insert(Vector, Tree.Left, Depth + 1), Tree.Right, Tree.Value);

                }
                else
                {
                    return new Node<Vector2>(Tree.Left, Insert(Vector, Tree.Right, Depth + 1), Tree.Value);
                }
            }
        }

        public void KDBuilder(Vector2[] SpecialBuildings, int LeftIndex, int RightIndex, int Depth)
        {
            if (LeftIndex < RightIndex)
            {
                int MiddleIndex = (LeftIndex + RightIndex) / 2;
                this.Tree = Insert(SpecialBuildings[MiddleIndex], this.Tree, Depth);
                KDBuilder(SpecialBuildings, LeftIndex, MiddleIndex, Depth + 1);
                KDBuilder(SpecialBuildings, MiddleIndex + 1, RightIndex, Depth + 1);
            }
        }

        public void TraversePreOrder(KDTree<Vector2> Tree)
        {
            if (Tree.IsEmpty)
                return;
            Counter++;
            TraversePreOrder(Tree.Left);
            TraversePreOrder(Tree.Right);
        }

        public void TraverseInOrder(KDTree<Vector2> Tree)
        {
            if (Tree.IsEmpty)
                return;
            TraversePreOrder(Tree.Left);
            Console.WriteLine(Tree.Value);
            TraversePreOrder(Tree.Right);
        }

        public void TraversePostOrder(KDTree<Vector2> Tree)
        {
            if (Tree.IsEmpty)
                return;
            TraversePreOrder(Tree.Left);
            TraversePreOrder(Tree.Right);
            Console.WriteLine(Tree.Value);
        }

        private float Distance(Vector2 specialbuilding, Vector2 House)
        {
            var distanceX = Math.Pow((House.X - specialbuilding.X), 2);
            var distanceY = Math.Pow((House.Y - specialbuilding.Y), 2);
            var result = Math.Sqrt((distanceX + distanceY));
            return (float)result;
        }

        public void TraverseSelected(KDTree<Vector2> Tree)
        {
            if (Tree.IsEmpty)
                return;
            foreach (var item in HousesAndDistances)
            {
                float distance = Distance(Tree.Value, item.Item1);
                if (distance <= item.Item2)
                {
                    Test.Add(Tree.Value);
                }
            }
            TraverseSelected(Tree.Left);
            TraverseSelected(Tree.Right);
        }

        public Exercise2(Vector2[] SpecialBuildings, List<Tuple<Vector2, float>> HousesAndDistances)
        {
            this.SpecialBuildings = SpecialBuildings;
            this.HousesAndDistances = HousesAndDistances;
        }
    }
}