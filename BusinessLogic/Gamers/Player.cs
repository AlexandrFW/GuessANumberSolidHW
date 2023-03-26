using GuessANumberSolidHW.Domain;
using GuessANumberSolidHW.Interfaces;

namespace GuessANumberSolidHW.BusinessLogic.Gamers;

internal class Player : Gamer
{
    public Player()
    {
        Name = "Игрок";
    }

    // Метод расширяет возможности базового класса - отражает принцып Opened/Closed
    public override int MakeStep()
    {
        var readValueFromConsole = Console.ReadLine();

        Console.WriteLine($"{Name} пытается отгадать.");

        int.TryParse(readValueFromConsole, out int proposedDigit);

        return proposedDigit;
    }
}