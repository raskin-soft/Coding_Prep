namespace Random_Test
{
    public class Class1
    {
        // Problem: n = number of lines, m = number of new people
        //          Add new people one by one into the  shortest line
        // n,m >  3 4
        // lines >  3 2 5
        public void solve(int[] lines, int n, int m)
        {
            int i, shortest;
            for (i = 0; i < m; i++)
            {
                shortest = shortest_line_index(lines, n);
                Console.WriteLine(lines[shortest] + "\n");
                lines[shortest]++;
            }
        }
        public int shortest_line_index(int[] lines, int n)
        {
            int j;
            int shortest = 0;
            for (j = 1; j < n; j++)
                if (lines[j] < lines[shortest])
                    shortest = j;
            return shortest;
        }




    }
}