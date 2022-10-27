using System;

public class Program
{
    public class MoneyType
    {
        public decimal Value { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Count { get; set; }
    }

    public static void Main()
    {
        Console.WriteLine("Please enter the amount of money you would like to exchange: ");
        decimal value_received = Convert.ToDecimal(Console.ReadLine());
        decimal value_temp = value_received;

        List<MoneyType> list = new List<MoneyType>()
        {
            new MoneyType() { Value = 20, Name = "Twenty Dollar", Type = "Bill" },
            new MoneyType() { Value = 10, Name = "Ten Dollar", Type = "Bill" },
            new MoneyType() { Value = 5, Name = "Five Dollar", Type = "Bill" },
            new MoneyType() { Value = 1, Name = "One Dollar", Type = "Bill" },
            new MoneyType() { Value = 0.50m, Name = "Fifty Cent", Type = "Coin" },
            new MoneyType() { Value = 0.25m, Name = "Twenty-five Cent", Type = "Coin" },
            new MoneyType() { Value = 0.10m, Name = "Ten Cent", Type = "Coin" },
            new MoneyType() { Value = 0.05m, Name = "Five Cent", Type = "Coin" },
            new MoneyType() { Value = 0.01m, Name = "One Cent", Type = "Coin" }
        };

        Console.WriteLine(list.Where(x => x.Name == "Twenty Dollar").Select(x => x.Count).ToString);

        foreach(var i in list)
        {
            if(value_temp >= i.Value)
            {
                // Math.Floor does not round up, which is what's needed
                int division_result = Convert.ToInt32(Math.Floor(value_temp / i.Value));
                i.Count += division_result;
                value_temp %= i.Value;
            }
        }

        string change_summary = String.Join(", ", list.Where(x=> x.Count != 0).Select(x=> $"x{x.Count} {x.Name} {x.Type}"));
        Console.WriteLine($"The number of bills and coins for the sum of {value_received} is {change_summary}.");
    }
}






