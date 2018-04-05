using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumberSelection
{
  public static class NumberList
  {    
    public static IList<int> GenerateList()
    {
      IList<int> numbers = new List<int>();
      var random = new Random();
      for (var i = 0; i < 10; i++)
      {
        numbers.Add(random.Next(50));
      }
      return numbers;
    }

    public static IList<NumberPair> SelectPairs(this IList<int> numbers, int sum)
    {
      IList<NumberPair> numberPairs = new List<NumberPair>();
      IList<int> selectedList = numbers.Where(n => n < sum).ToList();
      for(var i = 0; i < selectedList.Count - 1; i++)
      {
        int firstNumber = selectedList[i];
        for (var k = i + 1; k < selectedList.Count; k++)
        {
          if (firstNumber + selectedList[k] == sum)
          {
            NumberPair pair = new NumberPair(firstNumber, selectedList[k]);
            numberPairs.Add(pair);
            selectedList.RemoveAt(k);
            break;
          }
        }
      }
      return numberPairs;
    }
  }

  public struct NumberPair
  {
    public int FirstNumber { get; private set; }
    public int SecondNumber { get; private set; }

    public NumberPair(int firstNumber, int secondNumber)
    {
      FirstNumber = firstNumber;
      SecondNumber = secondNumber;
    }
  }
}
