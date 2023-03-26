using GuessANumberSolidHW.Interfaces;
using GuessANumberSolidHW.Model.Settings;

namespace GuessANumberSolidHW.Services;

internal class UserEnterValueVerifier : IVerify
{
    private AppConfig _appConfig;

    private int _stepAttepmts = 0;

    public UserEnterValueVerifier(AppConfig appConfig)
    {
        _appConfig = appConfig;

        _stepAttepmts = _appConfig.Rules!.Attempts;
    }

    public bool Verify(int Result, int GuessedNumber)
    {
        if (Result == GuessedNumber)
        {
            Console.WriteLine($"Вы отгадали число! Ура! Искомое число {Result}");
            Console.WriteLine();

            return true;
        }
        else
        {
            Console.WriteLine($"Вы не угадали");
            Console.WriteLine($"У осталось {--_stepAttepmts} попыток");
            Console.WriteLine();

            if (Result > GuessedNumber)
            {
                Console.WriteLine($"Загаданное число меньше введённого вами");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"Загаданное число больше введённого вами");
                Console.WriteLine();
            }

            if (_stepAttepmts <= 0)
            {
                Console.WriteLine($"Вы проиграли! Загаданное числло {GuessedNumber}");
                Console.WriteLine($"Игра окончена!");
                Console.WriteLine();
                return true;
            }
        }

        return false;
    }
}