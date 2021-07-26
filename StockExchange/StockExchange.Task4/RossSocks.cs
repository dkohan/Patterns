using System;

namespace StockExchange.Task4
{
    public class RossSocks
    {
        public int SoldShares { get; private set; }

        public int BoughtShares { get; private set; }

        public RossSocks()
        {
        }

        public bool SellOffer(string stockName, int numberOfShares)
        {
            StockMarket.StockRequestCompleted += Update;
            return StockMarket.MakeStockRequest(new Stock(false, stockName, numberOfShares, nameof(RossSocks)));
        }

        public bool BuyOffer(string stockName, int numberOfShares)
        {
            StockMarket.StockRequestCompleted += Update;
            return StockMarket.MakeStockRequest(new Stock(true, stockName, numberOfShares, nameof(RossSocks)));
        }

        void Update(object sender, Stock stock)
        {
            if (stock.Player == nameof(RossSocks))
            {
                if (stock.Type)
                {
                    BoughtShares += stock.Number;
                }
                else
                {
                    SoldShares += stock.Number;
                }
            }
            else
            {
                if (!stock.Type)
                {
                    BoughtShares += stock.Number;
                }
                else
                {
                    SoldShares += stock.Number;
                }
            }
        }


    }
}
