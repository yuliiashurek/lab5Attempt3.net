using System.Text;
using lab5.Commands;
using lab5.Observers;
using lab5.Subjects.Currency;
using lab5.Subjects.Currency.XmlCurrency;
using lab5.Subjects.Stock;

namespace lab5
{
    static class Program
    {
        private static void Main()
        {
            try
            {
                
                Console.OutputEncoding = Encoding.UTF8;

                
                MainController mainController= MainController.GetInstance(new MainView(), new MainModel());
                mainController.CreateSubjUserSubsciptions();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
