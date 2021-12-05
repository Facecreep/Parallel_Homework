using Homework_2;
using System;


namespace Parallel_Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, specify matrix size");
            int size = Convert.ToInt32(Console.ReadLine());

            Matrix matrix1 = new Matrix(size , Matrix.RandomizationMode.RANDOMIZE);
            Matrix matrix2 = new Matrix(size, Matrix.RandomizationMode.RANDOMIZE);

            MatrixMultiplier matrixMultiplier = new MatrixMultiplier();
            //Matrix matrix = matrixMultiplier.Multiply_Consecutevely(matrix1, matrix2);
            Matrix matrix = matrixMultiplier.MultiplyParallel(matrix1, matrix2);

            Console.WriteLine(matrix);
        }
    }
}
