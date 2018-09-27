using System.Collections.Generic;

namespace CastleGrimtol.Project
{
  public class Room
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public Dictionary<string, Room> NextRoomChoice { get; set; }
    public List<Item> Items = new List<Item>();

    public Room(string name, string description)
    {
      Name = name;
      Description = description;
      NextRoomChoice = new Dictionary<string, Room>();
    }

    internal void GetDescription()
    {
      System.Console.WriteLine($"You are in the {name}");
      System.Console.WriteLine($"{description}");
      return;
    }

    public void PrintNextRoomChoiceDirection()
    {
      foreach (var choice in NextRoomChoice)
      {
        System.Console.WriteLine(choice.Key);
      }
    }

  }
}