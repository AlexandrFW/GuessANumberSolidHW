using GuessANumberSolidHW.Domain;

namespace GuessANumberSolidHW.Interfaces;

public interface IGamerFactory
{
    public Gamer CreateGamer(string gamerType);
}