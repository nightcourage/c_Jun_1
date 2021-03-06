using System;

namespace FirstTask
{
    /*Легенда: Вы – теневой маг(можете быть вообще хоть кем) и у вас в арсенале есть несколько заклинаний, 
     * которые вы можете использовать против Босса. Вы должны уничтожить босса и только после этого будет вам покой.
     * 
     * Формально: перед вами босс, у которого есть определенное кол-во жизней и определенный ответный урон.
     * У вас есть 4 заклинания для нанесения урона боссу. Программа завершается только после смерти босса или смерти пользователя.
     * Пример заклинаний
     * Рашамон – призывает теневого духа для нанесения атаки (Отнимает 100 хп игроку)
     * Хуганзакура (Может быть выполнен только после призыва теневого духа), наносит 100 ед. урона
     * Межпространственный разлом – позволяет скрыться в разломе и восстановить 250 хп. Урон босса по вам не проходит
     * 
     * Заклинания должны иметь схожий характер и быть достаточно сложными, они должны иметь какие-то условия выполнения (пример - Хуганзакура).
     * Босс должен иметь возможность убить пользователя.*/

    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            //Базовые характеристики:
            float bossHP = rand.Next(300, 1000);
            int bossDamage = rand.Next(20, 60);
            int heroIntialHP = rand.Next(200, 400);
            float heroCurrentHP = Convert.ToSingle(heroIntialHP);


            //заклинания игрока:
            //1) барьер - обмен хп на магические барьер (х1.5 от затраченного хп), КД = 3 хода;
            //2) стан с уроном (возможно применить, если у босса меньше 50% ХП) - босс не может атаковать 2 хода, КД = 3 хода. Нельзя применить, если на боссе висит ДОТ.
            //3) токсичный хил - наносит мгновенный урон и периодический урон, игрок получает 1.5х урона на 2 хода но восстанавливает 30% от нанесенного урона, КД = 2 ход
            //4) фаталити - снимает 25% хп босса и 25% хм игрока. Если хп игрока ниже 30%, то урон боссу удваивается (50%). КД = 5 ходов.
            //5) уход в тень = если игрок ничего не делает (пропускает ход), то он восстанавливает 25% от недостающего ХП. КД = 3 хода.

            int barierDamage = rand.Next(50, Convert.ToInt32(heroCurrentHP));
            float barierHeal = 1.5f * barierDamage;
            int barierCD = 3;

            int stunDamage = rand.Next(30, 80);
            float stunTimer = 2;
            int stunCD = 3;
            bool stunStatus = false;

            int toxicInstantDamage = rand.Next(30, 50);
            int toxicDOT = rand.Next(5, 15);
            int dotCD = 5;
            bool dotStatus = false;
            float toxicHeal = 0.3f;
            float toxicDeBuff = 1.5f;
            int toxicDebufftTimer = 2;
            int toxicCD = 2;


            float fatalityDamage = 0.25f;
            int faralityDamageCD = 5;

            float shadowStep = 0.25f;
            int shadowStepCD = 3;


            //fight loop:   ход игрока - выбор заклинания, проверка возможности применения, плата за заклианние, применение, пересчет хит-поитов.
            //              ход босса: проверка статуса босса, проверка возможности нанести удар, нанесение удара, пересчет хит-поинтов.

            Console.WriteLine($"Бой начинается.\nХарактеристики Босса\nХит-Поитны: {bossHP}.\nУрон: {bossDamage}.\n\nХарактеристики игрока\nХит-Поинты:{heroIntialHP}\n");
            Console.WriteLine("Правила проведения боя.\n\n1) Игрок ходит первым.\n2) Игрок выбирает способность и исполняет ее.\n3) Атакует босс и наносит урон.\n4) Бой длится до смерти одного из участников.");

            while (heroCurrentHP > 0 && bossHP > 0)
            {
                bool nextStep = false;

                while (nextStep == false)
                {
                    int heroCast;
                    Console.WriteLine($"Выберите заклинание для применения. 1) Барьер; 2) Оглушение; 3) Токсичный залп; 4) Фаталити 5) Уход в тень. 6) Справка");
                    heroCast = Convert.ToInt32(Console.ReadLine());

                    switch (heroCast)
                    {
                        case 1:
                            Console.WriteLine("First ability");
                            nextStep = true;
                            break;
                        case 6:
                            Console.WriteLine("Справка");
                            Console.WriteLine("Press any key to go back");
                            Console.ReadKey();
                            break;
                    }

                }

                Console.WriteLine("Цикл окончен");
            }
            
        }
    }
}