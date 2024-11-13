using System;
namespace Decorator.Examples
{
    class MainApp
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            ChristmasTree ourTree = new ChristmasTree();
            DecorateWithToys toys = new DecorateWithToys();
            DecorateWithTinsel tinsel = new DecorateWithTinsel();
            DecorateWithTinsel tinsel2 = new DecorateWithTinsel();
            DecorateWithGarland garland = new DecorateWithGarland();

            //прикрашаємо нашу ялинку іграшками, двома дощиками та гірляндою
            toys.SetComponent(ourTree);
            tinsel.SetComponent(toys);
            tinsel2.SetComponent(tinsel);
            garland.SetComponent(tinsel2);

            garland.Operation();
            garland.TurnOn(); // один раз гірлянду ввімкнув - свято більше не закінчується!

            Console.Read();
        }
    }
  
    abstract class Fir
    {
        public abstract void Operation();
    }

    class ChristmasTree : Fir
    {
        public override void Operation()
        {
            Console.WriteLine("Ялинка стоїть посеред кімнати");
        }
    }
  
    abstract class Decorator : Fir
    {
        protected Fir component;

        public void SetComponent(Fir component)
        {
            this.component = component;
        }
        public override void Operation()
        {
            if (component != null)
            {
                component.Operation();
            }
        }
    }

    class DecorateWithToys : Decorator
    {
        private string addedState;

        public override void Operation()
        {
            base.Operation();
            addedState = "Іграшки";
            Console.WriteLine("Прикрашена іграшками");
        }
    }

    class DecorateWithTinsel : Decorator
    {
        private string addedState;

        public override void Operation()
        {
            base.Operation();
            addedState = "Дощик";
            Console.WriteLine("Прикрашена дощиком");
        }
    }

    class DecorateWithGarland : Decorator
    {
        private string garland;
        public override void Operation()
        {
            base.Operation();
            garland = "Гірлянда";
            Console.WriteLine("Прикрашена гірляндою");
        }
        public void TurnOn()
        {
            Console.WriteLine("Вона світиться різними кольорами...");
        }
    }
}
