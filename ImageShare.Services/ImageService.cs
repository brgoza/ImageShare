using Azure;
using Azure.Storage.Blobs;
using ImageShare.Core;
using ImageShare.Data;
using Microsoft.Extensions.Logging;

namespace ImageShare.Services;

public class ImageService
{
    private readonly ILogger<ImageService> _logger;
    private readonly BlobServiceClient _blobServiceClient;
    private readonly ApplicationDbContext _context;
    public ImageService(ILogger<ImageService> logger, BlobServiceClient blobClient, ApplicationDbContext context)
    {
        _logger = logger;
        _blobServiceClient = blobClient;
        _context = context;
    }

    public async Task<Image> UploadAsync(Image image, Stream stream)
    {
        image.BlobName = GenerateBlobName();
        var blobClient =
            _blobServiceClient.GetBlobContainerClient("images")
            .GetBlobClient(image.BlobName);
        try
        {
            await blobClient.UploadAsync(stream);
            image.Url = blobClient.Uri.ToString();
            _logger.LogInformation("Successfully Uploaded:\t{title}\nBlobName:\t{blobname}\nUrl:\t{url}",
                image.Title, image.BlobName, image.Url);

            return image;
        }
        catch (RequestFailedException ex)
        {
            _logger.LogError(ex, "{msg}", ex.Message);
            throw;
        }
    }

    public async Task<Image> AddAsync(Image image, Library library, Album? album)
    {
        image.Libraries = new List<Library>() { library };
        if (album != null) image.Albums = new List<Album>() { album };
        await _context.Images.AddAsync(image);
        try
        {
            await _context.SaveChangesAsync();
            return image;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{msg}", ex.Message);
            throw;
        }
    }

    public static string GenerateBlobName() =>
                   Convert.ToBase64String(Guid.NewGuid().ToByteArray())[..22]
                       .Replace("/", "_").Replace("+", "-");

}