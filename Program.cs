namespace ForLoop
{
    internal class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Vali kujund: [1] Ruut, [2] Ristkülik, [3] Teemant, [4] Ring");
                var choice = Console.ReadLine()?.Trim();

                switch (choice)
                {
                    case "1":
                        HandleSquare();
                        break;
                    case "2":
                        HandleRectangle();
                        break;
                    case "3":
                        HandleDiamond();
                        break;
                    case "4":
                        HandleCircle();
                        break;
                    default:
                        Console.WriteLine("Tundmatu valik.");
                        break;
                }

                Console.WriteLine("\nTahad proovida veel? (jah/ei)");
                var again = Console.ReadLine()?.Trim().ToLower();
                if (again != "jah") break;
            }
        }

        static void HandleSquare()
        {
            Console.WriteLine("Sisesta ruudu külje pikkus:");
            if (!int.TryParse(Console.ReadLine(), out int side) || side <= 0)
            {
                Console.WriteLine("Vigane sisestus.");
                return;
            }

            DrawFilledRectangle(side, side);

            double area = side * side;
            double perimeter = side * 4;

            AskUserAnswer("ruudu", area, perimeter);
        }

        static void HandleRectangle()
        {
            Console.WriteLine("Sisesta ristküliku esimene külg:");
            if (!int.TryParse(Console.ReadLine(), out int a) || a <= 0)
            {
                Console.WriteLine("Vigane sisestus.");
                return;
            }

            Console.WriteLine("Sisesta teine külg:");
            if (!int.TryParse(Console.ReadLine(), out int b) || b <= 0)
            {
                Console.WriteLine("Vigane sisestus.");
                return;
            }

            DrawFilledRectangle(a, b);

            double area = a * b;
            double perimeter = 2 * (a + b);

            AskUserAnswer("ristküliku", area, perimeter);
        }

        static void HandleDiamond()
        {
            Console.WriteLine("Sisesta teemanti diagonaali poolpikkus:");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Vigane sisestus.");
                return;
            }

            DrawDiamond(n);

            double area = n * n;
            double perimeter = 4 * n;

            AskUserAnswer("teemanti", area, perimeter);
        }

        static void HandleCircle()
        {
            Console.WriteLine("Sisesta ringi raadius:");
            if (!double.TryParse(Console.ReadLine(), out double r) || r <= 0)
            {
                Console.WriteLine("Vigane sisestus.");
                return;
            }

            DrawCircle(r);

            double area = Math.PI * r * r;
            double perimeter = 2 * Math.PI * r;

            AskUserAnswer("ringi", area, perimeter);
        }

        static void AskUserAnswer(string shapeName, double area, double perimeter)
        {
            Console.WriteLine($"\n{shapeName} pindala ja ümbermõõt?");
            Console.Write("Pindala: ");
            double.TryParse(Console.ReadLine(), out double userArea);

            Console.Write("Ümbermõõt: ");
            double.TryParse(Console.ReadLine(), out double userPerimeter);

            Console.WriteLine($"Õige pindala: {(Math.Abs(userArea - area) < 0.01 ? "Õige" : area.ToString("F2"))}");
            Console.WriteLine($"Õige ümbermõõt: {(Math.Abs(userPerimeter - perimeter) < 0.01 ? "Õige" : perimeter.ToString("F2"))}");
        }

        static void DrawFilledRectangle(int height, int width)
        {
            Console.WriteLine();
            for (int i = 0; i < height; i++)
            {
                Console.WriteLine(new string('*', width));
            }
        }

        static void DrawDiamond(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(new string(' ', n - i));
                Console.WriteLine(new string('*', 2 * i + 1));
            }
            for (int i = n - 2; i >= 0; i--)
            {
                Console.Write(new string(' ', n - i));
                Console.WriteLine(new string('*', 2 * i + 1));
            }
        }

        static void DrawCircle(double radius)
        {
            double thickness = 0.4;
            double rIn = radius - thickness, rOut = radius + thickness;

            for (double y = radius; y >= -radius; --y)
            {
                for (double x = -radius; x <= radius; x += 0.5)
                {
                    double val = x * x + y * y;
                    Console.Write(val >= rIn * rIn && val <= rOut * rOut ? "*" : " ");
                }
                Console.WriteLine();
            }
        }
    }
}







