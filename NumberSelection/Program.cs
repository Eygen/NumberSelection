using System;
using System.Collections.Generic;

namespace NumberSelection
{
  class Program
  {
    static void Main(string[] args)
    {
      IList<int> list = NumberList.GenerateList();
      foreach (var item in list)
      {
        Console.WriteLine(item);
      }
      Console.WriteLine("Введите целое число:");
      int sum;
      enterNumber: string sumStr = Console.ReadLine();      
      if (!Int32.TryParse(sumStr, out sum))
      {
        Console.WriteLine("Вы ввели не число! Попробуйте еще раз:");
        goto enterNumber;
      }
      IList<NumberPair> pairs = list.SelectPairs(sum);
      foreach(var item in pairs)
      {
        Console.WriteLine($"({item.FirstNumber}, {item.SecondNumber})");
      }
      Console.ReadKey();
    }
  }
}
