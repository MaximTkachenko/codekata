namespace SortingAlgorithms
{
    public class BubbleSorting : ISorting
    {
        public void Sort(int[] input)
        {
            bool isSorted = false;
            var lastUnsorted = input.Length - 1;
            while (!isSorted)
            {
                isSorted = true;
                for (var i = 0; i < lastUnsorted; i++)
                {
                    if (input[i] <= input[i + 1])
                    {
                        continue;
                    }

                    isSorted = false;
                    var temp = input[i];
                    input[i] = input[i + 1];
                    input[i + 1] = temp;
                }

                lastUnsorted--;
            }
        }
    }
}
