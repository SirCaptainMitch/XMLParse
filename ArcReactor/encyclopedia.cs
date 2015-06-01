using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace ArcReactor
{
    public class encyclopedia
    {
        private List<Spell> spellList = new List<Spell>();
        private string filepath;
        private string fileType;

        /// <summary>
        /// Where are my godamn spells?
        /// </summary>
        public string Filename
        {
            get
            {
                return filepath;
            }
            set
            {
                filepath = value;
            }
        }


        /// <summary>
        /// Your godamn spells
        /// </summary>
        public List<Spell> SpellList
        {
            get
            {
                return spellList;
            }
            set
            {
            }
        }

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
       

        public object study()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Filename);
            foreach (XmlNode spellbook in xmlDoc.DocumentElement.ChildNodes)
            {
                Spell curspell = new Spell();
                foreach (XmlElement spell in spellbook)
                {
                    switch (spell.Name)
                    {
                        case "name":
                            curspell.Name = spell.InnerText;
                            break;
                        case "level":
                            curspell.Level = Convert.ToInt32(spell.InnerText);
                            break;
                        case "school":
                            curspell.School = spell.InnerText;
                            break;
                        case "ritual":
                            curspell.Ritual = spell.InnerText;
                            break;
                        case "time":
                            curspell.Time = spell.InnerText;
                            break;
                        case "range":
                            curspell.Range = spell.InnerText;
                            break;
                        case "components":
                            curspell.Components = spell.InnerText;
                            break;
                        case "duration":
                            curspell.Duration = spell.InnerText;
                            break;
                        case "classes":
                            curspell.Classes = spell.InnerText;
                            break;
                        case "text":
                            curspell.Text += spell.InnerText;
                            break;
                        default:
                            break;
                    }

                }

                spellList.Add(curspell);
            }
            return spellList;
        }

        public String getInserts()
        {

            var s = "";
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
                         curspell.Name.ToString().Replace("'", ""),
                         curspell.Level,
                         curspell.School,
                         curspell.Ritual,
                         curspell.Time,
                         curspell.Range,
                         curspell.Components.ToString().Replace("'", ""),
                         curspell.Duration,
                         curspell.Classes,
                         curspell.Text.ToString().Replace("'", "")
                         );
            }
            return s;
        }
    }
}
