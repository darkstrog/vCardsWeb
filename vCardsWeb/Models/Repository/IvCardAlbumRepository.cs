using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vCardsWeb.Models.Repository
{
    public interface IvCardAlbumRepository
    {
        Task Create(vCardsAlbum album);
        Task Delete(string id);
        Task<vCardsAlbum> GetById(string id);
        Task<IEnumerable<vCardsAlbum>> GetAlbums(string user_id);
        Task Update(vCardsAlbum album);

    }
}
