using Exam9.CustomExceptions;

namespace Exam9
{
    internal class Program
    {
        public static event Action<int> OnCommandGetted;
        public static List<string> Names { get; private set; }
        static void Main(string[] args)
        {
            OnCommandGetted += SortNames;
            GetNames();
            WriteNames();
            Console.WriteLine("\nСортировать список (А-Я) - {0}, (Я-А) -{1}", 1, 2);
            Start(0);
            Console.ReadKey();
        }

        private static void GetNames()
        {
            Names =
            [
                "Кутузов",
                "Милорадович",
                "Кульнев",
                "Раевский",
                "Багратион",
                "Барклай-де-Толли",
                "Уваров",
                "Платов",
                "Ермолов",
                "Тучков",
                "Кутайсов"
            ];
        }

        private static void Start(int command)
        {
            if (command == 0)
            {
                GetUserCommand();
            }
            else
            {
                OnCommandGetted?.Invoke(command);
            }
        }

        private static void WriteNames()
        {
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Green;
            foreach(var name in Names)
            {
                Console.WriteLine(name);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void SortNames(int command)
        {
            if (command == 1)
            {
                Names = Names.OrderBy(a => a).ToList();
            }
            else
            {
                Names = Names.OrderByDescending(a => a).ToList();
            }
            WriteNames();
        }

        private static void GetUserCommand()
        {
            int command = 0;
            try
            {

                var key = Console.ReadLine();
                if(string.IsNullOrEmpty(key))
                {
                    throw new ArgumentNullException(nameof(key));
                }
                if(key.Length > 1)
                {
                    throw new CountInputException("Количестов символов больше 1");
                }
                command = int.Parse(key);
                if(command != 1 && command != 2)
                {
                    throw new ValueException("Значения должны быть 1 или 2");
                }

            }
            catch(ArgumentNullException ex)
            {
                command = 0;
                Console.WriteLine(ex.Message);
            }
            catch(CountInputException ex)
            {
                command = 0;
                Console.WriteLine(ex.Message);
            }
            catch (NumericException ex)
            {
                command = 0;
                Console.WriteLine(ex.Message);
            }
            catch(FormatException ex)
            {
                command = 0;
                Console.WriteLine(ex.Message);
            }
            catch(ValueException ex)
            {
                command = 0;
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                command = 0;
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Start(command);
            }

        }
    }
}
