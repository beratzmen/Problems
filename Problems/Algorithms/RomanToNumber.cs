namespace Problems.Algorithms;

public static class RomanToNumber
{
    public static void ConvertRomanToInteger()
    {
        var romanNumberDict =
            new Dictionary<string, int>
            {
                { "I", 1 },
                { "V", 5 },
                { "X", 10 },
                { "L", 50 },
                { "C", 100 },
                { "D", 500 },
                { "M", 1000 },
            };

        while (true)
        {
            var sum = 0;
            int numberSecond = 0;

            Console.Write("Romen rakamları ile bir sayı giriniz: ");

            string value = Console.ReadLine().ToUpperInvariant();

            if (string.IsNullOrEmpty(value))
            {
                throw new Exception("Boş değer girilemez");
            }

            for (var i = 0; i < value.Length; i++)
            {
                if (!romanNumberDict.ContainsKey(value[i].ToString()))
                {
                    Console.WriteLine($"Hatalı değer = {value[i]}");

                    throw new Exception("Hatalı giriş yapıldı");
                }
            }

            for (var i = 0; i < value.Length; i++)
            {
                romanNumberDict.TryGetValue(value[i].ToString(), out var number);

                if (i != value.Length - 1)
                {
                    romanNumberDict.TryGetValue(value[i + 1].ToString(), out numberSecond);
                }

                if (number < numberSecond)
                {
                    if (value.Length - 1 != i)
                    {
                        sum += numberSecond - number;
                    }
                    else
                    {
                        sum += number;
                    }

                    i += 1;
                }
                else
                {
                    sum += number;
                }
            }

            Console.WriteLine($"{value} = {sum}");
        }
    }
}
