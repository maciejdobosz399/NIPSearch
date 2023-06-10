using NIPSearchWebApi.Contracts;
using NIPSearchWebApi.Models;

namespace NIPSearchApp.Data.Interfaces
{
    public interface IEnterpreneurService
    {
        EnterpreneurModel Create(EnterpreneurRequestContract requestContract);

        EnterpreneurModel GetEnterpreneur(Guid guid);

        List<EnterpreneurModel> GetEnterpreneurs();
    }
}