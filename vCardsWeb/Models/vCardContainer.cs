using System;

namespace vCardsWeb.Models
{
    public class vCardContainer
	{   /// <summary>
		/// int identity primary key not null
		/// </summary>
		public int? vCard_id { get; set; }
		/// <summary>
		/// nvarchar(50) not null, имя визитки, FN из визитки
		/// </summary>
		public string vCard_name { get; set; }
		/// <summary>
		/// Приоритетный номер из визитки
		/// </summary>
		public string vCard_PrefNumber { get; set; }
		/// <summary>
		/// nvarchar(max) not null, тело визитки переедет в mongodb
		/// </summary>
		public string vCard_data { get; set; } 
		/// <summary>
		/// Имя для группировки (работа, семья и т.д.)
		/// </summary>
		public string vCard_groupname { get; set; }
		/// <summary>
		/// Дата создания
		/// </summary>
		public DateTime Create_date { get; set; }
		/// <summary>
		/// Дата изменения
		/// </summary>
		public DateTime Modified_date { get; set; }
		/// <summary>
		/// id пользователя
		/// </summary>
		public string vCard_usid { get; set; }
		/// <summary>
		/// true-сохранить как новый, false- обновить существующий
		/// </summary>
		public bool? Created { get; set; }

	}
}
