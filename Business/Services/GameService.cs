using Business.Models;
using Core.Business.Services.Bases;
using Core.Repositories.EntityFramework.Bases;
using Core.Results.Bases;
using DataAccess.Entities;
using DataAccess.Enums;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public interface IGameService : IService<GameModel>
    {
        List<GameModel> GetList();
        GameModel GetItem(int id);
    }

    public class GameService : IGameService
    {
        private readonly RepoBase<Game> _repo;

        public GameService(RepoBase<Game> repo)
        {
            _repo = repo;
        }

        public IQueryable<GameModel> Query()
        {
            return _repo.Query()
                //.Include(g => g.Publisher)
                //.Include(g => g.UserGames).ThenInclude(ug => ug.User)
                .OrderByDescending(g => g.PublishDate).ThenBy(g => g.Price).ThenBy(g => g.Name)
                .Where(g => !g.IsDeleted).Select(g => new GameModel()
                {
                    Id = g.Id,
                    Guid = g.Guid,

                    Name = g.Name,
                    Description = g.Description,
                    PublishDate = g.PublishDate,
                    Price = g.Price,
                    DownloadCount = g.DownloadCount,
                    PlayerCountType = g.PlayerCountType,
                    IsDeleted = g.IsDeleted,
                    PublisherId = g.PublisherId,

                    UserIdsInput = g.UserGames != null ? g.UserGames.Select(ug => ug.UserId).ToList() : null,
                    UsersOutput = g.UserGames != null ? g.UserGames.Select(ug => new UserModel()
                    {
                        UserName = ug.User != null ? ug.User.UserName : string.Empty,
                        Sex = ug.User != null ? ug.User.Sex : 0
                    }).ToList() : null,
                    PlayerCountTypeOutput = ((PlayerCountType)g.PlayerCountType).HasFlag(PlayerCountType.SinglePlayer)
                        && ((PlayerCountType)g.PlayerCountType).HasFlag(PlayerCountType.MultiPlayer)
                            ? "Single and Multi Player"
                            : ((PlayerCountType)g.PlayerCountType).HasFlag(PlayerCountType.SinglePlayer)
                                ? "Single Player"
                                : "Multi Player",
                    PriceOutput = g.Price.ToString("C2"),
                    PublishDateOutput = g.PublishDate.HasValue ? g.PublishDate.Value.ToString("yyyy-MM-dd") : string.Empty,
                    PublisherOutput = g.Publisher != null ? new PublisherModel()
                    {
                        Name = g.Publisher.Name
                    } : null
                });
        }

        public ResultBase Add(GameModel model)
        {
            throw new NotImplementedException();
        }

        public ResultBase Update(GameModel model)
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

        public List<GameModel> GetList()
        {
            return Query().ToList();
        }

        public GameModel GetItem(int id)
        {
            return Query().SingleOrDefault(q => q.Id == id);
        }
    }
}
