namespace AdventOfCode2024;

public class DayOne
{
    public int CalculateTotalDistance(List<int> listA, List<int> listB)
    {
        if (listA.Count != listB.Count)
        {
            throw new ArgumentException("Lists must be the same size!");
        }

        listA = listA.OrderBy(x => x ).ToList();
        listB = listB.OrderBy(x => x).ToList();

        var distances = new List<int>();


        for (int i = 0; i < listA.Count; i++)
        {
            var a = listA[i];
            var b = listB[i];

            var distance = Math.Abs(a - b);
            distances.Add(distance);
        }

        return distances.Sum(x => x);
    }
}