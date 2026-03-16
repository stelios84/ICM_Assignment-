
 

namespace Application.AppServices
{
    /// <summary>
    /// methods are responsible to fetch and update
    /// </summary>
    public interface IAppChainServiceDepreciate
    {

        Task<IEnumerable<DTO.BTCDto>> GetBTCAsynch();
        Task<IEnumerable<DTO.BtcTest3DTO>> GetBtcTest3Asynch();
        Task<IEnumerable<DTO.DashDTO>> GetDashAsynch();
        Task<IEnumerable<DTO.EthDTO>> GetEthAsynch();
        Task<IEnumerable<DTO.LtcDTO>> GetLtcAsynch();



        
       
         
    }
}
