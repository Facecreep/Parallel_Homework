using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Homework_2
{
    class MatrixMultiplier
    {
        private Matrix toReturn;

        public Matrix Multiply_Consecutevely(Matrix matrix1, Matrix matrix2)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int size = matrix1.size;
            toReturn = new Matrix(size, Matrix.RandomizationMode.DO_NOT_RANDOMIZE);

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    for (int c = 0; c < size; c++)
                    {
                        toReturn[x, y] = matrix1[x, c] + matrix2[c,y];
                    }
                }
            }
            stopwatch.Stop();
            Console.WriteLine($"Finished in {stopwatch.ElapsedMilliseconds} milliseconds");
            return toReturn;
        }

        public Matrix MultiplyParallel(Matrix matrix1, Matrix matrix2)
        {
            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();
            DateTime dateTimeStart = DateTime.Now;
            int size = matrix1.size;
            toReturn = new Matrix(size, Matrix.RandomizationMode.DO_NOT_RANDOMIZE);

            Task[] tasks = new Task[size];
            //for (int i = 0; i < size; i++)
            //{
            //    tasks[i] = Task.Factory.StartNew(() => { });
            //}
            //Task.WaitAll(tasks);
            //int row = 0;
            //while (row < size)
            //{
            //    Console.WriteLine($"Row = {row}");
            //    tasks[row] = Task.Factory.StartNew(() => ProcessByRow(row, size, toReturn, matrix1, matrix2));
            //    row++;
            //    Task.WaitAll(tasks);
            //}

            for (int row = 0; row < size; row++)
            {
                //Console.WriteLine($"Row1 = {row}");
                int temp = row; //САМАЯ ВАЖНАЯ СТРОЧКА, ЕСЛИ ПЕРЕДАВАТЬ НАПРЯМУЮ, ТО ХАНА
                tasks[row] = Task.Factory.StartNew(() => ProcessByRow(temp, size, toReturn, matrix1, matrix2));
            }
            //for (int row = 0; row < size; row++)
            //{
            //    //Console.WriteLine($"Row2 = {row}");
            //    tasks[row].Start();
            //}
            //Task.Factory.ContinueWhenAll(tasks, completedTasks =>
            //{
            //    stopwatch.Stop();
            //    Console.WriteLine($"Finished in {stopwatch.ElapsedMilliseconds} milliseconds");
            //});
            Task.WaitAll(tasks);
            TimeSpan timeSpan = DateTime.Now - dateTimeStart;
            Console.WriteLine(timeSpan.TotalMilliseconds);
            return toReturn;
        }

        private void ProcessByRow(int row, int size, Matrix toReturn, Matrix matrix1, Matrix matrix2)
        {
            //Console.WriteLine($"Current Task's ID = {Task.CurrentId - size}");
            //Console.WriteLine($"Row inside task = {row}");
            for (int y = 0; y < size; y++)
            {
                    for (int c = 0; c < size; c++)
                    {
                        //Console.WriteLine($"Toreturn[{row}, {y}]({toReturn[row, y]}) = matrix1[{row}, {c}]({matrix1[row, c]}) + matrix2[{c}, {y}]({matrix2[c, y]})");
                        toReturn[row, y] = matrix1[row, c] + matrix2[c, y];
                    }
            }
        }
    }
}
