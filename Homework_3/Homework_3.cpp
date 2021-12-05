// Homework_3.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <chrono>

template <
    class result_t = std::chrono::milliseconds,
    class clock_t = std::chrono::steady_clock,
    class duration_t = std::chrono::milliseconds
>
auto since(std::chrono::time_point<clock_t, duration_t> const& start)
{
    return std::chrono::duration_cast<result_t>(clock_t::now() - start);
}

void OutputMatrix(int** array, int size) {
    for (size_t y = 0; y < size; y++)
    {
        for (size_t x = 0; x < size; x++)
        {
            std::cout << array[x][y] << " ";
        }
        std::cout << "\n";
    }
}

int main()
{
    int size;
    std::cin >> size;

    int **matrix1 = new int* [size];
    int **matrix2 = new int* [size];
    for (size_t y = 0; y < size; y++)
    {
        matrix1[y] = new int[size];
        matrix2[y] = new int[size];
        for (size_t x = 0; x < size; x++)
        {
            matrix1[y][x] = std::rand()%100 + 1;
            matrix2[y][x] = std::rand()%100 + 1;
        }
    }

    //auto start = std::chrono::steady_clock::now();
    //int** resultingMatrix = new int* [size];
    //for (size_t y = 0; y < size; y++)
    //{
    //    resultingMatrix[y] = new int[size];
    //    for (size_t x = 0; x < size; x++)
    //    {
    //        for (size_t c = 0; c < size; c++)
    //        {
    //            resultingMatrix[y][x] = matrix1[c][x] + matrix2[y][x];
    //        }
    //    }
    //}
    //std::cout << "Elapsed(ms)=" << since(start).count() << std::endl;

    auto start = std::chrono::steady_clock::now();
    int** resultingMatrix = new int* [size];

    #pragma omp parallel for shared(resultingMatrix, matrix1, matrix2)
    for (int y = 0; y < size; y++)
    {
        resultingMatrix[y] = new int[size];
        for (int x = 0; x < size; x++)
        {
            for (int c = 0; c < size; c++)
            {
                resultingMatrix[y][x] = matrix1[c][x] + matrix2[y][x];
            }
        }
    }
    std::cout << "Elapsed(ms)(parallel)=" << since(start).count() << std::endl;

    //OutputMatrix(resultingMatrix, size);
}
// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
