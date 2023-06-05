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
            // try
            // {
                
                Console.OutputEncoding = Encoding.UTF8;

                
                MainController mainController= MainController.GetInstance(new MainView());
                MainModel mainModel = new MainModel(mainController);
                mainModel.CreateSubjUserSubsciptions();


                // //creating subjects
                // CurrencyRates currencyRates = new CurrencyRates(new WorkWithXml());
                // GovernmentBondStockQuote governmentBondStockQuote =
                //     new GovernmentBondStockQuote(1323146884.35, WayOfPaying.PostPaid);
                // NaturalGasStockQuotes naturalGasStockQuotes =
                //     new NaturalGasStockQuotes(10708.35, DeliveryConditions.Gts);
                //
                // //output all of the subjects
                // Console.WriteLine(currencyRates.CurrencyRatesToString());
                // Console.WriteLine(governmentBondStockQuote.StockQuotesToString());
                // Console.WriteLine(naturalGasStockQuotes.StockQuotesToString());
                //
                // //creating observers
                // UserView userView = new UserView();
                // User user1 = new User("user1", UserController.GetInstance(userView));
                // User user2 = new User("user2", UserController.GetInstance(userView));
                //
                // //adding subscriptions
                // user1.AddSubscription(currencyRates);
                // governmentBondStockQuote.RegisterObserver(user1);
                // user2.AddSubscription(naturalGasStockQuotes);

                //
                // CommandsAndHistory commandsAndHistory = new();
                // Console.WriteLine(
                //     "Enter a number n (added to governmentBond, naturalGas'll increase in n percentages):");
                // string? input = Console.ReadLine();
                // if (double.TryParse(input, out var number))
                // {
                //     commandsAndHistory.SetCommand(CommandsEnum.IncreaseGovPrice, new IncreasePriceCommand(governmentBondStockQuote, number));
                //     commandsAndHistory.SetCommand(CommandsEnum.IncreaseNatGasPercentage, new IncreasePriceByPercentageCommand(naturalGasStockQuotes, number));

                //make changes
                // commandsAndHistory.PressIncrease(CommandsEnum.IncreaseGovPrice);
                // commandsAndHistory.PressIncrease(CommandsEnum.IncreaseNatGasPercentage);
                // commandsAndHistory.PressUndo();
                // }
                //
                // //removing subscriptions
                // governmentBondStockQuote.RemoveObserver(user1);
            // }
            // catch (Exception e)
            // {
            //     Console.WriteLine(e.Message);
            // }
        }
    }
}