using GuessANumberSolidHW.Domain;
using GuessANumberSolidHW.Interfaces;
using GuessANumberSolidHW.Model.Settings;

namespace GuessANumberSolidHW.BusinessLogic.Gamers;

internal class GamerFactory : IGamerFactory
{
    private AppConfig? _appConfig;

    public GamerFactory(AppConfig appConfig)
    {
        _appConfig = appConfig;
    }

    public Gamer CreateGamer(string gamerType)
    {
        switch (gamerType)
        {
            default: 
                throw new TypeLoadException(nameof(gamerType));

            case "Player":
                return new Player();

            case "Computer":
                return new AiMachine(_appConfig);
        }
    }
}
