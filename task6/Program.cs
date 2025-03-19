using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace SortingVerificationSystem
{
    class Program
    {
        static void Main()
        {
            //CreateTest();
            var testFiles = Directory.GetFiles("TestArrays", "*.txt");
            int score = 0;
            foreach (var file in testFiles)
            {
                int tempScore = 0;
                Console.WriteLine("---------------------");
                double[] array = LoadArrayFromFile(file);
                //Console.WriteLine(string.Join(" ", array));
                Console.WriteLine(Path.GetFileName(file));
                Console.WriteLine("Shaker sort\t");
                TestSortRes(array, ShakerSort, StudentShakerSort, out tempScore); ;
                score += tempScore;
                Console.WriteLine("Selection sort\t");
                TestSortRes(array, SelectionSort, StudentSelectionSort, out tempScore);
                score += tempScore;
                Console.WriteLine("---------------------");
            }

            Console.WriteLine($"Score: {score}");
        }
        static void CreateTest()
        {
            if (!Directory.Exists("TestArrays"))  
                Directory.CreateDirectory("TestArrays");
            CreateArrFile("TestArrays/rand.txt", () => CreateRandomArray(20000));
            CreateArrFile("TestArrays/rand2.txt", () => CreateRandomArray(20000));
            CreateArrFile("TestArrays/reversed.txt", () => CreateReversedArray(20000));
            CreateArrFile("TestArrays/reversed2.txt", () => CreateReversedArray(20000));
            CreateArrFile("TestArrays/sorted.txt", () => CreateSortedArray(20000));
            CreateArrFile("TestArrays/sorted2.txt", () => CreateSortedArray(20000));
            CreateArrFile("TestArrays/sorted2.txt", () => CreateNearlySortedArray(20000));
        }
        static void CreateArrFile(string filePath, Func<double[]> generator)
        {
            double[] array = generator.Invoke();
            File.WriteAllText(filePath, string.Join(" ", array));
        }
        static double[] CreateRandomArray(int length)
        {
            Random random = new Random();
            double[] array = new double[length];
            for(int i = 0; i < length; i++)
            {
                array[i] = random.Next(-10000, 10000);
            }
            return array;
        }
        static double[] CreateReversedArray(int length)
        {
            Random random = new Random();
            double[] array = CreateSortedArray(length);
            array.Reverse();
            return array;
        }

        static double[] CreateSortedArray(int length)
        {
            Random random = new Random();
            double[] array = new double[length];
            array[0] = random.Next(int.MinValue / 2, int.MaxValue / 2);
            int delta = ((int)array[0] + int.MaxValue) / length;
            for (int i = 1; i < length; i++)
            {
                array[i] = array[i - 1] - delta;
            }
            return array;
        }


        static double[] CreateNearlySortedArray(int length)
        {
            Random random = new Random();
            double[] array = CreateSortedArray(length);
            for(int i = 0; i < length / 10; i++)
            {
                int index1 = random.Next(0, length - 1);
                int index2 = random.Next(0, length - 1);
                (array[index1], array[index2]) = (array[index2],  array[index1]);
            }
            return array;
        }

        static double[] LoadArrayFromFile(string filePath)
        {
            return Array.ConvertAll(File.ReadAllText(filePath).Split().ToArray(), double.Parse);
            
        }

        static void TestSortRes(double[] arr, Action<double[]> ReferenceSort, Action<double[]> StudentSort, out int score)
        {

            double[] refSortArr = (double[])arr.Clone();
            double[] studSortArr = (double[])arr.Clone();
            int timeRefSort = 0;
            int timeStudSort = 0;
            //student sort
            try
            {                
                timeStudSort = MeasureSortTime(StudentSort, studSortArr, out bool canceled);
                if (canceled)
                    throw new TimeoutException();
            
            }
            catch (TimeoutException)
            {
                Console.WriteLine("Timeout");
                score = 5;
            }
            catch {
                score = 0;
                Console.WriteLine("Runtime error");
                
            }

            //server
            try
            {
                timeRefSort = MeasureSortTime(ReferenceSort, refSortArr, out bool canceled);
                if (canceled)
                    throw new TimeoutException();
            }
            catch (TimeoutException)
            {
                Console.WriteLine("Timeout (server problem)");
                score = 5;
            }
            catch {
                score = 0;
                Console.WriteLine( "Runtime error (server problem)");
            }
            if (CompareTimes(timeRefSort, timeStudSort) && CompareArr(refSortArr, studSortArr))
            {
                score = 10;
                Console.WriteLine("Passed");
            }
            else
            {
                score = 0;
                Console.WriteLine("Failed");
            }
        }
        static bool CompareArr(double[] arr1, double[] arr2)
        {
            if(arr1.Length != arr2.Length) return false;
            for (int i = 0; i < arr1.Length; i++)
            {
                if(arr1[i] != arr2[i]) return false;
            }
            return true;
        }
        static int MeasureSortTime(Action<double[]> sort, double[] arr, out bool canceled)
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource(5000);
            CancellationToken token = cancelTokenSource.Token;
            var task = Task.Run(() => sort.Invoke(arr), token);
            Stopwatch stopwatch = Stopwatch.StartNew();
            try
            {
                task.Wait(token);
                canceled = false;
            }
            catch (OperationCanceledException)
            {
                canceled = true;
            }
            //sort.Invoke(arr);
            stopwatch.Stop();
            return stopwatch.Elapsed.Milliseconds;
        }

        static bool CompareTimes(int teta, int tstud)
        {
            return Math.Max(0, teta / 5) <= tstud && tstud <= 5 * teta;
        }
        static void SelectionSort(double[] array)
        {
            
            for (int i = 0; i < array.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minIndex])
                        minIndex = j;
                }
                (array[i], array[minIndex]) = (array[minIndex], array[i]);
            }
        }

        static void ShakerSort(double[] array)
        {
            bool swapped = true;
            int start = 0;
            int end = array.Length;

            while (swapped == true)
            {
                swapped = false;

                for (int i = start; i < end - 1; ++i)
                {
                    if (array[i] > array[i + 1])
                    {
                        (array[i], array[i + 1]) = (array[i + 1], array[i]);
                        swapped = true;
                        
                    }
                }

                if (swapped == false)
                    break;

                swapped = false;
                end = end - 1;
                for (int i = end - 1; i >= start; i--)
                {
                    if (array[i] > array[i + 1])
                    {
                        (array[i], array[i + 1]) = (array[i+1], array[i]);
                        swapped = true;
                    }
                }

                start = start + 1;
            }
        }

        static void StudentSelectionSort(double[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minIndex])
                        minIndex = j;
                }
                (array[i], array[minIndex]) = (array[minIndex], array[i]);

            }
        }

        static void StudentShakerSort(double[] array)
        {
            //bool swapped;
            //do
            //{
            //    swapped = false;
            //    for (int i = 0; i < array.Length - 1; i++)
            //    {
            //        if (array[i] > array[i + 1])
            //        {
            //            (array[i], array[i + 1]) = (array[i + 1], array[i]);
            //            swapped = true;
            //        }
            //    }
            //} while (swapped);
            //Array.Sort(array);

            //Array.Sort(array);
            bool swapped = true;
            int start = 0;
            int end = array.Length;

            while (swapped == true)
            {
                swapped = false;

                for (int i = start; i < end - 1; ++i)
                {
                    if (array[i] > array[i + 1])
                    {
                        (array[i], array[i + 1]) = (array[i + 1], array[i]);
                        swapped = true;

                    }
                }

                if (swapped == false)
                    break;

                swapped = false;
                end = end - 1;
                for (int i = end - 1; i >= start; i--)
                {
                    if (array[i] > array[i + 1])
                    {
                        (array[i], array[i + 1]) = (array[i + 1], array[i]);
                        swapped = true;
                    }
                }

                start = start + 1;

            }

            }
    }
}
