
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Providers
{
    /// <summary>
    /// i choose to implement the Provider interfaces in the domain as in the future it might collaborate with domain services if necessary
    /// </summary>
    public interface ISourceProvider
    {
        Task<string> GetBtcMainAsync(CancellationToken cancellationToken = default);

        Task<string> GetETHAsynch(CancellationToken cancellationToken = default);

        Task<string> GetDASHAsync(CancellationToken cancellationToken = default);

        Task<string> GetLTCSourceAsync(CancellationToken cancellationToken = default);

        Task<string> GetBtcTest3SourceAsync(CancellationToken cancellationToken = default);
    }


    public interface IProviderFactory
    {
        ISourceProvider ProvideFor(EnumSourceProvider enumSourceProvider);
        

    }

}
