using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Players : Creatures
    {
        string name { get; set; } //имя игрока
        List<Creatures> C { get; set; } //список монстров игры
        List<Bonuses> B { get; set; } // список бонусов на поле
        List<Obstacle> O { get; set; } //список препятствий
         
        public Players() { } //стандартный игрок
        public Players(string name) { } //создание своего игрока

        public void move(GameField GF, Obstacle O, Bonuses B, Creatures C) { } 
        //передвижение игрока по полю в зависимости от расположения бонусов, ионстров и препятствий.
        public void getBonuses(Bonuses B) { } //получить бонус
    }
}
