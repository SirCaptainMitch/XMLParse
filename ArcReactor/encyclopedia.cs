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
                                     Name = r.Element("name").Value.Replace("'", ""),
                                     Level = Convert.ToInt32(r.Element("level").Value),
                                     School = r.Element("school").Value,
                                     Ritual = r.Element("ritual").Value,
                                     Time = r.Element("time").Value,
                                     Range = r.Element("range").Value,
                                     Components = r.Element("components").Value.Replace("'", ""),
                                     Duration = r.Element("duration").Value,
                                     Classes = r.Element("classes").Value,
                                     Text = r.Elements("text").Select(x => x.Value.Replace("'", "")).ToList()
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
                         String.Join("<br>", curspell.Text.ToArray())
                         );
                }

            }

            if (fileType == "Race")
            {
                var raceList = (from r in xmlDoc.Descendants("race")
                                select new
                                {
                                    Name = r.Element("name").Value.Replace("'", ""),
                                    Size = r.Element("size").Value,
                                    Speed = r.Element("speed").Value,
                                    Ability = r.Element("ability").Value,
                                    Trait = (from v in r.Elements("trait")
                                             select new
                                             {
                                                 TraitName = v.Element("name").Value.Replace("'", ""),
                                                 Text = v.Elements("text").Select(x => x.Value.Replace("'", "")).ToList()
                                                 
                                             }).ToList()

                                });


                foreach (var race in raceList)
                {

                    foreach (var i in race.Trait)
                    {
                        s += String.Format(@"

                    INSERT dbo.race (Name, Size, Speed, Ability, Trait, Text)
                    SELECT
                            '{0}'
                            ,'{1}'
                            ,'{2}'
                            ,'{3}'
                            ,'{4}'
                            ,'{5}'
                            ;
                    ",
                     race.Name,
                     race.Size,
                     race.Speed,
                     race.Ability,
                     i.TraitName,
                     i.Text
                     );

                    }
                }

            }

            if (fileType == "Class")
            {

                var classList = (from r in xmlDoc.Descendants("class")
                                 select new
                                 {
                                     Name = r.Element("name").Value.Replace("'", ""),
                                     HD = r.Element("hd").Value.Replace("'", ""),
                                     Prof = r.Element("Proficiency").Value.Replace("'", ""),
                                     SpellAbility = (string)r.Element("spellAbility") ?? "",
                                     AutoLevel = (from v in r.Elements("autolevel")
                                                  select new
                                                  {
                                                      Level = (string) v.Attribute("level"),
                                                      Feature = (from e in v.Elements("feature")
                                                                 select new
                                                                 {
                                                                     FeatureName = e.Element("name").Value.Replace("'", ""),
                                                                     Text = e.Elements("text").Select(x => x.Value.Replace("'", "")).ToList()
                                                                 } ).ToList() 
                                                  }
                                                  ).ToList()



                                 });
 
                foreach (var cl in classList)
                {
                    foreach(var lvl in cl.AutoLevel)
                    {
                        foreach (var ft in lvl.Feature)
                        {
                            s += String.Format(@"

                    INSERT dbo.Class_1 (Name, hd, prof, spell, level, feature, text)
                    SELECT
                            '{0}'
                            ,'{1}'
                            ,'{2}'
                            ,'{3}'
                            ,'{4}'
                            ,'{5}'
                            ,'{6}'
                            ;
                    ", cl.Name
                     , cl.HD
                     , cl.Prof
                     , cl.SpellAbility
                     , lvl.Level
                     , ft.FeatureName
                     , String.Join("<br> ", ft.Text.ToArray())
                     );
                        }
                        
                    }
                    
                }
            }

            return s;
        }
    }
}
