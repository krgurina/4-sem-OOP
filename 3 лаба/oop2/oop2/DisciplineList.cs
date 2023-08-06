using System;
using System.Collections.Generic;
using System.Text;

namespace oop2
{
    public class DisciplineList
    {
        public List<Discipline> disciplineList { get; set; }
        public DisciplineList()
        {
            this.disciplineList = new List<Discipline>();
        }
        public int Count => this.disciplineList.Count;
        public void Add(Discipline element) => this.disciplineList.Add(element);  //добавление элемента

        public void RemoveAtPos(int pos) //удаление элемента в заданной позиции
        {
            this.disciplineList.RemoveAt(pos);
        }


    }
}
