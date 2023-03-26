namespace GuessANumberSolidHW.Domain;

public abstract class Gamer
{
    public string Name { get; set; } = string.Empty;

    public virtual int MakeStep()
    {
        return 0;
    }
}