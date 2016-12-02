using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoint
{
    public class Exercise1
    {
        public Vector2 House { get; set; }
        public Vector2[] Buildings { get; set; }

        private float Distance(Vector2 specialbuilding)
        {
            var distanceX = Math.Pow((House.X - specialbuilding.X), 2);
            var distanceY = Math.Pow((House.Y - specialbuilding.Y), 2);
            var result = Math.Sqrt((distanceX + distanceY));
            return (float)result;
        }

        public void MergeSort(Vector2[] UnsortedBuildings, int leftIndex, int rightIndex)
        {
            if (leftIndex < rightIndex)
            {
                int middleIndex = (leftIndex + rightIndex) / 2;
                MergeSort(UnsortedBuildings, leftIndex, middleIndex);
                MergeSort(UnsortedBuildings, middleIndex + 1, rightIndex);
                Merge(UnsortedBuildings, leftIndex, middleIndex, rightIndex);
                
            }
        }

        private void Merge(Vector2[] unsortedArray, int leftIndex, int middleIndex, int rightIndex)
        {
            int lengthLeft = middleIndex - leftIndex + 1;
            int lengthRight = rightIndex - middleIndex;
            Vector2[] leftArray = new Vector2[lengthLeft + 1];
            Vector2[] rightArray = new Vector2[lengthRight + 1];
            for (int i = 0; i < lengthLeft; i++)
            {
                leftArray[i] = unsortedArray[leftIndex + i];
            }
            for (int j = 0; j < lengthRight; j++)
            {
                rightArray[j] = unsortedArray[middleIndex + j + 1];
            }
            int iIndex = 0;
            int jIndex = 0;
            for (int k = leftIndex; k <= rightIndex; k++)
            {
                if (Distance(leftArray[iIndex]) <= Distance(rightArray[jIndex]))
                {
                    unsortedArray[k] = leftArray[iIndex];
                    iIndex++;
                }
                else
                {
                    unsortedArray[k] = rightArray[jIndex];
                    jIndex++;
                }
            }
        }
    }
}
