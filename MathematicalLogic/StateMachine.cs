using System;
using System.Threading;
using System.Collections.Generic;

namespace MathematicalLogic
{
  public enum Move
  {
    Left = -1,
    Stop = 0,
    Right = 1
  }
  public enum State
  {
    QSTOP, Q0, Q1, Q2, Q3, Q4, Q5, Q6, Q7, Q8, Q9, Q10, Q11
  }
  public enum Value
  {
    One, Two, Empty
  }

  class StateMachine
  {
    private int valuePosition;
    private List<Value> values;

    private State currentState;
    private Dictionary<State, Dictionary<Value, (State, Value, Move)>> table;

    public StateMachine(
      List<Value> values,
      Dictionary<State, Dictionary<Value, (State, Value, Move)>> table)
    {
      this.values = values;
      values.Insert(0, Value.Empty);
      values.Add(Value.Empty);

      valuePosition = 0;

      currentState = State.Q0;
      this.table = table;
    }

    public void Run(Action<State, List<Value>, int> functor)
    {
      while (currentState != State.QSTOP)
      {
        var (state, value, move) = table[currentState][values[valuePosition]];

        currentState = state;
        values[valuePosition] = value;
        functor(state, values, valuePosition);
        valuePosition += (int)move;

        Thread.Sleep(1000);
      }
    }
  }
}
