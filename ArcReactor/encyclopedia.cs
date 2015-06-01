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
        private string filepath;
        private string fileType;

        public encyclopedia()
        {
            throw new System.IO.FileNotFoundException();
        }
        public encyclopedia(string Filename, string FileType)
        {
            filepath = Filename;
            fileType = FileType;
        }


        public String getInserts()
        {
            XDocument xmlDoc = XDocument.Load(filepath);

            var s = "";

            if (fileType == "Spell")
            {

                var spellList = (from r in xmlDoc.Descendants("spell")
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
                                     Text = r.Elements("text").Select(x => x.Value).ToList()
                                 });




                foreach (var curspell in spellList)
                {
                    s += String.Format(@"

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
                         String.Join("<br>",curspell.Text.ToArray()) 
                         );
                }

            }

            return s;
        }
    }
}
