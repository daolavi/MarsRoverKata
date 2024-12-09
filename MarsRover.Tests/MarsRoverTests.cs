namespace MarsRover.Tests;

[TestFixture]
public class MarsRoverTests
{
    [Test]
    public void Initialise_ShouldInitialiseMarsRoverAndGrid()
    {
        var marsRover = new Logic.MarsRover(1,2,'N', 10, 10);
        Assert.That(marsRover.X, Is.EqualTo(1));
        Assert.That(marsRover.Y, Is.EqualTo(2));
        Assert.That(marsRover.Direction, Is.EqualTo('N'));
        Assert.That(marsRover.GridWidth, Is.EqualTo(10));
        Assert.That(marsRover.GridHeight, Is.EqualTo(10));
    }

    [TestCase('N', 1, 3)]
    [TestCase('E', 2,2)]
    [TestCase('S', 1,1)]
    [TestCase('W', 0,2)]
    public void Execute_Move(char direction, int expectedX, int expectedY)
    {
        var marsRover = new Logic.MarsRover(1,2,direction, 10, 10);
        marsRover.ExecuteCommand('M');
        Assert.That(marsRover.X, Is.EqualTo(expectedX));
        Assert.That(marsRover.Y, Is.EqualTo(expectedY));
    }

    /*
1 2 3
4 5 6
7 8 9
     */
    [TestCase(0, 2, 'N', 0 ,0)]
    [TestCase(0, 0, 'S', 0 ,2)]
    [TestCase(0, 1, 'W', 2 ,1)]
    [TestCase(2, 1, 'E', 0 ,1)]
    public void Execute_Move_WrapAround_AtTheEdge(int x, int y, char direction, int expectedX, int expectedY)
    {
        var marsRover = new Logic.MarsRover(x, y, direction, 3, 3);
        marsRover.ExecuteCommand('M');
        Assert.That(marsRover.X, Is.EqualTo(expectedX));
        Assert.That(marsRover.Y, Is.EqualTo(expectedY));
    }

    [TestCase('N', 'E')]
    [TestCase('E', 'S')]
    [TestCase('S', 'W')]
    [TestCase('W', 'N')]
    public void Execute_TurnRight(char direction, char expectedDirection)
    {
        var marsRover = new Logic.MarsRover(1, 1, direction, 3, 3);
        marsRover.ExecuteCommand('R');
        Assert.That(marsRover.Direction, Is.EqualTo(expectedDirection));
    }
    
    [TestCase('N', 'W')]
    [TestCase('W', 'S')]
    [TestCase('S', 'E')]
    [TestCase('E', 'N')]
    public void Execute_TurnLeft(char direction, char expectedDirection)
    {
        var marsRover = new Logic.MarsRover(1, 1, direction, 3, 3);
        marsRover.ExecuteCommand('L');
        Assert.That(marsRover.Direction, Is.EqualTo(expectedDirection));
    }

    [Test]
    public void Execute_MoveBackward()
    {
        var marsRover = new Logic.MarsRover(1, 1, 'N', 3, 3);
        Assert.Throws<Exception>(() => marsRover.ExecuteCommand('B'));
    }

    /*
1 2 3
4 5 6
7 8 9
     */
    [Test]
    public void Execute_Commands()
    {
        var marsRover = new Logic.MarsRover(1, 1, 'N', 3, 3);
        marsRover.ExecuteCommands("RRRRMLLLLLM");
        Assert.That(marsRover.X, Is.EqualTo(0));
        Assert.That(marsRover.Y, Is.EqualTo(2));
        Assert.That(marsRover.Direction, Is.EqualTo('W'));
    }
}