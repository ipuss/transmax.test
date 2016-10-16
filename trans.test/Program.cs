using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace trans.test
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                File.WriteAllLines(
                    $"{Path.GetFileNameWithoutExtension(args[0])}-graded.txt",
                    File.ReadAllLines(args[0])
                        .Where(l => Regex.IsMatch(l, @"^\w*, ?\w*, ?\d*$"))
                        .Select(l => l.Split(new char[] { ',' }))
                        .OrderByDescending(s => decimal.Parse(s[2]))
                        .ThenBy(s => s[0].ToLowerInvariant())
                        .ThenBy(s => s[1].ToLowerInvariant())
                        .Select(s => string.Join(", ", s))
                        .ToArray());
                Console.WriteLine("Completed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}\n\n{ex.ToString()}");
            }
            
            Console.ReadKey();
        }
    }
}
