using GuessANumberSolidHW.BusinessLogic.Gamers;
using GuessANumberSolidHW.Domain;
using GuessANumberSolidHW.Interfaces;
using GuessANumberSolidHW.Model.Settings;
using Microsoft.Extensions.Logging;

namespace GuessANumberSolidHW.BusinessLogic;

internal class GuessNumberGame : IGame
{
    ILogger<GuessNumberGame> _logger;

    IVerify _resultVerifier;

    IGamerFactory _gamerFactory;

    private AppConfig _appConfig;

    public GuessNumberGame(AppConfig appConfig, 
                           ILogger<GuessNumberGame> logger, 
                           IVerify resultVerifier,
                           IGamerFactory gamerFactory)
    {
        _logger = logger;
        _appConfig = appConfig;
        _resultVerifier = resultVerifier;
        _gamerFactory = gamerFactory;
    }

    public void StartGame()
    {
        GameLifetimeCycleStart();
    }

    public void StopGame()
    {
    }

    private void GameLifetimeCycleStart()
    {
        _logger.LogInformation("Игра запущена!");

        // Данный участок кода отображает прицып Liscov Substitution Principal
        // Класс Gamer можно подменить, как классом Player, так и классом AiMachine
        Gamer player = _gamerFactory.CreateGamer("Player");
        Gamer aiMachine = _gamerFactory.CreateGamer("Computer");

        var aiMachineHiddenNumber = aiMachine!.MakeStep();

        Console.WriteLine($"Отгадайте число в диапазоне от {_appConfig.Rules!.MinOfRange} до {_appConfig.Rules!.MaxOfRange}");
        Console.WriteLine($"У вас есть {_appConfig.Rules!.Attempts} попыток");
        Console.WriteLine();

        while (true)
        {
            var playerAnswer = player!.MakeStep();

            // Внедрение дополнительного Verifier демонстрирует Opened/Closed принцып т.к. можно расширить поведение
            // и сделать любую проверку введённых значений путём передачи в основной класс игры другую реализацию
            var verifiedResult = _resultVerifier.Verify(playerAnswer, aiMachineHiddenNumber);

            if (verifiedResult)
                break;

            Task.Delay(100).Wait();
        }

        _logger.LogInformation("Игра оставновлена!");
    }
}