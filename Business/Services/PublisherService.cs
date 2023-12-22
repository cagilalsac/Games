using Business.Models;
using Core.Business.Services.Bases;
using Core.Repositories.EntityFramework.Bases;
using Core.Results.Bases;
using DataAccess.Entities;

namespace Business.Services
{
    public interface IPublisherService : IService<PublisherModel>
    {
    }

    public class PublisherService : IPublisherService
    {
        private readonly RepoBase<Publisher> _repo;

        public PublisherService(RepoBase<Publisher> repo)
        {
            _repo = repo;
        }

        public IQueryable<PublisherModel> Query()
        {
            return _repo.Query().OrderBy(p => p.Name).Select(p => new PublisherModel()
            {
                Guid = p.Guid,
                Id = p.Id,
                Name = p.Name,

                GameCountOutput = p.Games.Count
            });
        }

        public ResultBase Add(PublisherModel model)
        {
            throw new NotImplementedException();
        }

        public ResultBase Update(PublisherModel model)
        {
            throw new NotImplementedException();
        }

        public ResultBase Delete(params int[] ids)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _repo.Dispose();
        }
    }
}
