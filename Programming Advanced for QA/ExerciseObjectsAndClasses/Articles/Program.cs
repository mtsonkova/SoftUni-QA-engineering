namespace Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(',').ToArray();
            Article article = new Article(input[0], input[1], input[2]);

           int num = int.Parse(Console.ReadLine());

            Article changedArticle = article.changeArticle(article, num);
           
            Console.WriteLine(changedArticle.ToString());
        }

        
    }
}