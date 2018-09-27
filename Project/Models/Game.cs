using System;

namespace CastleGrimtol.Models
{
  public class Game
  {
    bool playing = false;
    Target _currentTarget;
    Player player;

    public void StartGame()
    {
      Setup();
      while (playing)
      {
        GetUserInput();
      }
      Console.Clear();
      System.Console.WriteLine("You've reached your final destination. This is the end. Or.. the beginning?");
      Console.Sleep(4000);
    }
    void Setup()
    {
      playing = true;
      // rooms
      Room jailCell = new Room("jail cell",
      "You stand in the jail cell, where there is some hay to the west of you, assumingly for sleeping. To the east of you, theres a shabby old barrel. In front of you, a barred door that leads to a hallway lined with cobblestone.");
      Room hallway = new Room("hallway",
      "It's a short hallway lined with cobblestone, dimly lit by wall sconces holding blazing torches. Theres an open archway leading to a room at the very north of you.");
      Room storage = new Room("storage room",
      "You stand in a storage room, where there is a large sturdy door to the west of you, with a very big lock secured on it. Theres some shabby old barrels collected in the northeast corner of the room, and on the east wall, theres a small archway with a height that reaches only halfway up the wall, barred by crusty, rusting old bars you could easily break with a swift kick. It seems like a sewege entrance, and the small tunnel behind it slopes downwards into darkness. It produces an upleasant smell.");
      Room sewer = new Room("sewer",
      "Sliding down, you splash into a circular room with a cascading ceiling, the walls are lined with barred circular entrances assumingly leading to other sewage tunnels. A ladder on the north wall directly in front of you leads upwards and to a wooden hatch that emits dim light from the cracks of it's wood. But what awaits between you and freedom is an abnormally large and grotesque sewage rat the size of a great dane. Its beady eyes glare at you, and it screeches loudly. Theres large and sharp, jagged yellow teeth protruding from its foaming mouth, where a mysterious dark ooze drips from.")

      // items
      var bat = new Item("Lucille", 580);
      var saber = new Item("A mysterious device", 1000);
      var monkeyFist = new Item("Monkey Fist", 59);

      // asigning items to targets
      joe.Items.Add(saber);
      moe.Items.Add(bat);
      moe.Items.Add(monkeyFist);

      // relationships


    }
    private void GetUserInput()
    {
      System.Console.WriteLine("What do you wanna do?");
      string input = Console.ReadLine();
      input = input.ToLower();
      switch (input)
      {
        case "quit":
          playing = false;
          break;


      }



    }

  }
}