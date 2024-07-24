
String line;
line = Console.ReadLine();
int N = Convert.ToInt32(line);
int[][] ratings = new int[N][];
for (int i_ratings = 0; i_ratings < N; i_ratings++)
{
    line = Console.ReadLine();
    ratings[i_ratings] = line.Split().Select(str => int.Parse(str)).ToArray();
}

int out_ = solution(N, ratings);
Console.Out.WriteLine(out_);

static int solution(int N, int[][] ratings)
{
    // You must complete the logic for the function that is provided
    // before compiling or submitting to avoid an error.
    // Write your code here

    var dishRatings = new Dictionary<int, (int sum, int count)>();

    //Summing up ratings and counting the number of ratings for each dish.
    foreach (var rating in ratings)
    {
        int dishID = rating[0];
        int dishRating = rating[1];

        if (!dishRatings.ContainsKey(dishID))
        {
            dishRatings[dishID] = (0, 0);
        }

        dishRatings[dishID] = (dishRatings[dishID].sum + dishRating, dishRatings[dishID].count + 1);
    }

    int bestDishID = -1;
    double highestAverage = -1.0;

    //Calculate the average and finding the dish with the highest average rating
    foreach (var kvp in dishRatings)
    {
        int dishID = kvp.Key;
        var (sum, count) = kvp.Value;
        double average = (double)sum / count;

        if (average > highestAverage || (average == highestAverage && dishID < bestDishID))
        {
            highestAverage = average;
            bestDishID = dishID;
        }
    }

    return bestDishID;
}