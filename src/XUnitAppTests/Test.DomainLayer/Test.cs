using System.Text.Json;

namespace XUnitAppTests.Test.DomainLayer
{
    public class Test
    {
        [Fact]
        public void ValidJsonNameWithChainName()
        {
            //sample 
            string jsontest = @"{
  ""name"": ""BTC.main"",
  ""height"": 940688
}";

            var jo = JsonDocument.Parse(jsontest);
            string? _name = jo.RootElement.GetProperty("name").GetString();

            var chain = new Domain.Aggregates.ChainAR.BlockChain(Domain.Providers.EnumSourceProvider.Blockcypher, "BTC.main", DateTime.Now, jsontest);

            Assert.Equal(chain.GetName().ToLower(), _name?.ToLower());

        }
    }
}
