namespace CardsGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayerDeck = Console.ReadLine().Split(" ").Select(n => int.Parse(n)).ToList();
            List<int> secondPlayerDeck = Console.ReadLine().Split(" ").Select(n => int.Parse(n)).ToList();

            while(firstPlayerDeck.Count > 0 && secondPlayerDeck.Count > 0)
            {
                int firstPlayerCard = firstPlayerDeck[0];
                int secondPlayerCard = secondPlayerDeck[0];

                if (firstPlayerCard == secondPlayerCard)
                {
                    firstPlayerDeck.Remove(firstPlayerCard);
                    secondPlayerDeck.Remove(secondPlayerCard);
                }

                else if(firstPlayerCard > secondPlayerCard)
                {
                   firstPlayerDeck.Add(firstPlayerCard);
                   firstPlayerDeck.RemoveAt(0);
                    firstPlayerDeck.Add(secondPlayerCard);
                    secondPlayerDeck.RemoveAt(0);
                }
                else
                {
                    secondPlayerDeck.Add(secondPlayerCard);
                    secondPlayerDeck.RemoveAt(0);
                    secondPlayerDeck.Add(firstPlayerCard);
                    firstPlayerDeck.RemoveAt(0);
                }
            }

            if(firstPlayerDeck.Count > 0)
            {
                int sum = firstPlayerDeck.Sum();
                Console.WriteLine($"First player wins! Sum: {sum}");
            } 
            else
            {
                int sum = secondPlayerDeck.Sum();
                Console.WriteLine($"Second player wins! Sum: {sum}");
            } 
        }
    }
}
