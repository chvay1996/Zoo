using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    class Program
    {
        static void Main ( string [] args )
        {
            Zoo zoo = new Zoo ();
            zoo.Work ();
        }
    }

    class Zoo
    {
        private List<Animal> _animal = new List<Animal> ();
        private int _numberAnimal;

        public Zoo ()
        {
            _animal.Add ( new Monkeys( "Обезьяны", "Обезьян" , 5));
            _animal.Add ( new Lions ( "Львы", "Львов", 7 ) );
            _animal.Add ( new Giraffes ( "Жирафы", "Жирафов", 3 ) );
            _animal.Add ( new Birds ( "Птицы", "Птиц", 7 ) );
            _animal.Add ( new Fish ( "Рыбы", "Рыб", 10 ) );
        }

        public void Work ( )
        {
            bool isWork = true;

            while ( isWork == true )
            {
                Console.Write ( "Приветствуем вас в зоопарке!\n" +
                    "Выбирете в какой вальер вы ходите пройти!\n" +
                    "1 - Подойти к выброному вальеру.\n" +
                    "2 - Пройти экскурсию.\n" +
                    "3 - Список всех вальеров.\n" +
                    "4 - Выйти из зоопарка\n\n\t\t" );

                switch ( int.Parse ( Console.ReadLine () ) )
                {
                    case 1:
                        ShowVolier ();
                        break;
                    case 2:
                        ZooTour ();
                        break;
                    case 3:
                        ShowZoo (  );
                        break;
                    case 4:
                        isWork = false;
                        break;
                    default:
                        Console.WriteLine ( "Неверно указано значение!" );
                        break;
                }
                Console.ReadLine ();
                Console.Clear ();
            }
        }

        private void ShowVolier ()
        {
            Console.WriteLine ("Выберите к какому вальеру вы хотите подойти\n" +
                    "1 - Обезьяны.\n" +
                    "2 - Львы\n" +
                    "3 - Жирафы\n" +
                    "4 - Птицы\n" +
                    "5 - Рыбы\n");

            switch ( int.Parse ( Console.ReadLine () ) )
            {
                case 1:
                    _numberAnimal = 0;
                    break;
                case 2:
                    _numberAnimal = 1;
                    break;
                case 3:
                    _numberAnimal = 2;
                    break;
                case 4:
                    _numberAnimal = 3;
                    break;
                case 5:
                    _numberAnimal = 4;
                    break;
                default:
                    Console.WriteLine ( "Неверно указано значение!" );
                    break;
            }
            ShowAnimals ();
        }

        private void ShowAnimals ( )
        {
            Console.WriteLine ( "Вы преближаетесь к Вольеу" );
            for ( int i = 0; i < _animal [_numberAnimal].NumberAnimal; i++ )
            {
                _animal [ _numberAnimal ].ShowInfoVolier ();
            }
        }

        private void ShowZoo (  )
        {
            Console.WriteLine ( "Все животные:" );
            for ( int i = 0; i < _animal.Count; i++ )
            {
                _animal [ i ].ShowInfo ( );
            }
        }

        private void ZooTour ()
        {
            for ( int i = 0; i < _animal.Count; i++ )
            {
                Console.Write ("\nВы проходите вальер ");
                _animal [ i ].ShowInfo ();
                Console.ReadKey ();
            }
            ShowVolier ();
        }
    }

    class Animal
    {
        private Random _rnd = new Random ();

        public Animal () { }

        public Animal ( string name, string volier, int numberAnimal )
        {
            Name = name;
            Gender = IdentifyTheGender ();
            Voice = "unknow";
            Volier = volier;
            NumberAnimal = numberAnimal;
        }

        public string Name { get; private set; }
        public string Gender { get; private set; }
        public string Voice { get; set; }
        public string Volier { get; private set; }
        public int NumberAnimal { get; private set; }


        public void ShowInfo ()
        {
            Console.WriteLine ( $"Вольер {Volier}, в нем {Name}, {NumberAnimal} животных" );
        }

        public void ShowInfoVolier ()
        {
            Console.WriteLine ( $"{Volier} В нем {Name}, пол {IdentifyTheGender ()} и издает {Voice}, {NumberAnimal} животных" );
        }

        public string IdentifyTheGender ()
        {
            if ( _rnd.Next ( 0, 2 ) > 0 )
            {
                Gender = "Мужской";
            }
            else
            {
                Gender = "Женский";
            }
                return Gender;
        }
    }

    class Monkeys : Animal
    {
        public Monkeys ( string name, string volier, int numberAnimal  ) : base ( name, volier , numberAnimal )
        {
            Voice = "У-у-у-а";
        }
    }

    class Lions : Animal
    {
        public Lions ( string name, string volier, int numberAnimal ) : base ( name, volier , numberAnimal )
        {
            Voice = "Ррррр";
        }
    }

    class Giraffes : Animal
    {
        public Giraffes ( string name, string volier, int numberAnimal  ) : base ( name, volier, numberAnimal )
        {
            Voice = "Хрум-хрум";
        }
    }

    class Birds : Animal
    {
        public Birds ( string name, string volier, int numberAnimal ) : base ( name, volier, numberAnimal )
        {
            Voice = " Чик-чирик";
        }
    }

    class Fish : Animal
    {
        public Fish ( string name, string volier, int numberAnimal ) : base ( name, volier , numberAnimal )
        {
            Voice = " Буль-буль";
        }
    }
}
/*Задача:
Пользователь запускает приложение и перед ним находится меню, в котором он может выбрать к какому вольеру подойти. 
При приближении к вольеру пользователю выводится информация о том, что это за вольер, 
сколько животных там обитает, их пол и какой звук издает животное.
Вольеров в зоопарке может быть много, в решении нужно создать минимум 4 вольера.*/