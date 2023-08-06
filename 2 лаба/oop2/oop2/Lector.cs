using System;
using System.Collections.Generic;
using System.Text;

namespace oop2
{
    public class Lector
    {
        public string kafedra { get; set; }
        public string FIO { get; set; }
        public string audience { get; set; }

        public Lector(string FIO, string kafedra, string audience)
        {
            this.kafedra = kafedra;
            this.FIO = FIO;
            this.audience = audience;
        }
        public Lector() { }
        public override string ToString()
        {
            return "\n\nЛектор: " + this.FIO + "\nкафедра: " + this.kafedra + "\nаудитрия: " + this.audience;
        }
    }
}
