 
using System;

namespace Domain.Aggregates.ChainAR
{
    public class BlockChain
    {
        private string _name;
        private DateTime _createdAt;
        private string _jsonApi;
        private Providers.EnumSourceProvider _source;
        public Providers.EnumSourceProvider Source => _source;

        /// <summary>
        /// Improvments
        /// name could be an enum
        /// </summary>
        public BlockChain(Providers.EnumSourceProvider source, string name, DateTime createdAt, string jsonApi)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));

            if (string.IsNullOrEmpty(jsonApi))
                throw new ArgumentException($"'{nameof(jsonApi)}' cannot be null or empty.", nameof(jsonApi));

            if (createdAt == DateTime.MinValue || createdAt == DateTime.MaxValue)
            {
                //this is unusual and shouldn't be happened
                //we can throw an exception
            }

            if (jsonApi.ToLower().Contains(name.ToLower()) == false)
            {
                //this is a small fraction of validation that name of chain we about to add in the system exists in json api:
                //we can throw an exception
            }


            _name = name;
            _createdAt = createdAt;
            _jsonApi = jsonApi;
            _source = source;
        }

        public string GetName()
        {
            return _name;
        }

        public DateTime GetCreatedAt()
        {
            return _createdAt;
        }

        public string GetJsonApi()
        {
            return _jsonApi;
        }

        

    }

}
