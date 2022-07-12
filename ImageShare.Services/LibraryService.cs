using ImageShare.Core;
using ImageShare.Core.Models;
using ImageShare.Data;
using Microsoft.Extensions.Logging;

namespace ImageShare.Services
{
    public class LibraryService
    {
        private readonly ILogger<LibraryService> _logger;
        private readonly ApplicationDbContext _context;
        public LibraryService(ILogger<LibraryService> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public Library? GetById(Guid libraryId)
        {
            return _context.Libraries.Find(libraryId);
        }

        public Library Create(AppUser owner, string title, string description, List<string> tagTexts)
        {
            Library newLib = new Library
            {
                Created = DateTime.Now,
                Title = title,
                Description = description,
                LibrarySubscribers = new(),
                Tags = new()
            };

            newLib.LibrarySubscribers.Add(new LibrarySubscriber(owner, newLib, true, true));
            tagTexts.ForEach(t => newLib.Tags.Add(_context.Tags.Find(t) ?? new Tag(t)));

            _context.Libraries.Add(newLib);
            _context.SaveChanges();
            return newLib;
        }
    }
}
