using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\n========== MAIN MENU ==========");
            Console.WriteLine("1. Find Local Min/Max of a Cubic Function");
            Console.WriteLine("2. Stock Analysis");
            Console.WriteLine("3. Exit");
            Console.WriteLine("================================");
            Console.Write("Enter your choice (1-3): ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    FindCubicMinMax();
                    break;
                case "2":
                    StockAnalysis();
                    break;
                case "3":
                    Console.WriteLine("Exiting the program. Goodbye!");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                    break;
            }
        }
    }

    // ─────────────────────────────────────────────────────────────
    // PART 1 – Local Min/Max of a Cubic Function
    // f(x)  = ax³ + bx² + cx + d
    // f'(x) = 3ax² + 2bx + c   → set to 0 and solve with quadratic formula
    // ─────────────────────────────────────────────────────────────
    static void FindCubicMinMax()
    {
        Console.WriteLine("\n--- Cubic Function Local Min/Max Finder ---");
        Console.WriteLine("Function form: f(x) = ax³ + bx² + cx + d");

        double a = ReadDouble("Enter coefficient a (must not be 0): ", allowZero: false);
        double b = ReadDouble("Enter coefficient b: ");
        double c = ReadDouble("Enter coefficient c: ");
        double d = ReadDouble("Enter coefficient d: ");

        // f'(x) = 3ax² + 2bx + c  →  discriminant = (2b)² - 4*(3a)*c
        double A = 3 * a;
        double B = 2 * b;
        double C = c;

        double discriminant = B * B - 4 * A * C;

        if (discriminant < 0)
        {
            Console.WriteLine("\nNo real critical points found – the function has no local minimum or maximum.");
            return;
        }

        if (discriminant == 0)
        {
            double x = -B / (2 * A);
            double y = CubicValue(a, b, c, d, x);
            Console.WriteLine($"\nOnly one critical point exists at x = {x:F2}, f(x) = {y:F2}.");
            Console.WriteLine("This is an inflection point – no local minimum or maximum.");
            return;
        }

        double sqrtD  = Math.Sqrt(discriminant);
        double x1     = (-B + sqrtD) / (2 * A);
        double x2     = (-B - sqrtD) / (2 * A);

        double y1     = CubicValue(a, b, c, d, x1);
        double y2     = CubicValue(a, b, c, d, x2);

        // Second derivative  f''(x) = 6ax + 2b
        double f2_x1  = 6 * a * x1 + 2 * b;
        double f2_x2  = 6 * a * x2 + 2 * b;

        string label1 = f2_x1 > 0 ? "Local Minimum" : "Local Maximum";
        string label2 = f2_x2 > 0 ? "Local Minimum" : "Local Maximum";

        Console.WriteLine($"\nCritical point 1 → {label1}: x = {x1:F2}, f(x) = {y1:F2}");
        Console.WriteLine($"Critical point 2 → {label2}: x = {x2:F2}, f(x) = {y2:F2}");
    }

    static double CubicValue(double a, double b, double c, double d, double x)
        => a * x * x * x + b * x * x + c * x + d;

    // ─────────────────────────────────────────────────────────────
    // PART 2 – Stock Analysis
    // ─────────────────────────────────────────────────────────────
    static void StockAnalysis()
    {
        Console.WriteLine("\n--- Stock Analysis ---");

        string csvPath = @"C:\Users\Default.DESKTOP-NO16H53\Downloads\stocks.csv";

        if (!File.Exists(csvPath))
        {
            Console.WriteLine($"Error: CSV file not found at:\n  {csvPath}");
            Console.WriteLine("Please make sure 'stocks.csv' exists at that location.");
            return;
        }

        List<StockRecord> records = LoadStockData(csvPath);

        if (records == null || records.Count == 0)
        {
            Console.WriteLine("Error: No valid stock records could be read from the file.");
            return;
        }

        // ── Overall statistics ──────────────────────────────────
        StockRecord first = records.First();
        StockRecord last  = records.Last();

        double lowestPrice  = records.Min(r => r.Low);
        double highestPrice = records.Max(r => r.High);

        StockRecord maxVolDay = records.OrderByDescending(r => r.Volume).First();

        // Closing price change % vs previous day for the highest-volume day
        int maxVolIdx = records.IndexOf(maxVolDay);
        double changePercent = 0;
        string changeStr;

        if (maxVolIdx > 0)
        {
            double prevClose = records[maxVolIdx - 1].Close;
            changePercent    = (maxVolDay.Close - prevClose) / prevClose * 100.0;
            changeStr        = $"{changePercent:+0.00;-0.00}%";
        }
        else
        {
            changeStr = "N/A (no previous trading day in dataset)";
        }

        Console.WriteLine("\n========== OVERALL STATISTICS ==========");
        Console.WriteLine($"Opening price (first trading day  {first.Date:dd/MM/yyyy}): {first.Open:F2}");
        Console.WriteLine($"Closing price (last  trading day  {last.Date:dd/MM/yyyy}):  {last.Close:F2}");
        Console.WriteLine($"Total trading days  : {records.Count}");
        Console.WriteLine($"Lowest  trading price: {lowestPrice:F2}");
        Console.WriteLine($"Highest trading price: {highestPrice:F2}");
        Console.WriteLine($"Highest volume day   : {maxVolDay.Date:dd/MM/yyyy}  (Volume: {maxVolDay.Volume:N0})");
        Console.WriteLine($"  Closing price that day: {maxVolDay.Close:F2}  |  Change vs prev day: {changeStr}");

        // ── Monthly breakdown ───────────────────────────────────
        Console.Write("\nEnter a month for detailed stats (MM/YYYY, e.g. 06/2022): ");
        string monthInput = Console.ReadLine()?.Trim();

        if (!DateTime.TryParseExact(monthInput, "MM/yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime targetMonth))
        {
            Console.WriteLine("Invalid month format. Please use MM/YYYY.");
            return;
        }

        List<StockRecord> monthRecords = records
            .Where(r => r.Date.Year == targetMonth.Year && r.Date.Month == targetMonth.Month)
            .ToList();

        if (monthRecords.Count == 0)
        {
            Console.WriteLine($"No trading data found for {targetMonth:MMMM yyyy}.");
            return;
        }

        StockRecord mFirst      = monthRecords.First();
        StockRecord mLast       = monthRecords.Last();
        long        totalVol    = monthRecords.Sum(r => (long)r.Volume);
        double      monthLow    = monthRecords.Min(r => r.Low);
        double      monthHigh   = monthRecords.Max(r => r.High);

        Console.WriteLine($"\n========== {targetMonth:MMMM yyyy} STATISTICS ==========");
        Console.WriteLine($"Opening price (first day {mFirst.Date:dd/MM/yyyy}): {mFirst.Open:F2}");
        Console.WriteLine($"Closing price (last  day {mLast.Date:dd/MM/yyyy}):  {mLast.Close:F2}");
        Console.WriteLine($"Total trading volume : {totalVol:N0}");
        Console.WriteLine($"Highest trading price: {monthHigh:F2}");
        Console.WriteLine($"Lowest  trading price: {monthLow:F2}");
    }

    static List<StockRecord> LoadStockData(string path)
    {
        var records = new List<StockRecord>();

        try
        {
            string[] lines = File.ReadAllLines(path);

            // Skip header line(s) – find first line that parses as a date
            foreach (string line in lines)
            {
                string trimmed = line.Trim();
                if (string.IsNullOrWhiteSpace(trimmed)) continue;

                string[] parts = trimmed.Split(',');
                if (parts.Length < 7) continue;

                // Expected CSV columns: Date, Open, High, Low, Close, Adj Close, Volume
                if (!DateTime.TryParse(parts[0].Trim(), out DateTime date))
                    continue;   // likely header row

                if (!double.TryParse(parts[1].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out double open))   continue;
                if (!double.TryParse(parts[2].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out double high))   continue;
                if (!double.TryParse(parts[3].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out double low))    continue;
                if (!double.TryParse(parts[4].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out double close))  continue;
                if (!double.TryParse(parts[6].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out double volume)) continue;

                records.Add(new StockRecord
                {
                    Date   = date,
                    Open   = open,
                    High   = high,
                    Low    = low,
                    Close  = close,
                    Volume = (long)volume
                });
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading CSV: {ex.Message}");
            return null;
        }

        return records.OrderBy(r => r.Date).ToList();
    }

    // ─────────────────────────────────────────────────────────────
    // Helpers
    // ─────────────────────────────────────────────────────────────
    static double ReadDouble(string prompt, bool allowZero = true)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out double value))
            {
                if (!allowZero && value == 0)
                {
                    Console.WriteLine("Value cannot be zero. Please try again.");
                    continue;
                }
                return value;
            }

            Console.WriteLine("Invalid input. Please enter a numeric value.");
        }
    }
}

// ─────────────────────────────────────────────────────────────────
// Data model
// ─────────────────────────────────────────────────────────────────
class StockRecord
{
    public DateTime Date   { get; set; }
    public double   Open   { get; set; }
    public double   High   { get; set; }
    public double   Low    { get; set; }
    public double   Close  { get; set; }
    public long     Volume { get; set; }
}
