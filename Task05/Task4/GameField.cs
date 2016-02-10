using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class GameField //
    {
        string name { get; set; } //название поля 
        double width { get; set; } //ширина поля
        double height { get; set; } //высота поля
        List<Creatures> C { get; set; } //список монстров игры
        List<Bonuses> B { get; set; } // список бонусов на поле
        List<Obstacle> O { get; set; } //список препятствий


        public GameField() { } //создание стандартного поля
        public GameField(string name, double width, double height) { } // создание воего поля

        public void AddMonsters(Creatures C) { } //добавить монстра на поле
        public void AddBonuses(Bonuses B) { } // добавить бонус
        public void AddObstacle(Obstacle O) { } // добавить препятствие

        public void StartGame() { } //запуск игры
    }
}
