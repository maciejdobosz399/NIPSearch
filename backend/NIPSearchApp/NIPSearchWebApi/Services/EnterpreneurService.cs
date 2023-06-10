using NIPSearchApp.Data.DbContexts;
using NIPSearchApp.Data.Interfaces;
using NIPSearchWebApi.Contracts;
using NIPSearchWebApi.Models;

namespace NIPSearchApp.Data.Services
{
    public class EnterpreneurService : IEnterpreneurService
    {
        private readonly EnterpreneurDbContext _dbContext;

        public EnterpreneurService(EnterpreneurDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public EnterpreneurModel Create(EnterpreneurRequestContract requestContract)
        {
            var model = new EnterpreneurModel()
            {
                Guid = new Guid(),
                Name = requestContract.Name,
                Nip = requestContract.Nip,
                Regon = requestContract.Regon,
                Address = requestContract.Address,
            };

            if (_dbContext.Enterpreneurs.Any(ent => ent.Nip == model.Nip))
                return model;

            _dbContext.Enterpreneurs.Add(model);
            _dbContext.SaveChanges();

            return model;
        }

        public List<EnterpreneurModel> GetEnterpreneurs()
        {
            return _dbContext.Enterpreneurs.ToList();
        }

        public EnterpreneurModel GetEnterpreneur(Guid guid)
        {
            return _dbContext.Enterpreneurs.SingleOrDefault(ent => ent.Guid == guid)!;
        }
    }
}