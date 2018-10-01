using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
  public class Room : IRoom
  {
    string Name { get; set; }
    string Description { get; set; }
    List<Item> Items { get; set; }
    Dictionary<string, IRoom> Exits { get; set; }
  }
}