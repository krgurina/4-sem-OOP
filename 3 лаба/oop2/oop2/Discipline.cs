using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace oop2
{
    public class Discipline
    {
        [Required(ErrorMessage = "Не указан лектор")]
        public Lector lector { get; set; }

        [Required(ErrorMessage = "Не указано название предмета")]
        [RegularExpression(@"^[а-яА-Я]{3,}$",ErrorMessage ="Разрешены только буквы русского алфавита")]
        public string title { get; set; }

        [SemesterValidate]
        public int semestr { get; set; }

        [Required]
        public string course { get; set; }
        [Required(ErrorMessage = "Не указано количество лекций")]
        public int lectionCount { get; set; }
        [Range(1, 70, ErrorMessage ="Некорректное количество лаб")]
        public int labsCount { get; set; }
        public string specialization { get; set; }
        [Required(ErrorMessage = "Не указан тип контроля")]
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
            return "\n==============================="+"\nНазвание: " + title +"\nКурс: " + this.course + "\nСеместр: " + this.semestr + "\nСпециальность: " + this.specialization + "\nКол-во лекций: " + this.lectionCount + "\nКол-во лаб: " + this.labsCount + "\nТип контроля: " + this.controlType +  this.lector;
        }
    }
}
