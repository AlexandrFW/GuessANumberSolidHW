# Проект GuessANumberSolidHW является выполнением домашнего задания по принцыпам SOLID
##
## 1. S - Single Responsibility Proncipal - принцып единой ответственности
#### Реализация данного принципа отражается в классах доменной модели https://github.com/AlexandrFW/GuessANumberSolidHW/tree/master/Domain 
##
## 2. O - Opened/Closed Principal - принцип открытости/закрытости 
#### Данный принцып отражён в основном классе игрового цикла https://github.com/AlexandrFW/GuessANumberSolidHW/blob/master/BusinessLogic/GuessNumberGame.cs
#### 1. Через конструктор внедряются IGamerFactory gamerFactory, фабрика, которая производит игроков и IVerify resultVerifier, объект, проверяющий правильность резуьтата
####    Тем самым в конструктор может быть передана любая фабрика, которая генерирует любых игроков и любой объект верификации результата, не изменяя реализацию 
####    класса основного цикла игры
#### 2. Также данный принцып отражён в использование абстрактного класса Gamer и его конкретных реализаций Player и AiMachine
####    В классе Gamer определён виртуальный метод, который даёт возможность расширения в класса конкретных реализаций, при этом не изменяя родительский класс
####    Gamer - https://github.com/AlexandrFW/GuessANumberSolidHW/blob/master/Domain/Gamer.cs
####    Player - https://github.com/AlexandrFW/GuessANumberSolidHW/blob/master/BusinessLogic/Gamers/Player.cs
####    AiMachine - https://github.com/AlexandrFW/GuessANumberSolidHW/blob/master/BusinessLogic/Gamers/AiMachine.cs
##
## 3. Liskov Substitution principal - При подстановки Барбары Лисков
####  Данный принцип отражён при создание объектов Gamer фабрикой. Т.к. объект Player и AiMachine являются наследниками Gamer, то при соответствующем запросе к фабрике
####  создаются объекты конкретных реализаций и приравниваются к родительскому объекту. Но ведут созданные объекты себя в соответствии со своими реализациями
####  https://github.com/AlexandrFW/GuessANumberSolidHW/blob/master/BusinessLogic/GuessNumberGame.cs
##
## 4. Interface Segregation Principal - принцип разделения интерфейсов
####  Данный принцип отражён в интерфейсах. Ниодин из интерфейсов не перегружен и отвечает только за те действия, которые он определяет
####  https://github.com/AlexandrFW/GuessANumberSolidHW/tree/master/Interfaces 
##
## 5. Dependancy Inversion Principal - При инверсии зависимости
####  Данный принцип отражён в использование меанизмов внедрения зависимостей (Dependancy Injection)
####  https://github.com/AlexandrFW/GuessANumberSolidHW/blob/master/Program.cs (метод SetupDIContainer)
