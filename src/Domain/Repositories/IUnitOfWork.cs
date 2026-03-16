namespace Domain.Repositories
{
    public interface IUnitOfWork
    {
        Repositories.IBtcRepository BtcRepository{ get; }
        Repositories.IBtcTest3Repository BtcTest3Repository { get; }
        Repositories.IDashRepository DashRepository{ get; }
        Repositories.IEthRepository EthRepository { get; }
        Repositories.ILtcRepository LtcRepository { get; }

        IChainRepository ChainRepository { get; }
        void Commit();

    }
}
