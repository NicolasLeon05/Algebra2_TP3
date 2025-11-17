using System;

public class Player : IComparable<Player>
{
    public string Name;

    public Player(string name)
    {
        Name = name;
    }

    public int CompareTo(Player other)
    {
        if (other == null)
            return 1;

        return Name.CompareTo(other.Name);
    }

    public override string ToString()
    {
        return Name;
    }
}
