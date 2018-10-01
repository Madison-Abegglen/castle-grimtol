using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
  public class Room : IRoom
  {
    public Room(string name, string description, bool locked = false)
    {
      Name = name;
      Description = description;
      Items = new List<Item>();
      Exits = new Dictionary<string, Room>();
      Locked = locked;
    }


    public string Name { get; set; }
    public string Description { get; set; }
    public List<Item> Items { get; set; }
    public Dictionary<string, Room> Exits { get; set; }
    public bool Locked { get; set; }

    internal void GetDescription()
    {
      System.Console.WriteLine(Description);
    }
  }
}