namespace MusicHub;

using System;
using System.Diagnostics.Metrics;
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

        Console.WriteLine("Write Song Duration ");
        int duration = int.Parse(Console.ReadLine());

        Console.WriteLine(ExportSongsAboveDuration(context, duration));
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
        StringBuilder sb = new StringBuilder();

        using (context)
        {
            var songs = context.Songs
                .Where(s => s.Duration > TimeSpan.FromMinutes(duration))
                .Select(s => new
                {
                    SongName = s.Name,
                    WriterName = s.Writer.Name,
                    SongPerformers = s.SongPerformers,
                    ProducerName = s.Album.Producer.Name,
                    Duration = s.Duration.ToString("c")
                })
                .ToArray();

            int counter = 1;

            foreach (var song in songs
                                      .OrderBy(s => s.SongName)
                                      .ThenBy(s => s.WriterName))

            {

                sb.AppendLine("- - - - - - - - - - - - - - - - - -");
                sb.AppendLine($"-Song #{counter++}");
                sb.AppendLine($"---SongName: {song.SongName}");
                sb.AppendLine($"---Writer: {song.WriterName}");

                if (song.SongPerformers.Count == 1)
                {
                    string firstName = song.SongPerformers.FirstOrDefault().Performer.FirstName;
                    string lastName = song.SongPerformers.FirstOrDefault().Performer.LastName;

                    sb.AppendLine($"---Performer: {firstName} {lastName}");
                }
                else if (song.SongPerformers.Count > 1)
                {
                    sb.AppendLine("---Performers:");

                    foreach (var sp in song.SongPerformers.OrderBy(p => p.Performer.FirstName))
                    {
                        string firstName = sp.Performer.FirstName;
                        string lastName = sp.Performer.FirstName;

                        sb.AppendLine($"{firstName} {lastName}");
                    }
                }

                sb.AppendLine($"---AlbumProducer: {song.ProducerName}");
                sb.AppendLine($"---Duration: {song.Duration}");
            }

        }
        return sb.ToString().Trim();

    }
}

