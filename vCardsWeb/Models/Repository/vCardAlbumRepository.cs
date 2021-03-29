using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace vCardsWeb.Models.Repository
{
    public class vCardAlbumRepository : IvCardAlbumRepository
    {
        string connectionString;
        public vCardAlbumRepository(string _connectionString)
        {
            connectionString = _connectionString;
        }
        public async Task Create(vCardsAlbum album)
        {
            using (DbConnection db = new SqlConnection(connectionString))
            {
                string _query = "insert into vCardsAlbums album_id, album_usid, album_name, album_description values (@album_id, @album_usid, @album_name, @album_description); select cast(scope_identity() as int)";
                int? _album_id = (await db.QueryAsync<int>(_query, album)).FirstOrDefault();
                album.vCardsAlbum_id = _album_id.Value;
            }
        }
        /// <summary>
        /// Удаляет из базы альбом с указанныи id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(string id)
        {
            using (DbConnection db = new SqlConnection(connectionString))
            {
                string _query = "delete from vCardsAlbums where album_id=@id";
                await db.ExecuteAsync(_query, id);
            }
        }
        /// <summary>
        /// Возвращает альбом с указанным id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<vCardsAlbum> GetById(string id)
        {
            using (DbConnection db = new SqlConnection(connectionString))
            {
                string _query = "select album_id, album_usid, album_name, album_description from vCardsAlbums where album_id=@id";
                return (await db.QueryAsync<vCardsAlbum>(_query, new { id })).FirstOrDefault();
            }
        }

        public async Task<IEnumerable<vCardsAlbum>> GetAlbums(string user_id)
        {
            using (DbConnection db = new SqlConnection(connectionString))
            {
                string _query = "select vCardsAlbum_id, album_id, album_usid, album_name, album_description from vCardsAlbums where album_usid=@user_id";
                return (await db.QueryAsync<vCardsAlbum>(_query, new { user_id })).ToList();
            }
        }

        public async Task Update(vCardsAlbum album)
        {
            using (DbConnection db = new SqlConnection(connectionString))
            {
                string _query = "update vCardsAlboms set album_usid=@album_usid, album_name=@album_name, album_description=@album_description";
                await db.ExecuteAsync(_query, album);
            }
        }
    }
}
