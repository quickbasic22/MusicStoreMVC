using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicStoreMVC.Models;
using MusicStoreMVC.ViewModels;

namespace MusicStoreMVC.Data
{
    public class MusicStoreMVCContext : DbContext
    {
        public MusicStoreMVCContext (DbContextOptions<MusicStoreMVCContext> options)
            : base(options)
        {
        }

        public DbSet<MusicStoreMVC.Models.Album> Album { get; set; } = default!;

        public DbSet<MusicStoreMVC.Models.Artist>? Artist { get; set; }

        public DbSet<MusicStoreMVC.Models.Genre>? Genre { get; set; }

        public DbSet<MusicStoreMVC.ViewModels.AlbumArtistViewModel>? AlbumArtistViewModel { get; set; }
    }
}
