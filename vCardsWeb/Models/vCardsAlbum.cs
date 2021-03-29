namespace vCardsWeb.Models
{
    public class vCardsAlbum
    {
        public int vCardsAlbum_id { get; set; } /**id записи в базе**/
        public string album_id { get; set; } /**guid альбома**/
        public string album_usid { get; set; } /**id пользователя**/
        public string album_name { get; set; } /** nvarchar(30) not null default('без названия') имя альбома визиток**/
        public string album_description { get; set; }/**Описание при необходимости**/
    }
}
