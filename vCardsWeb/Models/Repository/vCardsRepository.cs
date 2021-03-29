using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;

namespace vCardsWeb.Models.Repository
{
    public class vCardsRepository : IvCardsRepository
    {
        string connectionString;
        public vCardsRepository(string _connectionString)
        {
            connectionString = _connectionString;
        }
        public async Task<bool> Create(vCardContainer CardContainer)
        {
            using (DbConnection db = new SqlConnection(connectionString))
            {
                string _query = "insert into vCards (vCard_usid, vCard_groupname, vCard_name, vCard_PrefNumber, vCard_data, CreateDate, Modified_date) values(@vCard_usid, @vCard_name, @vCard_PrefNumber, vCard_groupname, @vCard_data, @CreateDate, @Modified_date); select cast(scope_identity() as int)";
                try
                {
                    int? CardContainer_Id = (await db.QueryAsync<int>(_query, CardContainer)).FirstOrDefault();
                    CardContainer.vCard_id = CardContainer_Id.Value;
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task<bool> Delete(int _id)
        {
            using (DbConnection db = new SqlConnection(connectionString))
            {
                string _query = "delete from vCards where vCard_id=@_id";
                try
                {
                    await db.ExecuteAsync(_query, new { _id });
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task<vCardContainer> GetById(int id)
        {
            using (DbConnection db = new SqlConnection(connectionString))
            {
                string _query = $"select vCard_id, vCard_name, vCard_PrefNumber, vCard_data,vCard_groupname, CreateDate, Modified_date from vCards where vCard_id=@id";
                return (await db.QueryAsync<vCardContainer>(_query, new { id })).FirstOrDefault();
            }
        }

        public async Task<IEnumerable<vCardContainer>> GetCards(string _usid)
        {
            using (DbConnection db = new SqlConnection(connectionString))
            {
                string _query = $"select vCard_id, vCard_name, vCard_PrefNumber, vCard_groupname, Create_date, Modified_date from vCards where vCard_usid=@_usid";
                return (await db.QueryAsync<vCardContainer>(_query, new {_usid }));
            }
        }

        public async Task<(string,string)> GetCardDetail(string usid,int _vCard_Id)
        {
            using (DbConnection db = new SqlConnection(connectionString))
            {
                string _query = $"select vCard_usid, vCard_data from vCards where vCard_id={_vCard_Id}";
                var result = (await db.QueryAsync<(string,string)>(_query)).FirstOrDefault();
                if (result.Item1 == usid)
                {
                    return result;
                }
                else throw new Exception("Запись не принадлежит пользователю.");
            }
        }

        public async Task<IEnumerable<vCardContainer>> SearchByName(string _name)
        {
            using (DbConnection db = new SqlConnection(connectionString))
            {
                string _query = $"select vCard_id, vCard_name, vCard_PrefNumber, vCard_data,vCard_groupname, CreateDate, Modified_date from vCards where vCard_name={_name}"; //возможно стоит сделать like
                return (await db.QueryAsync<vCardContainer>(_query));
            }
        }

        public async Task<bool> Update(vCardContainer CardContainer)
        {
            using (DbConnection db = new SqlConnection(connectionString))
            {
                string _query = "update vCards set vCard_name= @vCard_name, vCard_PrefNumber=@vCard_PrefNumber, vCard_data=@vCard_data, Modified_date=@Modified_date, vCardAlbum_id=@vCardAlbum_id where vCard_id = @vCard_id";
                try
                {
                    await db.ExecuteAsync(_query, CardContainer);
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
