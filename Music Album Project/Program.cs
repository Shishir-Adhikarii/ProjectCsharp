/* 
    Program.cs
    Author: Shishir Adhikari
    Date: 2024
    Description: 
        This console application allows users to create music albums as objects.
        Users can define album details, including name, artist, year, tracks, 
        calculate total durations, and optionally save albums to a file.

    References:
        - W3Schools C# Tutorial: https://www.w3schools.com/cs/
        - .NET Documentation: https://learn.microsoft.com/en-us/dotnet/
        - Bro Code YouTube Channel: https://youtu.be/wxznTygnRfQ?si=7neYJp--ofDAL-IH
*/

using System; // For basic console operations like reading and writing.
using System.Collections.Generic; // To use List<T> collections for storing album tracks and durations.
using System.IO; // For handling file input/output operations (saving album details to a file).
using System.Text.RegularExpressions; // For validating track durations in mm:ss format.

namespace MusicAlbumApp // Namespace to encapsulate album-related logic.
{
    class Program // Main class containing the entry point of the application.
    {
        static void Main(string[] args) // Entry point of the application.
        {
            // Predefined album details for display.
            List<string> tracks1 = new List<string> { "Without Me", "Cleanin' Out My Closet", "Superman" };
            List<string> durations1 = new List<string> { "4:50", "4:58", "5:46" };
            Album album1 = new Album("The Eminem Show", "Eminem", 2002, tracks1, durations1);
            album1.DisplayAlbumDetails(); // Display album details.

            List<string> tracks2 = new List<string> { "Not Afraid", "Love The Way You Lie", "No Love" };
            List<string> durations2 = new List<string> { "4:08", "4:23", "5:09" };
            Album album2 = new Album("Recovery", "Eminem", 2010, tracks2, durations2);
            album2.DisplayAlbumDetails(); // Display second album details.

            List<string> tracks3 = new List<string> { "The Real Slim Shady", "Stan", "Kim" };
            List<string> durations3 = new List<string> { "4:44", "6:44", "6:30" };
            Album album3 = new Album("The Marshall Mathers LP", "Eminem", 2000, tracks3, durations3);
            album3.DisplayAlbumDetails(); // Display third album details.

            // Allow user to create a custom album.
            Console.WriteLine("Let's create your own album!");
            Console.Write("Enter the album name: ");
            string albumName = Console.ReadLine(); // Read album name from user input.

            Console.Write("Enter the artist's name: ");
            string artistName = Console.ReadLine(); // Read artist name from user input.

            // Enhanced year input with validation.
            int releaseYear;
            while (true)
            {
                Console.Write("Enter the year of release: ");
                string input = Console.ReadLine(); // Read year input.
                if (!string.IsNullOrEmpty(input) && int.TryParse(input, out releaseYear)) // Validate integer input.
                {
                    break; // Exit loop if valid year is entered.
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid year."); // Display error if invalid input.
                }
            }

            // Initialize lists to store user-defined tracks and durations.
            List<string> customTracks = new List<string>();
            List<string> customDurations = new List<string>();

            // Collect song tracks from the user.
            Console.WriteLine("Enter song tracks (type 'done' to finish):");
            while (true)
            {
                Console.Write("Enter track name: ");
                string trackName = Console.ReadLine(); // Read track name.
                if (string.IsNullOrEmpty(trackName) || trackName.ToLower() == "done") break; // Exit loop if user types 'done' or empty input.
                customTracks.Add(trackName); // Add track to the list.
            }

            // Collect track durations for the entered tracks.
            Console.WriteLine("Enter track durations in the format mm:ss:");
            foreach (var track in customTracks)
            {
                string trackDuration;
                bool isValidDuration;
                do
                {
                    Console.Write($"Enter duration for track '{track}': ");
                    trackDuration = Console.ReadLine(); // Read track duration.
                    isValidDuration = !string.IsNullOrEmpty(trackDuration) && Regex.IsMatch(trackDuration, @"^\d{1,2}:\d{2}$"); // Validate mm:ss format.
                    if (!isValidDuration)
                    {
                        Console.WriteLine("Invalid duration format. Please use mm:ss."); // Display error if format is incorrect.
                    }
                } while (!isValidDuration);

                customDurations.Add(trackDuration); // Add valid duration to the list.
            }

            // Create a custom album object and display its details.
            Album customAlbum = new Album(albumName, artistName, releaseYear, customTracks, customDurations);
            customAlbum.DisplayAlbumDetails(); // Display details of the custom album.

            // Ask user if they want to save the custom album to a file.
            Console.Write("Do you want to save your album to a file? (y/n): ");
            string saveChoice = Console.ReadLine();
            if (saveChoice.ToLower() == "y")
            {
                customAlbum.SaveAlbumToFile(); // Save album details to a file if user chooses 'yes'.
            }

            // Keep the console open for the user to view results.
            Console.ReadLine();
        }
    }
}