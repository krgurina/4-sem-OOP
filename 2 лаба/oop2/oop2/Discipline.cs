using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop2
{
    class Discipline
    {
        public Lector lector { get; set; }
        public string title { get; set; }
        public int semestr { get; set; }
        public string course { get; set; }
        public int lectionCount { get; set; }
        public int labsCount { get; set; }
        public string specialization { get; set; }
        public string controlType { get; set; }

        public Discipline(string title, int semestr, string course, int lectionCount, int labsCount, string specialization, string controlType, Lector lect)
        {
            this.title = title;
            this.semestr = semestr;
            this.course = course;
            this.lectionCount = lectionCount;
            this.labsCount = labsCount;
            this.specialization = specialization;
            this.controlType = controlType;
            lector = lect;
        }
        public Discipline()
        {

        }
        public override string ToString()
        {
            return title +"\nКурс: " + this.course + "\nСеместр: " + this.semestr + "\nСпециальность" + this.specialization + "\nКол-во лекций: " + this.lectionCount + "\nКол-во лаб: " + this.labsCount + "\nТип контроля: " + this.controlType +  this.lector;
        }
    }
}
