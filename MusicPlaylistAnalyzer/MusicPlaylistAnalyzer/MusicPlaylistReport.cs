using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MusicPlaylistAnalyzer
{
    public static class MusicPlaylistReport
    {
        public static string GenerateText(List<MusicPlaylistInfo> musicPlaylistList)
        {
            string report = "Music Playlist Report\n\n";

            if (musicPlaylistList.Count() < 1)
            {
                report += "No data is available.\n";

                return report;
            }

            report += "Songs that recieved 200 or more plays: \n";
            var records = from musicInfo in musicPlaylistList where musicInfo.Plays > 200 select musicInfo;
            if (records.Count() > 0)
            {
                foreach (var record in records)
                {
                    report += "Name: " + record.Name + ", Artist: " + record.Artist +  ", Album: " + record.Album + ", Genre: " + record.Genre + ", Size: " + record.Size + ", Time: " + record.Time + ", Year: " + record.Year + ", Plays: " + record.Plays + "\n";
                }
                report.TrimEnd('\t');
                report += "\n";
            }
            else
            {
                report += "not available\n\n";
            }

            report += "Number of Alternative songs: ";
            var altCount = from musicInfo in musicPlaylistList where musicInfo.Genre == "Alternative" select musicInfo.Name;
            if (altCount.Count() > 0)
            {
                report += altCount.Count() + "\n\n";

                report.TrimEnd('\t');
                report += "\n";
            }
            else
            {
                report += "not available\n\n";
            }

            report += "Number of Hip-Hop/Rap songs: ";
            var rapCount = from musicInfo in musicPlaylistList where musicInfo.Genre == "Hip-Hop/Rap" select musicInfo.Name;
            if (rapCount.Count() > 0)
            {
                report += rapCount.Count() + "\n\n";

                report.TrimEnd('\t');
                report += "\n";
            }
            else
            {
                report += "not available\n\n";
            }

            report += "Songs from the album Welcome to the Fishbowl: \n";
            var fishbowl = from musicInfo in musicPlaylistList where musicInfo.Album == "Welcome to the Fishbowl" select musicInfo;
            if (fishbowl.Count() > 0)
            {
                foreach (var fishbowlInfo in fishbowl)
                {
                    report += "Name: " + fishbowlInfo.Name + ", Artist: " + fishbowlInfo.Artist + ", Album: " + fishbowlInfo.Album + ", Genre: " + fishbowlInfo.Genre + ", Size: " + fishbowlInfo.Size + ", Time: " + fishbowlInfo.Time + ", Year: " + fishbowlInfo.Year + ", Plays: " + fishbowlInfo.Plays + "\n";
                }
                report.TrimEnd('\t');
                report += "\n";
            }
            else
            {
                report += "not available\n\n";
            }

            report += "Songs from before 1970: \n";
            var oldies = from musicInfo in musicPlaylistList where musicInfo.Year < 1970 select musicInfo;
            if (oldies.Count() > 0)
            {
                foreach (var oldie in oldies)
                {
                    report += "Name: " + oldie.Name + ", Artist: " + oldie.Artist + ", Album: " + oldie.Album + ", Genre: " + oldie.Genre + ", Size: " + oldie.Size + ", Time: " + oldie.Time + ", Year: " + oldie.Year + ", Plays: " + oldie.Plays + "\n";
                }
                report.TrimEnd('\t');
                report += "\n";
            }
            else
            {
                report += "not available\n\n";
            }

            report += "Song names longer than 85 characters: \n";
            var titles = from musicInfo in musicPlaylistList where musicInfo.Name.Length > 85 select musicInfo;
            if (titles.Count() > 0)
            {
                foreach (var title in titles)
                {
                    report += title.Name + "\n";
                }
                report.TrimEnd('\t');
                report += "\n";
            }
            else
            {
                report += "not available\n\n";
            }

            report += "Longest song: \n";
            var mostTime = from musicInfo in musicPlaylistList where musicInfo.Time == ((from info in musicPlaylistList select info.Time).Max()) select musicInfo.Name;
            if (mostTime.Count() > 0)
            {
                report += "Name: " + mostTime.First();
            }
            else
            {
                report += "not available\n";
            }

            var mostTimeArtist = from musicInfo in musicPlaylistList where musicInfo.Time == ((from info in musicPlaylistList select info.Time).Max()) select musicInfo.Artist;
            report += ", Artist: " + mostTimeArtist.First();

            var mostTimeAlbum = from musicInfo in musicPlaylistList where musicInfo.Time == ((from info in musicPlaylistList select info.Time).Max()) select musicInfo.Album;
            report += ", Album: " + mostTimeAlbum.First();

            var mostTimeGenre = from musicInfo in musicPlaylistList where musicInfo.Time == ((from info in musicPlaylistList select info.Time).Max()) select musicInfo.Genre;
            report += ", Genre: " + mostTimeGenre.First();

            var mostTimeSize = from musicInfo in musicPlaylistList where musicInfo.Time == ((from info in musicPlaylistList select info.Time).Max()) select musicInfo.Size;
            report += ", Size: " + mostTimeSize.First();

            var mostTimeTime = from musicInfo in musicPlaylistList where musicInfo.Time == ((from info in musicPlaylistList select info.Time).Max()) select musicInfo.Time;
            report += ", Time: " + mostTimeTime.First();

            var mostTimeYear = from musicInfo in musicPlaylistList where musicInfo.Time == ((from info in musicPlaylistList select info.Time).Max()) select musicInfo.Year;
            report += ", Year: " + mostTimeYear.First();

            var mostTimePlays = from musicInfo in musicPlaylistList where musicInfo.Time == ((from info in musicPlaylistList select info.Time).Max()) select musicInfo.Plays;
            report += ", Plays: " + mostTimePlays.First();

            return report;
        }
    }
}