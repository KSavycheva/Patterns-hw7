using System;
using System.Collections;

/*
 * Зоопарк з головною поляною та декількома залами з різноманітними тваринами
 * В одній з них знаходиться ще й акваріум з восьминігом. 
 * Головною поляною блукають не менш цікаві тварини... 
 */

namespace CompositeExample
{
    class MainApp
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Component root = new Composite("Головна поляна");
            root.Add(new Animal("Оцелот"));
            root.Add(new Animal("Аргентавіс"));
            root.Add(new Animal("Лось"));

            Animal extinctAnimal = new Animal("Тилацин");
            root.Add(extinctAnimal);

            Component reptileHall = new Composite("Зала з рептиліями");
            reptileHall.Add(new Animal("Гіганська черепаха"));
            reptileHall.Add(new Animal("Алігатор"));
            root.Add(reptileHall);

            Component marineHall = new Composite("Зала Морська");
            marineHall.Add(new Animal("Дікенсонія"));
            marineHall.Add(new Animal("Полярний ведмідь"));
            root.Add(marineHall);

            Component aquarium = new Composite("Aкваріум");
            aquarium.Add(new Animal("Восьминіг Дамбо"));
            marineHall.Add(aquarium);

            root.Display(0);

            root.Remove(marineHall);
            root.Remove(extinctAnimal);

            Console.WriteLine(" .  .  .  .  . Після декількох років .  .  .  .  . ");
            root.Display(0);

            Console.Read();
        }
    }
    abstract class Component
    {
        protected string name;

        public Component(string name)
        {
            this.name = name;
        }

        public abstract void Add(Component c);
        public abstract void Remove(Component c);
        public abstract void Display(int depth);
    }

    class Composite : Component
    {
        private ArrayList children = new ArrayList();
        public Composite(string name)
            : base(name)
        {
        }

        public override void Add(Component component)
        {
            children.Add(component);
        }

        public override void Remove(Component component)
        {
            children.Remove(component);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);

            foreach (Component component in children)
            {
                component.Display(depth + 2);
            }
        }
    }

    class Animal : Component
    {
        public Animal(string name)
            : base(name)
        {
        }

        public override void Add(Component c)
        {
            Console.WriteLine("Cannot add to an aviary");
        }

        public override void Remove(Component c)
        {
            Console.WriteLine("Cannot remove from an aviary");
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
        }

    }
}

