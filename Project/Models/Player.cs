namespace CastleGrimtol.Models
{
  public class Player
  {
    // player attributes
    int BaseStrength = 1;
    public int Damage { get => Weapon.Damage + BaseStrength; }
    public string Name { get; set; }
    public Item Weapon { get; private set; } = new Item("Fist", 1);

    // your functions
    public void GiveWeapon(Item item)
    {
      if (Weapon == null)
      {
        Weapon = item;
        return;
      }

      if (Weapon.Damage < item.Damage)
      {
        System.Console.Write("Are you sure you want to switch weapons? (y/n): ");
        var choice = Console.ReadLine();
        if (choice == "y")
        {
          Weapon = item;
        }
      }
    }

    public Player(string name)
    {
      if (name == "jake")
      {
        BaseStrength = 50;
      }
      Name = name;
    }
  }
}