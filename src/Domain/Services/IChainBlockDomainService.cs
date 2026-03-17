using Domain.Aggregates.ChainAR;
using System;
using System.Collections.Generic;

namespace Domain.Services
{


    /// <summary>
    /// Domain service that encapsulates operations involving multiple aggregates.
    /// Even if no current complex coordination is needed, this service allows future cross-aggregate logic.
    /// The name can be adapted to match the actual business domain.
    /// Domain service is not being use in the system but is just for example
    /// </summary>
    public interface IChainBlockDomainService
    {
        void DoSomething(BlockChain AR1, AR_Example AR2, List<string> otherdata);
    }

    //probably implementation in domain or infrastrucure
    public class ChainBlockDomainService : IChainBlockDomainService
    {
        public void DoSomething(BlockChain AR1, AR_Example AR2, List<string> otherdata)
        {
            if(AR1.Source== Providers.EnumSourceProvider.Blockcypher && AR2.GetCreatedDate().Date != DateTime.Now.Date)
            {
                throw new Exception("something happened");
            }
            AR2.SetInformation(100);
             
        }
    }

    public class AR_Example
    {
        string _name;
        DateTime _createdDate;
        decimal _amount;

        public AR_Example(string name, DateTime createdDate, decimal amount)
        {
            _name = name;
            _createdDate = createdDate;
            _amount = amount;
        }
        public DateTime GetCreatedDate()
        {
            return _createdDate;
        }
        internal void SetInformation(decimal amount)
        {
            _amount = amount;
        }
    }
}
