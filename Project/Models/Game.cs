using System;
using System.Collections.Generic;
using CastleGrimtol.Interfaces;
using CastleGrimtol.Models;

namespace CastleGrimtol.Project
{
  public class Game : IGame
  {
    public bool playing = false;
    public Room CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }
    public bool win = false;
    public bool lose = false;
    public void StartGame()
    {
      Setup();
      while (playing)
      {
        GetUserInput();
      }
    }

    void Setup()
    {
      // CREATE ROOMS 
      Room jailcell = new Room("JailCell", "You wake in a musky jail cell with brick walls to the left and right of you, and a cobblestone floor beneath. You're lying in a bed of straw and hay. Underneath you is something sharp, and upon examination it seems to be an odd tool for lock picking. In front of you and directly north, there's a barred door with a locked handle securing you in this confined space.");

      Room hallway = new Room("Hallway", "You enter a long hallway with only one exit at the very north end. It's dimly lit by a wall sconce holding a wooden torch, and there's no door in the archway that is the entrance to what appears to be a storage room.");

      Room storageroom = new Room("Storage Room", "Stepping through the archway, you stand on a wooden floor. To the west, a large and sturdy door with a locked handle. To the north, a small stool is placed next to a barrel with a shining short sword struck through the top of it. It could have possibly belonged to whoever was watching you, but there is no one else in the room. To the east, there is a sewage tunnel with rusted bars, which would likely break if were to breathe at them the wrong way.");

      Room sewer = new Room("Sewer", "You splash into a lightly flooded circular room with a cascading ceiling, where a soft light leaks through a wooden hatch. Leading to it, is an old metal ladder, where at the bottom waits a feral, grungy rat. It screeches at you from it's perch, which happens to be a jewel encrusted crystal skull. You jump, but lucky for you, the sudden movement causes it to skimper off and squeeze itself through a crack in the brick wall.");

      // GIVE ROOMS EXITS
      jailcell.Exits.Add("hallway", hallway);
      hallway.Exits.Add("storageroom", storage);
      storageroom.Exits.Add("Sewer", sewer);

      // CREATE ITEMS FOR ROOMS
      jailcell.Items.Add("lockpick", "an oddly shaped metal tool and bobbypin.");
      hallway.Items.Add("torch", "a flaming wooden torch. Very hot, very bright.");
      storageroom.Items.Add("shortsword", "a gleaming shortsword, a little dull but still a good form of defense.");
      sewer.Items.Add("skull", "a crystal skull adorned with precious gems, it's mouth grins at you with diamonds and it's eyes gleam with rubies.");

      // YOUR CURRENT POSITION
      CurrentRoom = jailcell;

      // CREATE PLAYER
      Console.Clear();
      System.Console.WriteLine("What do you call yourself?");
      var name = Console.ReadLine();
      CurrentPlayer = new Player(name);

    }

    public void GetUserInput()
    {
      CurrentRoom.GetDescription();
      System.Console.WriteLine("What's your next move?");
      string input = Console.ReadLine().ToLower();

      switch (input)
      {
        case "quit":
          Quit();
          break;
        case "help":
          Help();
          break;
        case "inventory":
          Inventory();
          break;
        case "reset":
          Reset();
          break;
        case "look":
          Look();
          break;
        case "take":
          TakeItem(input);
          break;
        case "go":
          Go();
          break;
        case "use":
          UseItem();
          break;
        default:
          System.Console.WriteLine("It's unclear what you're trying to do...");
          break;
      }

      // QUIT GAME
      void Quit()
      {
        playing = false;
        return;
      }

      // TAKE AN ITEM
      void TakeItem(string itemName)
      {
        if (CurrentRoom.Items[itemName])
        {
          System.Console.WriteLine($"You pick up the {CurrentRoom.Items[itemName].Name}. It is {CurrentRoom.Items[itemName].Description}");
          CurrentPlayer.Inventory.Add(CurrentRoom.Items[itemName].Name);
          CurrentRoom.Items.Remove(CurrentRoom.Items[itemName].Name);
        }
        return;
      }

      void UseItem(string itemName)
      {
        if (CurrentPlayer.Inventory.Count >= 1)
        {
          System.Console.WriteLine("Your Inventory:\n");
          foreach (KeyValuePair<string, Item> item in CurrentPlayer.Inventory)
          {
            System.Console.WriteLine($"{item.Name}");
            System.Console.WriteLine($"{item.Description}");
          }
        }
        return;
      }

      void Help()
      {
        System.Console.WriteLine("Game Instructions and Commands: \n");
        System.Console.WriteLine("Enter 'Help' to display these instructions. \n");
        System.Console.WriteLine("Enter 'Inventory' to display your current inventory. \n");
        System.Console.WriteLine("Enter 'Go' + any correct direction to go there, like 'go east' \n");
        System.Console.WriteLine("Enter 'Use' + any existing item within your inventory to use that item.");
        System.Console.WriteLine("Enter 'Quit' to quit the game.");
        System.Console.WriteLine("Enter 'Reset' to reset the game.");
        return;
      }

      void Reset()
      {
        playing = false;
        var g = new Game();
        g.StartGame();
      }

      void Look()
      {
        System.Console.WriteLine($"{CurrentRoom.Description}");
        return;
      }
    }


  }
}