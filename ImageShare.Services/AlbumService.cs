using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageShare.Core.Models;
using ImageShare.Core;
using ImageShare.Data;
using Microsoft.Extensions.Logging;

namespace ImageShare.Services
{
    public class AlbumService
    {
        private readonly ILogger<LibraryService> _logger;
        private readonly ApplicationDbContext _context;
        public AlbumService(ILogger<LibraryService> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public Library Create(AppUser owner, string title, string description, List<string> tagTexts)
        {
            Album newAlbum = new()
            {
                Created = DateTime.Now,
                Title = title,
                Description = description,
                AlbumSubscribers = new List<AlbumSubscriber>(),
                Tags = new()
            };

            newAlbum.AlbumSubscribers.Add(new AlbumSubscriber(owner, newAlbum, true, true));
            tagTexts.ForEach(t => newAlbum.Tags.Add(_context.Tags.Find(t) ?? new Tag(t)));

            _context.Libraries.Add(newAlbum);
            _context.SaveChanges();
            return newAlbum;
        }
    }
}
