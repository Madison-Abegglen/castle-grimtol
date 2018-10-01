using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
  public class Game : IGame
  {
    public bool playing = false;
    public Room CurrentRoom { get; set; }
    public Player CurrentPlayer { get; set; }

    public void StartGame()
    {
      Setup();
      CurrentRoom.GetDescription();

      while (playing)
      {
        GetUserInput();
      }
    }

    public void Setup()
    {
      playing = true;
      // CREATE ROOMS  
      Room jailcell = new Room("JailCell", "You are in a musky jail cell with brick walls to the left and right of you, and a cobblestone floor beneath. You're lying in a bed of straw and hay. Underneath you is something sharp, and upon examination it seems to be an odd tool for lock picking. In front of you and directly north, there's a barred door with a locked handle securing you in this confined space.", true);

      Room hallway = new Room("Hallway", "You enter a long hallway with only one exit at the very north end. It's dimly lit by a wall sconce holding a wooden torch, and there's no door in the archway that is the entrance to what appears to be a storage room.");

      Room storageroom = new Room("Storage Room", "Stepping through the archway, you stand on a wooden floor. To the west, a large and sturdy door with a locked handle. A shortsword is planted in the top of the barrel. There is no one else in the room. To the east, there is a sewage tunnel with rusted, broken bars. It makes the entrance to the tunnel look like a gaping mouth with chipped and rotted teeth.");

      Room sewer = new Room("Sewer", "You splash into a lightly flooded circular room with a cascading ceiling, where a soft light leaks through a wooden hatch. Leading to it and directly east of you, is an old metal ladder, where at the bottom waits a feral, grungy rat. It screeches at you from it's perch, which happens to be a jewel encrusted crystal skull. You jump, but lucky for you, the sudden movement causes it to skimper off and squeeze itself through a crack in the brick wall.");

      Room hatch = new Room("hatch", "You climb the ladder and bust through the hatch. You're engulfed in sunlight and have escaped your captors.");

      // GIVE ROOMS EXITS
      jailcell.Exits.Add("north", hallway);
      hallway.Exits.Add("north", storageroom);
      hallway.Exits.Add("south", jailcell);
      storageroom.Exits.Add("east", sewer);
      storageroom.Exits.Add("south", hallway);
      sewer.Exits.Add("east", hatch);

      // CREATE ITEMS FOR ROOMS
      var lockpick = new Item("lockpick", "an oddly shaped metal tool and bobbypin.", true);
      jailcell.Items.Add(lockpick);
      var skull = new Item("skull", "a crystal skull adorned with precious gems, it's mouth grins at you with diamonds and it's eyes gleam with rubies. This is most definitely worth a fortune in the market. Or would make a nice paperweight. I won't judge you.");
      sewer.Items.Add(skull);
      var shortsword = new Item("shortsword", "a gleaming shortsword");
      storageroom.Items.Add(shortsword);

      // YOUR CURRENT POSITION
      CurrentRoom = jailcell;

      // CREATE PLAYER
      Console.Clear();
      System.Console.WriteLine("What do you call yourself?");
      var name = Console.ReadLine();
      CurrentPlayer = new Player(name);
      System.Console.WriteLine($"Hello {name}. Welcome to your journey. It all begins when...");

    }

    public void GetUserInput()
    {
      if (CurrentRoom.Name == "hatch")
      {
        System.Console.WriteLine("You've reached the end of your journey. Or maybe.. began another?");
        playing = false;
        return;
      }
      System.Console.Write(" What's your next move? > ");
      string input = Console.ReadLine().ToLower();
      var inputArr = input.Split(" ");

      switch (inputArr[0])
      {
        case "quit":
          Quit();
          break;
        case "help":
          System.Console.WriteLine("\n");
          Help();
          break;
        case "inventory":
          System.Console.WriteLine("\n");
          Inventory();
          break;
        case "reset":
          System.Console.WriteLine("\n");
          Reset();
          break;
        case "look":
          System.Console.WriteLine("\n");
          Look();
          break;
        case "take":
          System.Console.WriteLine("\n");
          TakeItem(inputArr[1]);
          break;
        case "go":
          System.Console.WriteLine("\n");
          Go(inputArr[1]);
          break;
        case "use":
          System.Console.WriteLine("\n");
          UseItem(inputArr[1]);
          break;
        default:
          System.Console.WriteLine("\n");
          System.Console.WriteLine("It's unclear what you're trying to do...");
          break;
      }
    }

    public void Go(string direction)
    {
      if (CurrentRoom.Locked == true)
      {
        System.Console.WriteLine("The exit is locked. I'd recommend you figure that out.");
        return;
      }
      if (CurrentRoom.Exits.ContainsKey(direction))
      {
        CurrentRoom = CurrentRoom.Exits[direction];
        CurrentRoom.GetDescription();
        return;
      }
      System.Console.WriteLine("It appears you tried going that way, but then had a radical moment of disphoria. You blink and you're in the exact position you were at before you tried going the apparently wrong way.");
    }

    // QUIT GAME
    public void Quit()
    {
      playing = false;
    }

    // TAKE AN ITEM
    public void TakeItem(string itemName)
    {
      var foundItem = CurrentRoom.Items.Find(i => i.Name == itemName);

      if (foundItem.Name == "shortsword")
      {
        System.Console.WriteLine("You attempt to free the blade from the barrel, however your had slips halfway through your efforts and the blade spins from your hands and into your chest. Looks like thats gonna be a little more than just a flesh wound...");
        System.Console.WriteLine("You most certainly bleed out, you clumsy fool. This ends your journey.");
        System.Console.WriteLine("The end.");
        playing = false;
        return;
      }

      if (CurrentRoom.Items.Count > 0)
      {
        CurrentRoom.Items.Remove(foundItem);
        CurrentPlayer.Inventory.Add(foundItem);
        System.Console.WriteLine($"You took a {foundItem.Name}. It is {foundItem.Description} ");
      }
    }

    public void UseItem(string itemName)
    {
      if (CurrentPlayer.Inventory.Count >= 1)
      {
        var foundItem = CurrentPlayer.Inventory.Find(i => i.Name == itemName);
        if (foundItem.Name == "lockpick")
        {
          CurrentRoom.Locked = false;
          CurrentPlayer.Inventory.Remove(foundItem);
          System.Console.WriteLine("You pick the lock with a snap at the expense of your tool. Unfortunately, it appears to have had a one-time-use lifespan. However, the door opens.");
          return;
        }
        System.Console.WriteLine($"The {foundItem.Name} looks pretty neat. However, it's not of much use.");
      }
    }

    public void Help()
    {
      System.Console.WriteLine("Game Instructions and Commands: \n");
      System.Console.WriteLine("Enter 'Help' to display these instructions. \n");
      System.Console.WriteLine("Enter 'Inventory' to display your current inventory. \n");
      System.Console.WriteLine("Enter 'Go' + any correct direction to go there, like 'go east' \n");
      System.Console.WriteLine("Enter 'Use' + any existing item within your inventory to use that item. \n");
      System.Console.WriteLine("Enter 'Quit' to quit the game. \n");
      System.Console.WriteLine("Enter 'Reset' to reset the game. \n");
      return;
    }

    public void Reset()
    {
      Setup();
      CurrentRoom.GetDescription();
    }

    public void Look()
    {
      System.Console.WriteLine($"{CurrentRoom.Description}");
      return;
    }

    public void Inventory()
    {
      foreach (var item in CurrentPlayer.Inventory)
      {
        System.Console.Write($"{item.Name}: {item.Description}");
      }
    }
  }
}