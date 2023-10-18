namespace rovnice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x1, x2;

            Console.WriteLine("Kvadratická rovnice");
            Console.Write("Zadej a: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Zadej b: ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("Zadej c: ");
            int c = int.Parse(Console.ReadLine());

            int d = b * b - 4 * a * c;
            if (d > 0)
            {
                x1 = (-b + (int)Math.Sqrt(d)) / (2 * a);
                x2 = (-b - (int)Math.Sqrt(d)) / (2 * a);
                Console.WriteLine("má dvě řešení: x1 = {0} a x2 = {1}",x1,x2);
            }
            else if (d == 0)
            {
                x1 = -b / (2 * a);
                Console.WriteLine("má jedno řešení: x1 = {0}",x1);
            }
            else // d < 0
            {
                Console.WriteLine("nemá řešení v oboru R");
            }

            Console.ReadLine();
        }
    }
}