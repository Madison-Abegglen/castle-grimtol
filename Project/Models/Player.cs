using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
  public class Player : IPlayer
  {
    string PlayerName { get; set; }
    List<Item> Inventory { get; set; }
  }
}