namespace ConsoleApp4
{
    abstract class Car
    {
        public string Name { get; set; }
        public int Speed { get; set; }

        public Car(string name, int speed)
        {
            Name = name;
            Speed = speed;
        }

        // Делегат для события "Финиш"
        public delegate void FinishHandler(Car car);

        // Событие "Финиш"
        public event FinishHandler Finish;

        // Метод для движения автомобиля
        public void Move()
        {
            Random rnd = new Random();
            int distance = 0;

            while (distance < 100)
            {
                distance += Speed;
                Console.WriteLine($"{Name} проехал {distance} км");

                // Проверка на достижение финиша
                if (distance >= 100)
                {
                    if (Finish != null)
                    {
                        Finish(this);
                    }
                }

                // Задержка для эффекта движения
                System.Threading.Thread.Sleep(rnd.Next(500, 1000));
            }
        }
    }

    // Класс спортивного автомобиля
    class SportsCar : Car
    {
        public SportsCar(string name, int speed) : base(name, speed) { }
    }

    // Класс легкового автомобиля
    class SedanCar : Car
    {
        public SedanCar(string name, int speed) : base(name, speed) { }
    }

    // Класс грузовика
    class Truck : Car
    {
        public Truck(string name, int speed) : base(name, speed) { }
    }

    // Класс автобуса
    class Bus : Car
    {
        public Bus(string name, int speed) : base(name, speed) { }
    }

    // Класс игры
    class Game
    {
        public void StartRace()
        {
            // Создание объектов автомобилей
            SportsCar sportsCar = new SportsCar("Спортивный автомобиль", 10);
            SedanCar sedanCar = new SedanCar("Легковой автомобиль", 8);
            Truck truck = new Truck("Грузовик", 6);
            Bus bus = new Bus("Автобус", 4);

            // Подписка на событие "Финиш" для вывода победителя
            sportsCar.Finish += DisplayWinner;
            sedanCar.Finish += DisplayWinner;
            truck.Finish += DisplayWinner;
            bus.Finish += DisplayWinner;

            // Запуск гонок
            sportsCar.Move();
            sedanCar.Move();
            truck.Move();
            bus.Move();
        }

        // Метод для вывода победителя
        public void DisplayWinner(Car car)
        {
            Console.WriteLine($"{car.Name} победил в гонках!");
        }
    }

    // Точка входа в программу
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.StartRace();
        }
    }

}
