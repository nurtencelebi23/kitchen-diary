/*
    Burada kullanıcıdan alınan bilgilerle yeni tarif oluşturmak için gereken bileşenler var
*/
using System.ComponentModel.DataAnnotations;

namespace KitchenDiary.Models
{
    public class RecipeCreateViewModel
    {
        [Required(ErrorMessage = "Başlık boş bırakılamaz.")]
        public string Title { get; set; } = "";

        [Required(ErrorMessage = "Açıklama boş bırakılamaz.")]
        public string Description { get; set; } = "";

        [Required(ErrorMessage = "Hazırlama süresi girilmelidir.")]
        [Range(0, 1000, ErrorMessage = "Hazırlama süresi 0 ile 1000 dakika arasında olmalıdır.")]
        public int PrepTime { get; set; }

        [Required(ErrorMessage = "Pişirme süresi girilmelidir.")]
        [Range(0, 1000, ErrorMessage = "Pişirme süresi 0 ile 1000 dakika arasında olmalıdır.")]
        public int CookTime { get; set; }

        [Required(ErrorMessage = "Porsiyon sayısı girilmelidir.")]
        [Range(1, 100, ErrorMessage = "Porsiyon 1 ile 100 arasında olmalıdır.")]
        public int Servings { get; set; }

        [Required(ErrorMessage = "Lütfen bir kategori seçin.")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "En az bir malzeme girilmelidir.")]
        public string IngredientsText { get; set; } = "";

        [Required(ErrorMessage = "En az bir hazırlanış adımı girilmelidir.")]
        public string StepsText { get; set; } = "";
    }
}