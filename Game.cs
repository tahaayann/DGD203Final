using System.Diagnostics.Metrics;
using System.Numerics;
using System.Xml.Serialization;

namespace DGD203
{
    internal class Game
    {
        private const int _defaultMapWidth = 5;
        private const int _defaultMapHeight = 5;

        public Player Player { get; private set; }

        private string _playerName;
        private int _playerAge;

        public Location[] _locations;

        private int[] _integerArray;
        private List<int> _integerList;

        private bool _gameRunning;
        private Map _gameMap;

        private string _playerInput;
      

        private void GetPlayerName()
        {

            Console.WriteLine("Welcome soldier!");
            Console.WriteLine("Can you tell me your name?");
            _playerName = Console.ReadLine();

            if (_playerName == "Johnny")
            {
                Console.WriteLine($"Here comes the {_playerName}.");

            }
            else if (_playerName == "")

            {
                Console.WriteLine("Player name not entered, giving the name John Doe");
                _playerName = "JohnDoe";

            }
            else

            {
                Console.WriteLine($"Pleased to meet you , {_playerName}.");

            }
        }

        private void GetPlayerAge()
        {
            Console.WriteLine($"Okey then , what is your age {_playerName}");

            string PlayerAgeInString = Console.ReadLine();

            if (Int32.TryParse(PlayerAgeInString, out int x))
            {
                _playerAge = x;
                Console.WriteLine($"Wow what a wonderful age ,{_playerAge} is");

            }
            else
            {
                _playerAge = 2;
                Console.WriteLine($"Ha ha ha so mature then i assume your age as an {_playerAge}");

        }
        }

        private void InitializeGameConditions()
        {
            
            _gameMap.CheckForLocation(_gameMap.GetCoordinates());
        }

        public void StartGame(Game gameInstanceReference)
        {
            CreateNewMap();
            CreatePlayer();
            InitializeGameConditions();

            _gameRunning = true;

            StartGameLoop();

        }

        public void CreateNewMap()
        {
            _gameMap = new Map(_defaultMapWidth,_defaultMapHeight);

        }

        private void CreatePlayer()
        {
            GetPlayerName();
            GetPlayerAge();
            Console.WriteLine($"Good luck in your adventure {_playerName}, take a care! ");

        }

        private void StartGameLoop()
        {
            while (_gameRunning) 
            {
                GetInput();
                ProcessInput();
            }


        }

        private void GetInput()
        {
            _playerInput = Console.ReadLine();

        }

        private void ProcessInput()
        {
            if(_playerInput == null||_playerInput == "")
            {
                Console.WriteLine("Give me an command!");
                return;
            }
            switch(_playerInput)
            {
                case "N":
                    _gameMap.MovePlayer(0, 1);
                    break;

                case "S":
                    _gameMap.MovePlayer(0, -1);
                    break;
                case "E":
                    _gameMap.MovePlayer(1, 0);
                    break;
                case "W":
                    _gameMap.MovePlayer(-1, 0);
                    break;
                case "exit":
                    Console.WriteLine("I hope you enjoyed my game!");
                    _gameRunning = false;
                    break;
                case "where":
                    _gameMap.CheckForLocation(_gameMap.GetCoordinates());

                    break;
                case "clear":
                    Console.Clear();

                    break;
                case "take":
                    _gameMap.TakeItem(Player,_gameMap.GetCoordinates());
                    break;
                default:
                    Console.WriteLine("We can currently only accept map movement commands. Please provide a direction, ,inditacated by" +
                        "its initial letter (N, S, W or E");

                    break;

            }

        }

    
    } 
}
