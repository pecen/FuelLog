using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace FuelLog.TestConsole {
  class Program {
    [STAThread]
    static void Main(string[] args) {
      while (true) {
        try {
          ShowMenu();

          switch (ReadKey().KeyChar) {
            case '1': GetCars(); break;
            case '2': GetCar(); break;
            case '3': GetFillups(); break;
            case '0': WriteLine(); return;

            default: ShowMenu(); break;
          }
        }
        catch (Exception ex) {
          WriteLine();
          WriteLine("There was an error: ");
          while (ex != null) {
            WriteLine(ex.Message);
            ex = ex.InnerException;
          }
        }

        WriteLine();
        WriteLine("Press <ENTER> to return to menu.");
        ReadLine();
      }
    }

    public static void ShowMenu() {
      Clear();
      WriteLine("PREREQ:");
      WriteLine("1. Set first req here,");
      WriteLine("2. Set second req here");
      WriteLine("");
      WriteLine("- Select DecryptionService command.");
      WriteLine("");
      WriteLine(" 1) Get Cars.");
      WriteLine(" 2) Get specific Car.");
      WriteLine(" 3) Get Fillups for a Car.");
      WriteLine(" 0) Exit");

      WriteLine("");
      Write(" > ");
    }

    private static void GetCars() {
      throw new NotImplementedException();
    }

    private static void GetCar() {
      throw new NotImplementedException();
    }

    private static void GetFillups() {
      throw new NotImplementedException();
    }
  }
}
