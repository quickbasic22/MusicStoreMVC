using MusicStoreMVC.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicStoreMVC.ViewModels
{
    public class AlbumArtistViewModel
    {
        [Key]
        public virtual int AlbumId { get; set; }
        public virtual int GenreId { get; set; }
        public virtual int ArtistId { get; set; }
        [Required]
        public virtual string Title { get; set; }
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public virtual decimal Price { get; set; }
        [DataType(DataType.ImageUrl)]
        public virtual string AlbumArtUrl { get; set; }
        public virtual string ArtistName { get; set; }
        public virtual string GenreName { get; set; }
        public virtual string GenreDescription { get; set; }
       
    }
}
