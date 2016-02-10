using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Bonuses : GameField
    {
        string name { get; set; } //название бонуса
        List<string> type { get; set; } //тип
        List<string> stat { get; set; } //характеристики, изменяемые бонусом

        public Bonuses() { } //стандартный бонус
        public Bonuses(string name, string type) { } //создание своего бонуса

        public void Stats(string type, string stat) { } // изменение зарактеристики из-за поднятого бонуса
    }
}
