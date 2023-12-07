using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace CoverYourAss.Models
{
    public class Activity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public DateTime When { get; set; }

        //public List<Person> People { get; set; }
        //public Location Where { get; set; }
        //public List<string> Pictures { get; set; }
        //public List<Tag> Tags { get; set; }
        //public List<Note> Notes { get; set; }
    }
}
