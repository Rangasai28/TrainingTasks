namespace SortingTechniquies
{
    internal class Program
    {
        public void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n-1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }
        public void SelectionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }
                int temp = arr[minIndex];
                arr[minIndex] = arr[i];
                arr[i] = temp;
            }
        }
        public void PrintArray(int[] arr)
        {
            for(int i = 0;i < arr.Length;i++)
            {
                Console.Write(arr[i]+" ");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Program pro = new Program();
            int[] arr = new int[] { 44, 2, 55, 1, 5, 100, 23, 43, 12, 54 };
            pro.BubbleSort(arr);
            pro.PrintArray(arr);
            pro.SelectionSort(arr);
            pro.PrintArray(arr);
        }
    }
}
