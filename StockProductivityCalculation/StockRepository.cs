using System.Collections.Generic;
using System.Web;

namespace StockProductivityCalculation
{
    /// <summary>
    /// This class allows to keep Stock data and calculation results together in memory
    /// </summary>
    public class StockHttpApplicationRepository : IStockRepository
    {
        //Key of storage in application state
        private const string KEY_NAME = "StockStorage";

        HttpApplicationState currentApplication;

        public StockHttpApplicationRepository(HttpApplicationState state)
        {
            this.currentApplication = state;
        }

        public void Add(StockCalculationResult result)
        {
            //Since ApplicationState is thread unsafe use lock models during adding new values.
            lock (currentApplication)
            {
                IList<StockCalculationResult> results = currentApplication[KEY_NAME] as IList<StockCalculationResult>;
                if(results == null)
                {
                    results = new List<StockCalculationResult>();
                    currentApplication[KEY_NAME] = results;
                }
                results.Add(result);
            }
        }

        public IList<StockCalculationResult> GetAll()
        {
            return currentApplication[KEY_NAME] as IList<StockCalculationResult>;
        }
    }

    public interface IStockRepository
    {
        void Add(StockCalculationResult result);
        IList<StockCalculationResult> GetAll();
    }
}