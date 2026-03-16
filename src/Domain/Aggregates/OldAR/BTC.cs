using System;

namespace Domain.Aggregates.OldAR
{
    public class BTC
    {
        private string _name;
        private int _height;
        private string _hash;
        private DateTime _time;
        private string _latestUrl;
        private string _previousHash;
        private string _previousUrl;
        private int? _peerCount;
        private int _unconfirmedCount;
        private int _highFeePerKb;
        private int _mediumFeePerKb;
        private int _lowFeePerKb;
        private int _lastForkHeight;
        private string _lastForkHash;
        private DateTime _createdAt;
        private string _jsonApi;
        public BTC(string name, int height, string hash, DateTime time, string latestUrl, string previousHash, string previousUrl, int? peerCount, int unconfirmedCount, int highFeePerKb, int mediumFeePerKb, int lowFeePerKb, int lastForkHeight, string lastForkHash, DateTime createdAt,string jsonApi)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));
            }

            _name = name;
            _height = height;
            _hash = hash;
            _time = time;
            _latestUrl = latestUrl;
            _previousHash = previousHash;
            _previousUrl = previousUrl;
            _peerCount = peerCount;
            _unconfirmedCount = unconfirmedCount;
            _highFeePerKb = highFeePerKb;
            _mediumFeePerKb = mediumFeePerKb;
            _lowFeePerKb = lowFeePerKb;
            _lastForkHeight = lastForkHeight;
            _lastForkHash = lastForkHash;
            _createdAt = createdAt;
            _jsonApi = jsonApi;
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

        public int? GetPeerCount()
        {
            return _peerCount;
        }

        public int GetUnconfirmedCount()
        {
            return _unconfirmedCount;
        }

        public int GetHighFeePerKb()
        {
            return _highFeePerKb;
        }

        public int GetMediumFeePerKb()
        {
            return _mediumFeePerKb;
        }

        public int GetLowFeePerKb()
        {
            return _lowFeePerKb;
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
