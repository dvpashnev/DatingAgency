using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatingAgency
{
  static class CurrentClient
  {
    public static Client Value = null;
  }
  
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new Form1());
    }
  }

  public class MyException : Exception
  {
    public MyException(Control ctrl, string message)
      : base(message)
    {
      Data.Add("controlParent", ctrl.Parent.Name);
      Data.Add("controlName", ctrl.Name);
      Data.Add("controlType", ctrl.GetType());
    }
  }

  static class ZodiacSing
  {
    public static string GetZodiacSing(DateTime dt)
    {
      if (dt >= new DateTime(dt.Year, 3, 21)
        && dt <= new DateTime(dt.Year, 4, 20)) // Овен 21 марта — 20 апреля
      {
        return "овен";
      }
      else if (dt >= new DateTime(dt.Year, 4, 21)
        && dt <= new DateTime(dt.Year, 5, 21)) // Телец 21 апреля — 21 мая
      {
        return "телец";
      }
      else if (dt >= new DateTime(dt.Year, 5, 22)
        && dt <= new DateTime(dt.Year, 6, 21)) // Близнецы 22 мая — 21 июня
      {
        return "близнецы";
      }
      else if (dt >= new DateTime(dt.Year, 6, 22)
        && dt <= new DateTime(dt.Year, 7, 22)) // Рак 22 июня — 22 июля
      {
        return "рак";
      }
      else if (dt >= new DateTime(dt.Year, 7, 23)
        && dt <= new DateTime(dt.Year, 8, 23)) // Лев 23 июля — 23 августа
      {
        return "лев";
      }
      else if (dt >= new DateTime(dt.Year, 8, 24)
        && dt <= new DateTime(dt.Year, 9, 23)) // Дева 24 августа — 23 сентября
      {
        return "дева";
      }
      else if (dt >= new DateTime(dt.Year, 9, 24)
        && dt <= new DateTime(dt.Year, 10, 23)) // Весы 24 сентября — 23 октября
      {
        return "весы";
      }
      else if (dt >= new DateTime(dt.Year, 10, 24)
       && dt <= new DateTime(dt.Year, 11, 22)) // Скорпион 24 октября — 22 ноября
      {
        return "скорпион";
      }
      else if (dt >= new DateTime(dt.Year, 11, 23)
        && dt <= new DateTime(dt.Year, 12, 21)) // Стрелец 23 ноября — 21 декабря
      {
        return "стрелец";
      }
      else if (dt >= new DateTime(dt.Year, 12, 22)
       && dt <= new DateTime(dt.Year, 1, 20)) // Козерог 22 декабря — 20 января
      {
        return "козерог";
      }
      else if (dt >= new DateTime(dt.Year, 1, 21)
        && dt <= new DateTime(dt.Year, 2, 18)) // Водолей 21 января — 18 февраля
      {
        return "водолей";
      }
      else if (dt >= new DateTime(dt.Year, 2, 19)
        && dt <= new DateTime(dt.Year, 3, 20)) // Рыбы 19 февраля — 20 марта
      {
        return "рыбы";
      }
      return "овен";
    }

  }
}
