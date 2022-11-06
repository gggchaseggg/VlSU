using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace MicroserviceStudent.Models
{
    public class Student
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string GroupName { get; set; }
        public int Score { get; set; }
        public int PlaceInRanking { get; set; }
        public string Speciality { get; set; }
    }
}