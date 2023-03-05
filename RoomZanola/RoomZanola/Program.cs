

public class Room
{
    public int Length;
    public int Height;
    public int Width;
}

public class Program
{
    static void Main(string[] args)
    {
        // 0)Create a list of rooms
        List<Room> rooms = new List<Room>()
        {
            new Room { Length = 11, Height = 5, Width = 12 },
            new Room { Length = 9, Height = 7, Width = 11 },
            new Room { Length = 8, Height = 1, Width = 10 },
            new Room { Length = 10, Height = 10, Width = 10}
        };

        // Query 1: a list of volumes
        var volumes = rooms.Select(r => r.Length * r.Height * r.Width).ToList();
        Console.WriteLine("Volumes: " + string.Join(", ", volumes));

        // Query 2: a list of areas
        var areas = rooms.Select(r =>  (r.Length* r.Width )).ToList();
        Console.WriteLine("Areas: " + string.Join(", ", areas));

        // Query 3: the sum of all volumes
        var totalVolume = rooms.Sum(r => r.Length * r.Height * r.Width);
        Console.WriteLine("Total volume: " + totalVolume);

        // Query 4: the minimum of all areas
        var minArea = rooms.Min(r =>  (r.Length * r.Width));
        Console.WriteLine("Minimum area: " + minArea);
    }
}
