namespace GuessANumberSolidHW.Model.Settings;

public class AppConfig
{
    public Rules? Rules { get; set; }
}

public class Rules
{
    public int Attempts { get; set; }

    public int MinOfRange { get; set; }

    public int MaxOfRange { get; set; }
}