using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_2
{
    class Matrix
    {
        public int size { get; }
        public int[,] array { get; set; }

        public enum RandomizationMode
        {
            RANDOMIZE,
            DO_NOT_RANDOMIZE
        }

        public Matrix(int size, RandomizationMode randomization)
        {
            this.size = size;

            array = new int[size, size];
            Random random = new Random();
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    if(randomization == RandomizationMode.RANDOMIZE)
                        array[x, y] = random.Next(1000);
                    else
                        array[x, y] = -1;
                }
            }
        }

        public int this[int x, int y]
        {
            get
            {
                try
                {
                    return array[x, y];
                }
                catch (Exception)
                {
                    Console.WriteLine($"Exception occured, x={x}, y={y}");
                    throw;
            }   }
            set { array[x,y] = value; }
        }

        public override string ToString()
        {
            string toReturn = "";

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    toReturn += array[j, i] + " ";
                }
                toReturn += "\n";
            }

            return toReturn;
        }
    }
}
