using System;
using System.Collections.Generic;
using Test.Task.Entities;

namespace Test.Task
{
    public class DataLayer
    {
        public async System.Threading.Tasks.Task<IList<MacBase>> GetDataAsync()
        {
            using (var DbContext = new DataBaseContext())
            {
                List<MacBase> outList = new List<MacBase>();
                try
                {
                    var list = DbContext.CpeMacBase.AsAsyncEnumerable();

                    await foreach (var item in list)
                    {
                        outList.Add(item);
                    }
                    
                }
                catch (Exception ex)
                {
                    Logger.Log(ex.Message);
                }
                return outList;
            }
        }
    }
}
