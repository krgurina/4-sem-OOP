using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop2
{
    class Discipline
    {
        public string title { get; set; }
        public int semestr { get; set; }
        public int course { get; set; }
        public int lectionCount { get; set; }
        public int labsCount { get; set; }

        public specialization Specialization { get; set; }
        public enum specialization
        {
            POIT,
            ISIT,
            POIBMS,
            DEVI
        }
        public controlType ControlType { get; set; }
        public enum controlType
        {
            exam,
            zachet
           
        }
    }
}
