namespace Угадай
{
    internal class Program
    {
        /// <summary>
        /// Точка входа в программу. Инициализирует игровой процесс, генерирует загаданное число и запускает игровой цикл
        /// </summary>
        /// <param name="args">Аргументы командной строки (не используются)</param>
        static void Main(string[] args)
        {

            Console.WriteLine("Введите число от 1 до 100");
            int secretNumber = GeneralRandomNumber();
            PlayGame(secretNumber);

        }

        /// <summary>
        /// Создает случайное целое число в заданном интервале с помощью генератора случайных чисел
        /// </summary>
        /// <returns>Псевдослучайное число из диапазона [1, 100]</returns>
        static int GeneralRandomNumber()
        {
            Random rnd = new Random();
            return rnd.Next(1, 101);
        }
        /// <summary>
        /// Выполняет валидацию пользовательского ввода с ограничением количества попыток
        /// </summary>
        /// <param name="userNum">Переменная для сохранения корректного значения, введенного пользователем</param>
        /// <returns>Целое число, прошедшее проверку на соответствие допустимому диапазону</returns>
        static int Check(int userNum)
        {
            for (int i = 0; i < 3; i++)
            {
                if (!int.TryParse(Console.ReadLine(), out userNum) || userNum > 100 || userNum < -1)
                    Console.WriteLine("Некорректный ввод числа");

                else break;
                if (i == 2)
                {
                    Console.WriteLine("Ваше число имеет некорректный ввод");
                    Environment.Exit(0);
                }

            }
            return userNum;
        }
        /// <summary>
        /// Реализует основную механику угадывания числа путем сравнения пользовательского ввода с загаданным значением
        /// </summary>
        /// <param name="secretNumber">Целевое число, которое необходимо угадать игроку</param>
        /// <returns>Загаданное число (возвращается после завершения игры)</returns>
        static int PlayGame(int secretNumber)
        {

            while (true)
            {

                int checkNum = Check(secretNumber);



                if (checkNum < secretNumber)
                    Console.WriteLine("Ваша цифра меньше");
                else if (checkNum > secretNumber)
                    Console.WriteLine("Ваша цифра больше");
                else
                {
                    Console.WriteLine("Вы победили");
                    break;
                }

            }
            return secretNumber;
        }
    }

}
