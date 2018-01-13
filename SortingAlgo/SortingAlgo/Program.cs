using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SortingAlgo
{
	class Program
	{
		static void Main(string[] args)
		{

			List<int> a = new List<int> { 13, 15, 11, 10, 8, 5, 23 };

			List<string> b = new List<string> { "13", "15", "11", "10", "8", "5", "23" };

			SelectionSort.Sort(a);

			SelectionSort.Sort(b);

			Console.WriteLine("Sorting of numbers");

			foreach (int item in a)
			{
				Console.WriteLine(item);
			}

			Console.WriteLine("Sorting of string");

			foreach (string item in b)
			{
				Console.WriteLine(item);
			}


			Console.WriteLine("Insertion Sort");

			List<int> c = new List<int> { 13, 15, 11, 10, 8, 5, 23 };

			List<string> d = new List<string> { "13", "15", "11", "10", "8", "5", "23" };

			InsertionSort.Sort(c);

			InsertionSort.Sort(d);

			Console.WriteLine("Sorting of numbers");

			foreach (int item in c)
			{
				Console.WriteLine(item);
			}

			Console.WriteLine("Sorting of string");

			foreach (string item in d)
			{
				Console.WriteLine(item);
			}

			Console.WriteLine("Merge Sort");

			List<int> e = new List<int> { 13, 15, 11, 10, 8, 5, 23 };
			List<int> auxe = new List<int> { 13, 15, 11, 10, 8, 5, 23 };


			List<string> f = new List<string> { "13", "15", "11", "10", "8", "5", "23" };
			List<string> auxf = new List<string> { "13", "15", "11", "10", "8", "5", "23" };
			MergeSort.Sort(e, auxe, 0, e.Count - 1);

			MergeSort.Sort(f, auxf, 0, f.Count - 1);

			Console.WriteLine("Sorting of numbers");

			foreach (int item in e)
			{
				Console.WriteLine(item);
			}

			Console.WriteLine("Sorting of string");

			foreach (string item in f)
			{
				Console.WriteLine(item);
			}


			Console.ReadLine();
		}
	}

	public class SelectionSort
	{
		private static Boolean less<T>(T v, T w) where T : IComparable<T>
		{
			return v.CompareTo(w) < 0;
		}

		private static void exch<T>(List<T> a, int i, int j)
		{
			T swap = a[i];
			a[i] = a[j];
			a[j] = swap;
		}

		public static void Sort<T>(List<T> a) where T : IComparable<T>
		{
			int n = a.Count;
			for (int i = 0; i < n; i++)
			{
				int min = i;
				for (int j = i + 1; j < n; j++)
				{

					if (less(a[j], a[min]))
					{
						min = j;
					}
				}
				exch(a, i, min);
			}

		}
	}


	//Insertion Sort
	public class InsertionSort
	{
		private static Boolean less<T>(T v, T w) where T : IComparable<T>
		{
			return v.CompareTo(w) < 0;
		}

		private static void exch<T>(List<T> a, int i, int j)
		{
			T swap = a[i];
			a[i] = a[j];
			a[j] = swap;
		}

		public static void Sort<T>(List<T> a) where T : IComparable<T>
		{
			int n = a.Count;
			for (int i = 0; i < n; i++)
			{
				T temp = a[i];
				int j = i + 1;
				for (j = i; j > 0; j--)
				{

					if (less(a[j], a[j - 1]))
					{
						exch(a, j, j - 1);
					}
				}

			}

		}
	}

	//Merge Sort
	public class MergeSort
	{
		private static Boolean less<T>(T v, T w) where T : IComparable<T>
		{
			return v.CompareTo(w) < 0;
		}

		private static void exch<T>(List<T> a, int i, int j)
		{
			T swap = a[i];
			a[i] = a[j];
			a[j] = swap;
		}

		public static void Sort<T>(List<T> a, List<T> aux, int low, int high) where T : IComparable<T>
		{
			if (high <= low)
			{
				return;
			}
			int mid = low + (high - low) / 2;
			Sort(a, aux, low, mid);
			Sort(a, aux, mid + 1, high);
			Merge(a, aux, low, mid, high);
		}


		public static void Merge<T>(List<T> a, List<T> aux, int low, int mid, int high) where T : IComparable<T>
		{
			for (int k = low; k <= high; k++)
			{
				aux[k] = a[k];
			}
			int i = low, j = mid + 1;

			for (int k = low; k <= high; k++)
			{
				if (i > mid) a[k] = aux[j++];
				else if (j > high) a[k] = aux[i++];
				else if (less(aux[j], aux[i])) a[k] = aux[j++];
				else a[k] = aux[i++];
			}

		}
	}
}
