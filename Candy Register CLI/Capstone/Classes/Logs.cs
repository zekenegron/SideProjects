using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public sealed class Logs
    {
        
        string loggingFilePath = @"C:\Store\Log.txt";
        public void LogMoneyReceived(decimal amountAdded, decimal currentBalance)
        {
            using(StreamWriter writer = new StreamWriter(loggingFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now} MONEY RECEIVED: {amountAdded.ToString("C")} {currentBalance.ToString("c")}");
            }
        }

        public void LogChangeGiven(decimal change)
        {
            using (StreamWriter writer = new StreamWriter(loggingFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now} CHANGE GIVEN: {change.ToString("C")} $0.00");
            }
        }

        public void LogItemPurchased(Inventory item, int numOfItems, decimal balance)
        {
            using (StreamWriter writer = new StreamWriter(loggingFilePath, true))
            {
                decimal cost = numOfItems * item.Price;
                writer.WriteLine($"{DateTime.Now} {numOfItems} {item.Name} {item.Id} {cost.ToString("c")} {balance.ToString("c")}");
            }
        }
    }
}
