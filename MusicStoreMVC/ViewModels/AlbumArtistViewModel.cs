using MusicStoreMVC.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicStoreMVC.ViewModels
{
    public class AlbumArtistViewModel
    {
        [Key]
        public int AlbumId { get; set; }
        public int GenreId { get; set; }
        public int ArtistId { get; set; }
        [Required]
        public string Title { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        [DataType(DataType.ImageUrl)]
        public string AlbumArtUrl { get; set; }
        public string ArtistName { get; set; }
        public string GenreName { get; set; }
        public string GenreDescription { get; set; }
        public List<Artist> Artists { get; set; }
        public List<Genre> Genres { get; set; }

    }
}
