namespace MandatoryLiterature
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPages = int.Parse(Console.ReadLine());
            int pagesReadInOneHour = int.Parse(Console.ReadLine());
            int daysNeededToReadTheBook = int.Parse(Console.ReadLine());

            int requiredHoursPerDay = (numberOfPages / pagesReadInOneHour) / daysNeededToReadTheBook;

            Console.WriteLine(requiredHoursPerDay);

        }
    }
}