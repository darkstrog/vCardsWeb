using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vCardsWeb.Models.Repository
{
    public interface IvCardsRepository
    {
        Task<bool> Create(vCardContainer CardContainer);
        Task<bool> Delete(int id);
        Task<vCardContainer> GetById(int id);
        Task<(string, string)> GetCardDetail(string usid, int _vCard_Id);
        Task<IEnumerable<vCardContainer>> GetCards(string usid);
        Task<IEnumerable<vCardContainer>> SearchByName(string name);
        Task<bool> Update(vCardContainer CardContainer);
    }
}
