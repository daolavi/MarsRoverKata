namespace MarsRover.Logic;

public class MarsRover
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public char Direction { get; set; }
    
    public int GridWidth { get; private set; }
    public int GridHeight { get; private set; }

    public MarsRover(int x, int y, char direction, int gridWidth, int gridHeight)
    {
        X = x;
        Y = y;
        Direction = direction;
        GridWidth = gridWidth;
        GridHeight = gridHeight;
    }

    public void ExecuteCommands(string commands)
    {
        foreach (var command in commands)
        {
            ExecuteCommand(command);
        }
    }
    
    public void ExecuteCommand(char command)
    {
        switch (command)
        {
            case 'M': Move(); break;
            case 'R': TurnRight(); break;
            case 'L': TurnLeft(); break;
            default:
                throw new Exception($"Command {command} hasn't been supported");
        }
    }

    private void Move()
    {
        switch (Direction)
        {
            case 'N': Y = (Y + 1) % GridHeight; break;
            case 'E': X = (X + 1) % GridWidth; break;
            case 'S': Y = (Y - 1 + GridHeight) % GridHeight; break;
            case 'W': X = (X - 1 + GridWidth) % GridWidth; break;
        }
    }

    public void TurnRight()
    {
        switch (Direction)
        {
            case 'N': Direction = 'E'; break;
            case 'E': Direction = 'S'; break;
            case 'S': Direction = 'W'; break;
            case 'W': Direction = 'N'; break;
        }
    }

    public void TurnLeft()
    {
        switch (Direction)
        {
            case 'N': Direction = 'W'; break;
            case 'W': Direction = 'S'; break;
            case 'S': Direction = 'E'; break;
            case 'E': Direction = 'N'; break;
        }
    }
}