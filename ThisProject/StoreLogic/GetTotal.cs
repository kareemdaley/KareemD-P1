using System;
namespace ThisProject.StoreLogic
{
    public class GetTotal
	{
        int[] purchasing;
		public GetTotal(int[] x)
		{
            purchasing = x;
		}

        public static int Total(int[] purchasing)
        {
            int cost = 0;
            cost += purchasing[0] * 5 + purchasing[1] * 10 + purchasing[2] * 15;
            Console.WriteLine($"Your total is: ${cost}");
            return cost;
        }
    }
}

