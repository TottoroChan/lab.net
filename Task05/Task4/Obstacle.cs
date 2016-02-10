using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Obstacle : GameField //препятствия
    {
        string name { get; set; } //название
        List<string> type { get; set; } // тип препятствия

        public Obstacle() { } // стандартный конструктор
        public Obstacle(string name, string type) { } // конструктор создающй препятствие определённого типа
        
    }
}
