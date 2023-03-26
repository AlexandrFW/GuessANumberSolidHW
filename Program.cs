using GuessANumberSolidHW.BusinessLogic;
using GuessANumberSolidHW.BusinessLogic.Gamers;
using GuessANumberSolidHW.Interfaces;
using GuessANumberSolidHW.Model.Settings;
using GuessANumberSolidHW.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

// Каждый класс в Domain имеет единую ответственность, что отображает принцип Single Rsponcibilities

public class Program
{
    public static AppConfig? AppConfiguration { get; set; }

    static ServiceProvider? serviceProvider;
    static ILogger<Program>? _logger;

    public static void Main(string[] args)
    {
        Console.WriteLine("Домашняя работа Solid: Игра отгадай число");
        Console.WriteLine();

        var iConfiguration = GetConfigurationFromJson();

        AppConfiguration = iConfiguration.Get<AppConfig>();

        SetupDIContainer();

        _logger!.LogInformation("Запуск приложения");

        var game = serviceProvider!.GetService<IGame>();
        game!.StartGame();

        serviceProvider?.Dispose();
    }

    private static void SetupDIContainer()
    {
        // Установка DI контейнера - отражение принципа Dependancy Inversion (Инверсии зависимости)
        serviceProvider = new ServiceCollection()
            .AddSingleton(AppConfiguration!)
            .AddLogging(c => c.AddConsole(opt => opt.LogToStandardErrorThreshold = LogLevel.Debug))
            .AddScoped<IGamerFactory, GamerFactory>()
            .AddScoped<IVerify, UserEnterValueVerifier>()
            .AddSingleton<IGame, GuessNumberGame>()
            .BuildServiceProvider();

        _logger = serviceProvider
            .GetService<ILoggerFactory>()!
            .CreateLogger<Program>()!;                    
    }

    private static IConfiguration GetConfigurationFromJson()
    {
        var configBuilder = new ConfigurationBuilder()
                        .AddJsonFile("appconfig.json");

        return configBuilder.Build();
    }
}