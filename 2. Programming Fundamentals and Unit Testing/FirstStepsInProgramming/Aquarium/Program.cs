namespace Aquarium
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double occupiedSpacePercentage = double.Parse(Console.ReadLine()) * 0.01;

            int volume = length * width * height;
            double volumeInLiters = volume * 0.001;
            double requiredLitters = volumeInLiters * (1 - occupiedSpacePercentage);

            Console.WriteLine($"{requiredLitters:F2}");
        }
    }
}