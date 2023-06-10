using NIPSearchWebApi.Contracts;
using System.Net;

namespace NIPSearch.WebApi.Interfaces
{
    public interface ISearchRepository
    {
        Task<(EnterpreneurRequestContract, bool)> SearchAsync(string nip);
    }
}