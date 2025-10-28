using System;
using System.Security.AccessControl;
using System.Transactions;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using Microsoft.VisualBasic;

class Program()
{
    public static List<Player> playerList = new List<Player>();  


    static void Main(string[] args)
    {
        Player p1 = new Player("Lionel Messi", 34, "Forward");
        playerList.Add(p1);
        Player p2 = new Player("Christiano Ronaldo", 36, "Forward");
        playerList.Add(p2);
        Player p3 = new Player("Neymar Jr", 29, "Forward");
        playerList.Add(p3);
        Player p4 = new Player("Kevin De Bruyne", 30, "Midfielder");
        playerList.Add(p4);
        Player p5 = new Player("Virgil van Dijk", 30, "Defender");
        playerList.Add(p5);
        Player p6 = new Player("Mohamed Salah", 28, "Forward");
        playerList.Add(p6);
        Player p7 = new Player("Robert Lewandowski", 32, "Forward");
        playerList.Add(p7);
        Player p8 = new Player("Sadio Mané", 29, "Forward");
        playerList.Add(p8);
        Player p9 = new Player("Harry Kane", 27, "Forward");
        playerList.Add(p9);
        Player p10 = new Player("Kylian Mbappé", 22, "Forward");
        playerList.Add(p10);
        while (true)
        {
            Console.WriteLine("Welcome to the Soccer Player Management System \n ");
            Console.Write("""
                Menu:
                 1. Add a Player 
                 2. Remove a Player 
                 3. Search for a player 
                 4. Display all players 
                 5. Print player information to file 
                 6. Exit
                  Enter a choice:
                """);

            try
            {
                int answer = Convert.ToInt32(Console.ReadLine());
                switch (answer)
                {
                    case 1:
                        AddPlayer();
                        break;
                    
                    case 2:
                        RemovePlayer();
                        break;

                    case 3:
                        SearchPlayer();
                        break;

                    case 4:
                        ShowPlayers();
                        break;

                    case 5:
                        Print();
                        break;

                    case 6:
                        Exit();
                        break;

                    case <6:
                        Console.WriteLine("Invalid Input");
                        break;
                }
                
            }
            catch (FormatException) 
            {
                Console.WriteLine("Your input was not in the correct format");
            }
        }
    }

    public static void AddPlayer()
    {
       
        try
        {
            Console.WriteLine("\nEnter Player Details:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Position: ");
            string position = Console.ReadLine();
            Player playerObject = new Player(name, age, position);
            playerList.Add(playerObject);
            Console.WriteLine($"Player {name} age:{age}, position:{position} has been successfully added");
        }
        catch (Exception ex) 
        {
            Console.WriteLine("The age was not in the correct format");
            Debug.WriteLine(ex.Message);
            AddPlayer();
        }
        Thread.Sleep(1000);
    }

    static void RemovePlayer()
    {
        try
        {
            Console.WriteLine("\nEnter the name of the player to remove");
            string searchName = Console.ReadLine();
            var deletePlayer = playerList.Find(name => name.PlayerName == searchName);
            playerList.Remove(deletePlayer);
            Console.WriteLine("Player has been successfully removed.");
        }
        catch (FormatException) 
        {
            Console.WriteLine("Input was in the incorrect format");
        }
        ShowPlayers();
        Thread.Sleep(1000);

    }

    static void SearchPlayer()
    {
        try
        {
            Console.WriteLine("\nEnter the name of the player you would like to search");
            string searchName = Console.ReadLine();
            var searchPlayerName = playerList.Where(name => name.PlayerName == searchName);

            foreach (var player in searchPlayerName)
            {
                Console.WriteLine($"Name: {player.PlayerName}, Age: {player.PlayerAge}, Position: {player.PlayerPosition}\n");
                Thread.Sleep(1000);
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Input was in the incorrect format");     
        }
        Console.WriteLine("\n");
        
    }

     static void ShowPlayers()
    {
        Console.WriteLine("\nList of Players:");
        
        foreach ( var player in playerList )
        {     
            Console.WriteLine($"Name: {player.PlayerName}, Age: {player.PlayerAge}, Position: {player.PlayerPosition}");
        }
        Console.WriteLine("\n");
        Thread.Sleep(1000);
    }

    static void Print()
    {
        try
        {
            string fileName = "player_information.txt.";
            StreamWriter writer = new StreamWriter(fileName);
            writer.WriteLine("-----------Player Information-----------");
            foreach (var player in playerList)
            {
                writer.WriteLine($"{player.PlayerName}, {player.PlayerAge}, {player.PlayerPosition}");
            };


            writer.Close();
            Console.WriteLine("Information succesfully printed!");
            Process.Start("notepad.exe", fileName);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.WriteLine("\n");
        Thread.Sleep(1000);
    }

    static void Exit()
    {
        Console.WriteLine("\n");
        Console.WriteLine("Good Bye! \nThank you for using The Soccer Management System!");
        Environment.Exit(0);
    }
}

public class Player
{
    public string PlayerName = "";
    public int PlayerAge = 0;
    public string? PlayerPosition = "";


    public Player() { }

    public Player(string name, int age, string? position)
    {
        PlayerName = name;
        PlayerAge = age;
        PlayerPosition = position=string.IsNullOrWhiteSpace(position) ? "Unknown":position;
    }

}