namespace MusicHub;

using System;
using System.Text;
using Data;
using Initializer;
using MusicHub.Data.Models;

public class StartUp
{
    public static void Main()
    {
        MusicHubDbContext context =
            new MusicHubDbContext();

        DbInitializer.ResetDatabase(context);

        Console.WriteLine("Write Producer ID");
        int producerId = int.Parse(Console.ReadLine());

        Console.WriteLine(ExportAlbumsInfo(context, producerId));
    }

    public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
    {
        StringBuilder sb = new StringBuilder();
        using (context)
        {
            var albums = context.Albums
                .Where(a => a.ProducerId == producerId)
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate,
                    ProducerName = a.Producer.Name,
                    Price = a.Price,
                    Songs = a.Songs
                                   .Select(s => new
                                   {
                                       SongName = s.Name,
                                       Price = s.Price,
                                       WriterName = s.Writer.Name
                                   }).ToArray()
                })
                .ToArray();

            foreach (var album in albums.OrderByDescending(a => a.Price))
            {
                sb.AppendLine("- - - - - - - - - - - - - - - - - -");
                sb.AppendLine($"-AlbumName: {album.AlbumName}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate.ToString("M/d/yyyy")}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine($"-Songs:");

                int counter = 1;

                foreach (var song in album.Songs
                                                .OrderByDescending(s => s.SongName)
                                                .ThenBy(s => s.WriterName))
                {
                    sb.AppendLine($"---#{counter++}");
                    sb.AppendLine($"---SongName: {song.SongName}");
                    sb.AppendLine($"---Price: {song.Price:F2}");
                    sb.AppendLine($"---Writer: {song.WriterName}");
                }

                sb.AppendLine($"-AlbumPrice: {album.Price:F2}");
            }
        }

        return sb.ToString().Trim();
    }

    public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
    {
        throw new NotImplementedException();
    }
}

