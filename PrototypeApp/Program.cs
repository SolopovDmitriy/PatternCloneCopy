using Company;
using System;
using System.Drawing;

namespace PrototypeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Prototype - паттерн который отвечает за создание копии обьекта
            //ответсвенность создания копии обьекта ложится на сам копируемый обьект 
            /*Director s = new Director();
            Director d =  s.Clone();*/

            Shape firstShape = new Shape();
            Console.WriteLine(firstShape);

            Shape secondShape = new Shape(150, 50, Color.Black);
            Console.WriteLine(secondShape);

            Shape point = (Shape)secondShape.Clone(); //задействовано приведение типов

            Console.WriteLine(point);

            secondShape.Color = Color.Red;
            Console.WriteLine(secondShape);
            Console.WriteLine("Клонированный обьект");
            Console.WriteLine(point);



            Circle circle_1 = new Circle();
            Console.WriteLine(circle_1);

            Circle circle_2 = new Circle(15,15,25,Color.Green);
            Console.WriteLine(circle_2);

            Console.WriteLine("Клонированный обьект");
            Circle copy = circle_2.GenClone();
            copy.Radius = 1500;
            Console.WriteLine(copy);

            Worker worker = new Worker("Марко", "Поло", "Иммануилович", new DateTime(1990, 10, 25), Genre.MALE, Nationality.English,
                                        EducationLevel.Higher, 3500f, "Колоть дрова");
            Manager manager = new Manager();
            manager.addWorker(worker);

            Console.WriteLine(manager);
        }
    }
}
