/*
    Album.cs
    Author: Shishir Adhikari
    Date: 2024
    Description:
        This file defines the Album class, representing music albums with properties 
        (name, artist, year, tracks, durations) and methods to display album details 
        and save album data to a file.
*/

using System; // For basic console operations.
using System.Collections.Generic; // For generic collections like List<T>.
using System.IO; // For file operations like saving data to a file.

namespace MusicAlbumApp // Encapsulation of album-related logic.
{
    public class Album
    {
        // Properties of the album.
        public string Name { get; set; }
        public string Artist { get; set; }
        public int Year { get; set; }
        public List<string> Tracks { get; set; }
        public List<string> Durations { get; set; }

        // Constructor to initialize album details.
        public Album(string name, string artist, int year, List<string> tracks, List<string> durations)
        {
            Name = name;
            Artist = artist;
            Year = year;
            Tracks = tracks;
            Durations = durations;
        }

        // Method: DisplayAlbumDetails
        // Purpose: Displays album details including name, artist, year, tracks, and total duration.
        public void DisplayAlbumDetails()
        {
            Console.WriteLine($"Album Name: {Name}");
            Console.WriteLine($"Artist: {Artist}");
            Console.WriteLine($"Year of Release: {Year}");
            Console.WriteLine("Tracks:");

            int totalMinutes = 0;
            int totalSeconds = 0;

            // Loop through tracks and calculate total duration.
            for (int i = 0; i < Tracks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Tracks[i]} - Duration: {Durations[i]}");

                // Parse and add track durations.
                try
                {
                    string[] timeParts = Durations[i].Split(':'); // Split duration into minutes and seconds.
                    int minutes = int.Parse(timeParts[0]);
                    int seconds = int.Parse(timeParts[1]);

                    totalMinutes += minutes;
                    totalSeconds += seconds;

                    // Adjust for seconds exceeding 60.
                    if (totalSeconds >= 60)
                    {
                        totalMinutes += totalSeconds / 60;
                        totalSeconds = totalSeconds % 60;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid duration format. Please use mm:ss."); // Handle invalid duration format.
                }
            }

            Console.WriteLine($"Total Duration: {totalMinutes} minutes and {totalSeconds} seconds.");
        }

        // Method: SaveAlbumToFile
        // Purpose: Saves album details to a file named after the album.
        public void SaveAlbumToFile()
        {
            string albumData = $"Album: {Name}, Artist: {Artist}, Year: {Year}\n";
            for (int i = 0; i < Tracks.Count; i++)
            {
                albumData += $"{Tracks[i]} - {Durations[i]}\n"; // Append track details to the data.
            }

            try
            {
                File.WriteAllText($"{Name}_album.txt", albumData); // Save album data to file.
                Console.WriteLine("Album details saved to file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving the album: {ex.Message}"); // Handle file errors.
            }
        }
    }
}