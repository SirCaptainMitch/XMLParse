using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace ArcReactor
{
    public class encyclopedia
    {
        private List<Spell> spellList = new List<Spell>();
        private List<Race> raceList = new List<Race>();
        private string filepath;
        private string fileType;


        public override string ToString()
        {
            var t = "";
            foreach (Spell s in spellList)
            {
                t += String.Format("name: {0}\r\n\t level: {1}\r\n\t school: {2}\r\n\t ritual: {3}\r\n\t time: {4}\r\n\t range: {5}\r\n\t components: {6}\r\n\t duration: {7}\r\n\t classes: {8}\r\n\t text: {9}\r\n\r\n",
                    s.Name, s.Level, s.School, s.Ritual,
                    s.Time, s.Range, s.Components,
                    s.Duration, s.Classes, s.Text
                    );
            }
            return t;
        }

        public encyclopedia()
        {
            throw new System.IO.FileNotFoundException();
        }
        public encyclopedia(string Filename, string FileType)
        {
            filepath = Filename;
            fileType = FileType;
        }

        // 
        public void study()
        {
            XDocument xmlDoc = XDocument.Load(filepath);
            

            if (fileType == "Spell")
            {

                spellList = (from r in xmlDoc.Descendants("spell")
                             select new
                             {
                                 Name = r.Element("name").Value,
                                 Level = Convert.ToInt32(r.Element("level").Value),
                                 School = r.Element("school").Value,
                                 Ritual = r.Element("ritual").Value,
                                 Time = r.Element("time").Value,
                                 Range = r.Element("range").Value,
                                 Components = r.Element("components").Value,
                                 Duration = r.Element("duration").Value,
                                 Classes = r.Element("classes").Value,
                                 Text = r.Element("text").Value
                             }).AsEnumerable().Select(x => new Spell
                             {
                                 Name = x.Name,
                                 Level = x.Level,
                                 School = x.School,
                                 Ritual = x.Ritual,
                                 Time = x.Time,
                                 Range = x.Range,
                                 Components = x.Components,
                                 Duration = x.Duration,
                                 Classes = x.Classes,
                                 Text = x.Text

                             }).ToList(); 
                             
            }

        }

        public String getInserts()
        {

            var s = "";

            if (fileType == "Spell")
            {
                foreach (var curspell in spellList)
                {
                    s +=
                                       String.Format(@"

INSERT dbo.Spells (Name, Level, School, Ritual, Time, Range, Components, Duration, Classes, Text)
SELECT
        '{0}'
        ,'{1}'
        ,'{2}'
        ,'{3}'
        ,'{4}'
        ,'{5}'
        ,'{6}'
        ,'{7}'
        ,'{8}'
        ,'{9}';
",
     curspell.Name,
     curspell.Level,
     curspell.School,
     curspell.Ritual,
     curspell.Time,
     curspell.Range,
     curspell.Components,
     curspell.Duration,
     curspell.Classes,
     curspell.Text
     );




                }

            }

            return s;
        }
    }
}
