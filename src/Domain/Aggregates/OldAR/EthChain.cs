using System;


namespace Domain.Aggregates.OldAR
{
    public class EthChain
    {
       
        private string _name ;
        private int _height;
        private string _hash ;
        private DateTime _time;
        private string _latestUrl;
        private string _previousHash;
        private string _previousUrl;
        private int _peerCount;
        private int _unconfirmedCount;
        private long _highGasPrice;
        private long _mediumGasPrice;
        private long _lowGasPrice;
        private long _highPriorityFee;
        private long _mediumPriorityFee;
        private long _lowPriorityFee;
        private long _baseFee;
        private int _lastForkHeight;
        private string _lastForkHash;
        private DateTime _createdAt;
        string _jsonApi;

        public EthChain( string name, int height, string hash, DateTime time, string latestUrl, string previousHash, string previousUrl, int peerCount, int unconfirmedCount, long highGasPrice, long mediumGasPrice, long lowGasPrice, long highPriorityFee, long mediumPriorityFee, long lowPriorityFee, long baseFee, int lastForkHeight, string lastForkHash, DateTime createdAt,string jsonApi)
        {
            _name = name;
            _height = height;
            _hash = hash;
            _time = time;
            _latestUrl = latestUrl;
            _previousHash = previousHash;
            _previousUrl = previousUrl;
            _peerCount = peerCount;
            _unconfirmedCount = unconfirmedCount;
            _highGasPrice = highGasPrice;
            _mediumGasPrice = mediumGasPrice;
            _lowGasPrice = lowGasPrice;
            _highPriorityFee = highPriorityFee;
            _mediumPriorityFee = mediumPriorityFee;
            _lowPriorityFee = lowPriorityFee;
            _baseFee = baseFee;
            _lastForkHeight = lastForkHeight;
            _lastForkHash = lastForkHash;
            _createdAt = createdAt;
            _jsonApi=jsonApi;
        }

        

        public string GetName()
        {
            return _name;
        }

        public int GetHeight()
        {
            return _height;
        }

        public string GetHash()
        {
            return _hash;
        }

        public DateTime GetTime()
        {
            return _time;
        }

        public string GetLatestUrl()
        {
            return _latestUrl;
        }

        public string GetPreviousHash()
        {
            return _previousHash;
        }

        public string GetPreviousUrl()
        {
            return _previousUrl;
        }

        public int GetPeerCount()
        {
            return _peerCount;
        }

        public int GetUnconfirmedCount()
        {
            return _unconfirmedCount;
        }

        public long GetHighGasPrice()
        {
            return _highGasPrice;
        }

        public long GetMediumGasPrice()
        {
            return _mediumGasPrice;
        }

        public long GetLowGasPrice()
        {
            return _lowGasPrice;
        }

        public long GetHighPriorityFee()
        {
            return _highPriorityFee;
        }

        public long GetMediumPriorityFee()
        {
            return _mediumPriorityFee;
        }

        public long GetLowPriorityFee()
        {
            return _lowPriorityFee;
        }

        public long GetBaseFee()
        {
            return _baseFee;
        }

        public int GetLastForkHeight()
        {
            return _lastForkHeight;
        }

        public string GetLastForkHash()
        {
            return _lastForkHash;
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
