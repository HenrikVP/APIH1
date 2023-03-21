namespace APIH1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            new WeatherAPI().GetWeather();
        }
    }
}