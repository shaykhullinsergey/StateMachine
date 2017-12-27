
using static MathematicalLogic.Value;

namespace MathematicalLogic
{
  public static class MyClass
  {
    public static string ToLiteral(this Value value)
    {
      switch (value)
      {
        case One: return "1";
        case Two: return "2";
        case Empty: return "^";
      }

      return "";
    }
  }
}
