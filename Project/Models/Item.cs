using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
  public class Item : IItem
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Usable { get; set; }

    public Item(string name, string description, bool usable = false)
    {
      Name = name;
      Description = description;
      Usable = usable;
    }
  }
}