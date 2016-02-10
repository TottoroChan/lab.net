using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Creatures : GameField //монстры и игрок
    {
        string name { get; set; } //имя
        List<string> type { get; set; } // тип монстра
        List<Obstacle> O { get; set; } //список препятствий

        public Creatures() { } //созданеи стандартного монстра
        public Creatures(string name, string type) { } //создание собственного монстра

        public void move(GameField GF, Obstacle O) { } //передвижение монстра по полю
    }
}
