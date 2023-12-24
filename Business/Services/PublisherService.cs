using Business.Models;
using Core.Business.Services.Bases;
using Core.Repositories.EntityFramework.Bases;
using Core.Results;
using Core.Results.Bases;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

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
            return _repo.Query().Include(p => p.Games).OrderBy(p => p.Name).Select(p => new PublisherModel()
            {
                Guid = p.Guid,
                Id = p.Id,
                Name = p.Name,

                GameCountOutput = p.Games == null ? 0 : p.Games.Count,
                GamesOutput = p.Games == null ? "" : string.Join("<br />", p.Games.Select(g => g.Name))
            });
        }

        public ResultBase Add(PublisherModel model)
        {
            if (_repo.Query().Any(p => p.Name.ToUpper() == model.Name.ToUpper().Trim()))
                return new ErrorResult("Publisher can't be added because publisher with the same name exists!");
            var entity = new Publisher()
            {
                Guid = Guid.NewGuid().ToString(),
                Name = model.Name.Trim()
            };
            _repo.Add(entity);
            return new SuccessResult("Publisher added successfully.");
        }

        public ResultBase Update(PublisherModel model)
        {
            if (_repo.Query().Any(p => p.Id != model.Id && p.Name.ToUpper() == model.Name.ToUpper().Trim()))
                return new ErrorResult("Publisher can't be updated because publisher with the same name exists!");
            var entity = new Publisher()
            {
                Id = model.Id,
                Name = model.Name.Trim(),
                Guid = model.Guid
            };
            _repo.Update(entity);
            return new SuccessResult("Publisher updated successfully.");
        }

        public ResultBase Delete(params int[] ids)
        {
            var entity = _repo.Query().Include(p => p.Games).SingleOrDefault(p => ids.Contains(p.Id));
            if (entity.Games is not null && entity.Games.Any()) // if (entity.Games is not null && entity.Games.Count() > 0)
                return new ErrorResult("Publisher can't be deleted because it has relational games!");
            _repo.Delete(p => ids.Contains(p.Id));
            return new SuccessResult("Publisher deleted successfully.");
        }

        public void Dispose()
        {
            _repo.Dispose();
        }
    }
}
