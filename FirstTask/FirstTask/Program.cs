using System;

namespace FirstTask
{
    class Program
    {
        static void Main(string[] args)
        {
            //Вы задаете вопросы пользователю, по типу "как вас зовут", "какой ваш знак зодиака" и тд, после чего, по данным, которые он ввел,
            //    формируете небольшой текст о пользователе.

            //"Вас зовут Алексей, вам 21 год, вы водолей и работаете на заводе."

            string firstName, lastName, profession, city;
            int age, salary;

            Console.Write("Укажите ваше имя: ");
            firstName = Console.ReadLine();
            Console.Write("Укажите вашу фамилию: ");
            lastName = Console.ReadLine();
            Console.Write("Укажите вашу профессию: ");
            profession = Console.ReadLine();
            Console.Write("Укажите город в котором проживаете: ");
            city = Console.ReadLine();
            Console.Write("Укажите ваш возраст: ");
            age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Укажите вашу зарплату в USD: ");
            salary = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Вас зовут {firstName} {lastName}. Вы проживаете в городе {city}. Вам {age} лет.\nВы работатет {profession} и получаете {salary} USD");


        }
    }
}
