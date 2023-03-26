using GuessANumberSolidHW.Domain;
using GuessANumberSolidHW.Interfaces;
using GuessANumberSolidHW.Model.Settings;

namespace GuessANumberSolidHW.BusinessLogic.Gamers;

internal class AiMachine : Gamer
{
    private AppConfig _appConfig;

    public AiMachine(AppConfig appConfig)
    {
        _appConfig = appConfig;

        Name = "Компьютер";
    }

    // Метод расширяет возможности базового класса - отражает принцып Opened/Closed
    public override int MakeStep()
    {
        var minRange = _appConfig.Rules!.MinOfRange;
        var maxRange = _appConfig.Rules!.MaxOfRange;

        Console.WriteLine($"{Name} загадал число!\r\n");

        return new Random().Next(minRange, maxRange);
    }
}
