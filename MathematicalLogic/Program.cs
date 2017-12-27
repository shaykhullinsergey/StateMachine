using System;
using System.Collections.Generic;

using static MathematicalLogic.Value;
using static MathematicalLogic.State;
using static MathematicalLogic.Move;

namespace MathematicalLogic
{
  class Program
  {
    static void Main(string[] args)
    {
      var machine = new StateMachine(Values, Table);

      machine.Run((state, value, position) =>
      {
        Console.Clear();
        Console.WriteLine($"{string.Join("   ", IterateValues())}\t {state}");

        IEnumerable<string> IterateValues()
        {
          for (int index = 0; index < value.Count; index++)
            yield return index == position 
              ? $"|{value[index].ToLiteral()}|"
              : value[index].ToLiteral();
        }
      });
    }

    static List<Value> Values => new List<Value>
    {
      One, One, One, One, One, One, One, One, One, One, One
    };

    static Dictionary<State, Dictionary<Value, (State, Value, Move)>> Table =>
      new Dictionary<State, Dictionary<Value, (State, Value, Move)>>
    {
      [Q0] = new Dictionary<Value, (State, Value, Move)>
      {
        [Empty] = (Q1, Empty, Right)
      },

      [Q1] = new Dictionary<Value, (State, Value, Move)>
      {
        [Empty] = (Q4, Empty, Stop),
        [One] = (Q2, Two, Right)
      },

      [Q2] = new Dictionary<Value, (State, Value, Move)>
      {
        [Empty] = (Q4, Empty, Stop),
        [One] = (Q3, Two, Right)
      },

      [Q3] = new Dictionary<Value, (State, Value, Move)>
      {
        [Empty] = (Q4, Empty, Stop),
        [One] = (Q1, One, Right)
      },

      [Q4] = new Dictionary<Value, (State, Value, Move)>
      {
        [Empty] = (Q5, Empty, Left)
      },

      [Q5] = new Dictionary<Value, (State, Value, Move)>
      {
        [Empty] = (QSTOP, Empty, Stop),
        [Two] = (Q5, Empty, Left),
        [One] = (Q6, One, Stop)
      },

      [Q6] = new Dictionary<Value, (State, Value, Move)>
      {
        [Empty] = (QSTOP, Empty, Stop),
        [One] = (Q7, One, Right)
      },

      [Q7] = new Dictionary<Value, (State, Value, Move)>
      {
        [Empty] = (Q8, Empty, Left),
        [One] = (Q7, One, Right)
      },

      [Q8] = new Dictionary<Value, (State, Value, Move)>
      {
        [One] = (Q9, Empty, Left)
      },

      [Q9] = new Dictionary<Value, (State, Value, Move)>
      {
        [Empty] = (Q10, Empty, Right),
        [Two] = (Q7, One, Stop),
        [One] = (Q9, One, Left)
      },

      [Q10] = new Dictionary<Value, (State, Value, Move)>
      {
        [Empty] = (Q11, One, Stop),
        [One] = (Q10, One, Right)
      },

      [Q11] = new Dictionary<Value, (State, Value, Move)>
      {
        [Empty] = (QSTOP, Empty, Stop),
        [One] = (QSTOP, One, Stop)
      }
    };
  }
}
