namespace Domain.Repositories
{
    public interface IUnitOfWork
    {
        
        IChainRepository ChainRepository { get; }
        void Commit();

    }
}
