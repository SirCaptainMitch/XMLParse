using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Reflection;

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
            var s = "";

            try
            {
                XDocument xmlDoc = XDocument.Load(filepath);

                if (fileType == "Characters")
                {
                    ArcReactor.Models.Character.compendium characters =
                        FromXml<ArcReactor.Models.Character.compendium>(xmlDoc.ToString());
                    /*  
                          */

                    var test = 0;
                }

                ///////////////////////////////////////

                if (fileType == "Spells")
                {
                    ArcReactor.Models.Spell.compendium spells =
                        FromXml<ArcReactor.Models.Spell.compendium>(xmlDoc.ToString());
                    /*  spell: name, classes, components, duration, level, range, ritual, school, time
                               roll: [value]
                               text: [value]  */

                    var spellList = (from r in xmlDoc.Descendants("spell")
                                    select new
                                    {
                                        Name = ((string)r.Element("name") ?? "").Replace("'", ""),
                                        Classes = ((string)r.Element("classes") ?? "").Replace("'", ""),
                                        Components = ((string)r.Element("components") ?? "").Replace("'", ""),
                                        Duration = ((string)r.Element("duration") ?? "").Replace("'", ""),
                                        Level = ((string)r.Element("level") ?? "").Replace("'", ""),
                                        Range = ((string)r.Element("range") ?? "").Replace("'", ""),
                                        Ritual = ((string)r.Element("ritual") ?? "").Replace("'", ""),
                                        School = ((string)r.Element("school") ?? "").Replace("'", ""),
                                        Time = ((string)r.Element("time") ?? "").Replace("'", ""),
                                        Roll = r.Elements("roll").Where(x => x.Value != "" && x.Value != null)
                                               .Select(x => x.Value.Replace("'", "")).ToList(),
                                        Text = r.Elements("text").Where(x => x.Value != "" && x.Value != null)
                                               .Select(x => x.Value.Replace("'", "")).ToList()
                                    });

                    s = @"CREATE TABLE dbo.Spell ( Spell_ID INT IDENTITY(1,1),Name VARCHAR(MAX), classes VARCHAR(MAX), components VARCHAR(MAX), duration VARCHAR(MAX), level VARCHAR(MAX), range VARCHAR(MAX), ritual VARCHAR(MAX), school VARCHAR(MAX), time VARCHAR(MAX), roll VARCHAR(MAX), text VARCHAR(MAX)) ";

                    foreach (var sl in spellList)
                    {
                        s += String.Format(@"

                            INSERT dbo.Spell (name, classes, components, duration, level, range, ritual, school, time, roll, text)
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
                            ,'{9}'
                            ,'{10}'
                            ;
                            ",
                               sl.Name,
                               sl.Classes,
                               sl.Components,
                               sl.Duration,
                               sl.Level,
                               sl.Range,
                               sl.Ritual,
                               sl.School,
                               sl.Time,
                               String.Join("<br> ", sl.Roll.ToArray()),
                               String.Join("<br> ", sl.Text.ToArray())
                               );
                    }
                }

                if (fileType == "Items")
                {
                    ArcReactor.Models.Item.compendium items =
                        FromXml<ArcReactor.Models.Item.compendium>(xmlDoc.ToString());
                    /*  item: name, ac, dmg1, dmg2, dmgType, property, range, roll, stealth, strength, type, weight
                              modifier: category, [value]
                              text: [value]
                          
                        text value is sometimes null  */

                    var itemList = (from r in xmlDoc.Descendants("item")
                                    select new
                                    {
                                        Name = ((string)r.Element("name") ?? "").Replace("'", ""),
                                        AC = ((string)r.Element("ac") ?? "").Replace("'", ""),
                                        Dmg1 = ((string)r.Element("dmg1") ?? "").Replace("'", ""),
                                        Dmg2 = ((string)r.Element("dmg2") ?? "").Replace("'", ""),
                                        DmgType = ((string)r.Element("dmgtype") ?? "").Replace("'", ""),
                                        Property = ((string)r.Element("property") ?? "").Replace("'", ""),
                                        Range = ((string)r.Element("range") ?? "").Replace("'", ""),
                                        Roll = ((string)r.Element("roll") ?? "").Replace("'", ""),
                                        Stealth = ((string)r.Element("stealth") ?? "").Replace("'", ""),
                                        Strength = ((string)r.Element("strength") ?? "").Replace("'", ""),
                                        Type = ((string)r.Element("type") ?? "").Replace("'", ""),
                                        Weight = ((string)r.Element("weight") ?? "").Replace("'", ""),
                                        Modifier = ((string)r.Element("modifier") ?? "").Replace("'", ""),
                                        Category = (string)r.Element("modifier") != null
                                            ? (string)r.Element("modifier").Attribute("category") ?? "" : "",
                                        Text = r.Elements("text").Where(x => x.Value != "" && x.Value != null)
                                               .Select(x => x.Value.Replace("'", "")).ToList()
                                    });

                    s = @"CREATE TABLE dbo.Item (Item_ID  INT IDENTITY(1,1),name VARCHAR(MAX),ac VARCHAR(MAX), dmg1 VARCHAR(MAX), dmg2 VARCHAR(MAX), dmgtype VARCHAR(MAX), property VARCHAR(MAX), range VARCHAR(MAX), roll VARCHAR(MAX), stealth VARCHAR(MAX), strength VARCHAR(MAX), type VARCHAR(MAX), weight VARCHAR(MAX), modifier VARCHAR(MAX), category VARCHAR(MAX), text VARCHAR(MAX))";

                    foreach (var il in itemList)
                    {
                        s += String.Format(@"

                            INSERT dbo.Item (name, ac, dmg1, dmg2, dmgType, property, range, roll, stealth, strength, type, 
                                             weight, modifier, category, text)
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
                            ,'{9}'
                            ,'{10}'
                            ,'{11}'
                            ,'{12}'
                            ,'{13}'
                            ,'{14}'
                            ;
                            ",
                               il.Name,
                               il.AC,
                               il.Dmg1,
                               il.Dmg2,
                               il.DmgType,
                               il.Property,
                               il.Range,
                               il.Roll,
                               il.Stealth,
                               il.Strength,
                               il.Type,
                               il.Weight,
                               il.Modifier,
                               il.Category,
                               String.Join("<br> ", il.Text.ToArray())
                               );
                    }
                }

                if (fileType == "Monsters")
                {
                    ArcReactor.Models.Monster.compendium monsters =
                        FromXml<ArcReactor.Models.Monster.compendium>(xmlDoc.ToString());
                    /*  monster: name, ac, alignment, conditionImmune, cr, hp, immune, languages, passive, reaction, resist, save, 
                                            senses, size, skill, speed, spells, type, vulnerable, str, dex, con, int, wis, cha
                                 action: name
                                         attack: [value]
                                         text: [value]
                                 trait: name
                                        attack: [value]
                                        text: [value]
                                 legendary: name
                                            attack: [value]
                                            text: [value]   */

                    var monsterList = (from r in xmlDoc.Descendants("monster")
                                        select new
                                        {
                                            Name = ((string)r.Element("name") ?? "").Replace("'", ""),
                                            AC = ((string)r.Element("ac") ?? "").Replace("'", ""),
                                            Alignment = ((string)r.Element("alignment") ?? "").Replace("'", ""),
                                            ConditionImmune = ((string)r.Element("conditionImmune") ?? "").Replace("'", ""),
                                            CR = ((string)r.Element("cr") ?? "").Replace("'", ""),
                                            HitPoints = ((string)r.Element("hp") ?? "").Replace("'", ""),
                                            Immune = ((string)r.Element("immune") ?? "").Replace("'", ""),
                                            Languages = ((string)r.Element("languages") ?? "").Replace("'", ""),
                                            Passive = ((string)r.Element("passive") ?? "").Replace("'", ""),
                                            Reaction = ((string)r.Element("reaction") ?? "").Replace("'", ""),
                                            Resist = ((string)r.Element("resist") ?? "").Replace("'", ""),
                                            Save = ((string)r.Element("save") ?? "").Replace("'", ""),
                                            Senses = ((string)r.Element("senses") ?? "").Replace("'", ""),
                                            Size = ((string)r.Element("size") ?? "").Replace("'", ""),
                                            Skill = ((string)r.Element("skill") ?? "").Replace("'", ""),
                                            Speed = ((string)r.Element("speed") ?? "").Replace("'", ""),
                                            Spells = ((string)r.Element("spells") ?? "").Replace("'", ""),
                                            Type = ((string)r.Element("type") ?? "").Replace("'", ""),
                                            Vulnerable = ((string)r.Element("vulnerable") ?? "").Replace("'", ""),
                                            Str = ((string)r.Element("str") ?? "").Replace("'", ""),
                                            Dex = ((string)r.Element("dex") ?? "").Replace("'", ""),
                                            Con = ((string)r.Element("con") ?? "").Replace("'", ""),
                                            Int = ((string)r.Element("int") ?? "").Replace("'", ""),
                                            Wis = ((string)r.Element("wis") ?? "").Replace("'", ""),
                                            Cha = ((string)r.Element("cha") ?? "").Replace("'", ""),
                                            Action = (from v in r.Elements("action")
                                                      select new
                                                      {
                                                          ActionName = ((string)v.Element("name") ?? "").Replace("'", ""),
                                                          Attack = v.Elements("attack").Where(x => x.Value != "")
                                                                 .Select(x => x.Value.Replace("'", "")).ToList(),
                                                          Text = v.Elements("text").Where(x => x.Value != "")
                                                                 .Select(x => x.Value.Replace("'", "")).ToList()
                                                      }).ToList(),
                                            Trait = (from v in r.Elements("trait")
                                                     select new
                                                     {
                                                         TraitName = ((string)v.Element("name") ?? "").Replace("'", ""),
                                                         Attack = v.Elements("attack").Where(x => x.Value != "")
                                                                .Select(x => x.Value.Replace("'", "")).ToList(),
                                                         Text = v.Elements("text").Where(x => x.Value != "")
                                                                .Select(x => x.Value.Replace("'", "")).ToList()
                                                     }).ToList(),
                                            Legendary = (from v in r.Elements("legendary")
                                                         select new
                                                         {
                                                             LegendaryName = ((string)v.Element("name") ?? "").Replace("'", ""),
                                                             Attack = v.Elements("attack").Where(x => x.Value != "")
                                                                    .Select(x => x.Value.Replace("'", "")).ToList(),
                                                             Text = v.Elements("text").Where(x => x.Value != "")
                                                                    .Select(x => x.Value.Replace("'", "")).ToList()
                                                         }).ToList()
                                        });

                    s = @"
CREATE TABLE dbo.Monster (Monster_id  INT IDENTITY(1,1),name VARCHAR(MAX), ac VARCHAR(MAX), alignment VARCHAR(MAX), conditionImmune VARCHAR(MAX), cr VARCHAR(MAX), hitpoints VARCHAR(MAX), immune VARCHAR(MAX), languages VARCHAR(MAX), passive VARCHAR(MAX), reaction VARCHAR(MAX), resist VARCHAR(MAX), saves VARCHAR(MAX), senses VARCHAR(MAX), size VARCHAR(MAX), skill VARCHAR(MAX), speed VARCHAR(MAX), spells VARCHAR(MAX),monstertype VARCHAR(MAX), vulnerable VARCHAR(MAX), strength VARCHAR(MAX), dex VARCHAR(MAX), cont VARCHAR(MAX), intel VARCHAR(MAX), wis VARCHAR(MAX), cha VARCHAR(MAX))

CREATE TABLE dbo.Monster_Traits (monster_id INT, traitName VARCHAR(MAX), attack VARCHAR(MAX), text VARCHAR(MAX))

CREATE TABLE dbo.Monster_Legendary (monster_id INT, legendaryName VARCHAR(MAX), attack VARCHAR(MAX), text VARCHAR(MAX))

CREATE TABLE dbo.Monster_Actions (monster_id INT, actionName VARCHAR(MAX), attack VARCHAR(MAX), text VARCHAR(MAX))
";

                    foreach (var bl in monsterList)
                    {
                        s += String.Format(@"

                            INSERT dbo.Monster (name, ac, alignment, conditionImmune, cr, hitpoints, immune, languages, passive, reaction,
                                                resist, saves, senses, size, skill, speed, spells, monstertype, vulnerable, strength, dex, cont, intel, wis, cha)
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
                            ,'{9}'
                            ,'{10}'
                            ,'{11}'
                            ,'{12}'
                            ,'{13}'
                            ,'{14}'
                            ,'{15}'
                            ,'{16}'
                            ,'{17}'
                            ,'{18}'
                            ,'{19}'
                            ,'{20}'
                            ,'{21}'
                            ,'{22}'
                            ,'{23}'
                            ,'{24}'
                            ;
                            ",
                               bl.Name,
                               bl.AC,
                               bl.Alignment,
                               bl.ConditionImmune,
                               bl.CR,
                               bl.HitPoints,
                               bl.Immune,
                               bl.Languages,
                               bl.Passive,
                               bl.Reaction,
                               bl.Resist,
                               bl.Save,
                               bl.Senses,
                               bl.Size,
                               bl.Skill,
                               bl.Speed,
                               bl.Spells,
                               bl.Type,
                               bl.Vulnerable,
                               bl.Str,
                               bl.Dex,
                               bl.Con,
                               bl.Int,
                               bl.Wis,
                               bl.Cha
                               );

                        foreach (var act in bl.Action)
                        {
                            s += String.Format(@"

                            INSERT dbo.Monster_Actions (monster_id, actionName, attack, text)
                            SELECT
                                (SELECT TOP 1 monster_id FROM dbo.Monster WHERE name = '{0}')
                                ,'{1}'
                                ,'{2}'
                                ,'{3}'
                                ;
                                ",
                            bl.Name,
                            act.ActionName,
                            String.Join("<br> ", act.Attack.ToArray()),
                            String.Join("<br> ", act.Text.ToArray())
                            );
                        }

                        foreach (var trt in bl.Trait)
                        {
                            s += String.Format(@"

                            INSERT dbo.Monster_Traits (monster_id, traitName, attack, text)
                            SELECT
                                (SELECT TOP 1 monster_id FROM dbo.Monster WHERE name = '{0}')
                                ,'{1}'
                                ,'{2}'
                                ,'{3}'
                            ;
                            ",
                            bl.Name,
                            trt.TraitName,
                            String.Join("<br> ", trt.Attack.ToArray()),
                            String.Join("<br> ", trt.Text.ToArray())
                            );
                        }

                        foreach (var lgd in bl.Legendary)
                        {
                            s += String.Format(@"

                            INSERT dbo.Monster_Legendary (monster_id, legendaryName, attack, text)
                            SELECT
                                (SELECT TOP 1 monster_id FROM dbo.Monster WHERE name = '{0}')
                                ,'{1}'
                                ,'{2}'
                                ,'{3}'
                            ;
                            ",
                            bl.Name,
                            lgd.LegendaryName,
                            String.Join("<br> ", lgd.Attack.ToArray()),
                            String.Join("<br> ", lgd.Text.ToArray())
                            );
                        }
                    }
                }

                if (fileType == "Races")
                {
                    ArcReactor.Models.Race.compendium races =
                        FromXml<ArcReactor.Models.Race.compendium>(xmlDoc.ToString());
                    /*  race: ability, name, proficiency, size, speed
                              trait: name
                                     text: [value]  */
                    
                    var raceList = (from r in xmlDoc.Descendants("race")
                                    select new
                                    {
                                        Name = ((string)r.Element("name") ?? "").Replace("'", ""),
                                        Size = ((string)r.Element("size") ?? "").Replace("'", ""),
                                        Speed = ((string)r.Element("speed") ?? "").Replace("'", ""),
                                        Ability = ((string)r.Element("ability") ?? "").Replace("'", ""),
                                        Proficiency = ((string)r.Element("proficiency") ?? "").Replace("'", ""),
                                        Trait = (from v in r.Elements("trait")
                                                 select new
                                                 {
                                                     TraitName = ((string)v.Element("name") ?? "").Replace("'", ""),
                                                     Text = v.Elements("text").Where(x => x.Value != "")
                                                            .Select(x => x.Value.Replace("'", "")).ToList()
                                                 }).ToList()
                                    });

                    s = @" 
CREATE TABLE dbo.Race (Race_ID  INT IDENTITY(1,1),name VARCHAR(MAX), size VARCHAR(MAX), speed VARCHAR(MAX), ability VARCHAR(MAX), proficiency VARCHAR(MAX))

CREATE TABLE dbo.Race_Traits (Race_id INT, traitName VARCHAR(MAX), text VARCHAR(MAX))
";

                    foreach (var race in raceList)
                    {
                        s += String.Format(@"

                            INSERT dbo.Race (name, size, speed, ability, proficiency)
                            SELECT 
                            '{0}'
                            ,'{1}'
                            ,'{2}'
                            ,'{3}'
                            ,'{4}'
                            ;
                            ",
                            race.Name,
                            race.Size,
                            race.Speed,
                            race.Ability,
                            race.Proficiency
                            );

                        foreach (var i in race.Trait)
                        {
                            s += String.Format(@"

                            INSERT dbo.Race_Traits (race_id, traitName, text)
                            SELECT
                                (SELECT TOP 1 race_id FROM dbo.Race WHERE name = '{0}')
                            ,'{1}'
                            ,'{2}'
                            ;
                            ",
                            race.Name,
                            i.TraitName,
                            String.Join("<br> ", i.Text.ToArray())
                            );
                        }
                    }
                }

                if (fileType == "Backgrounds")
                {
                    ArcReactor.Models.Background.compendium backgrounds =
                        FromXml<ArcReactor.Models.Background.compendium>(xmlDoc.ToString());
                    /*  background: name, proficiency
                                    trait: name
                                           text: [value]  */

                    var backgroundList = (from r in xmlDoc.Descendants("background")
                                         select new
                                         {
                                             Name = ((string)r.Element("name") ?? "").Replace("'", ""),
                                             Proficiency = ((string)r.Element("proficiency") ?? "").Replace("'", ""),
                                             Trait = (from v in r.Elements("trait")
                                                      select new
                                                      {
                                                          TraitName = ((string)r.Element("name") ?? "").Replace("'", ""),
                                                          Text = v.Elements("text").Where(x => x.Value != "")
                                                                .Select(x => x.Value.Replace("'", "")).ToList()
                                                      }).ToList()
                                         });

                    s = @" 
CREATE TABLE dbo.Background (Background_id INT IDENTITY(1,1), Name VARCHAR(MAX), Proficiency VARCHAR(MAX))

CREATE TABLE dbo.Background_Traits (Background_id INT, traitName VARCHAR(MAX), text VARCHAR(MAX))
";

                    foreach (var bl in backgroundList)
                    {
                        s += String.Format(@"

                        INSERT dbo.Background (Name, Proficiency)
                        SELECT
                                ,'{0}'
                                ,'{1}'
                                ;
                       ", bl.Name
                        , bl.Proficiency
                        );

                        foreach (var trt in bl.Trait)
                        {
                            s += String.Format(@"

                            INSERT dbo.Background_Traits (background_id, traitName, text)
                            SELECT
                                    (SELECT TOP 1 background_id FROM dbo.Background WHERE name = '{0}')
                                    ,'{1}'
                                    ,'{2}'
                                    ;
                           ", bl.Name
                            , trt.TraitName
                            , String.Join("<br> ", trt.Text.ToArray())
                            );
                        }
                    }
                }

                if (fileType == "Feats")
                {
                    ArcReactor.Models.Feat.compendium feats =
                        FromXml<ArcReactor.Models.Feat.compendium>(xmlDoc.ToString());
                    /*  feat: name, prerequisite
                              modifier: category, [value]
                              text: [value]  */

                    var featList = (from r in xmlDoc.Descendants("feat")
                                    select new
                                    {
                                        Name = ((string)r.Element("name") ?? "").Replace("'", ""),
                                        Prerequisite = ((string)r.Element("prerequisite") ?? "").Replace("'", ""),
                                        Modifier = (string)r.Element("modifier") ?? "",
                                        Category = (string)r.Element("modifier") != null
                                            ? (string)r.Element("modifier").Attribute("category") ?? "" : "",
                                        Text = r.Elements("text").Where(x => x.Value != "")
                                            .Select(x => x.Value.Replace("'", "")).ToList(),
                                    });

                    s = @" 
CREATE TABLE dbo.Feat (Name VARCHAR(MAX), prerequisite VARCHAR(MAX), modifier VARCHAR(MAX), category VARCHAR(MAX), text VARCHAR(MAX))
";

                    foreach (var fl in featList)
                    {
                        s += String.Format(@"

                        INSERT dbo.Feat (name, prerequisite, modifier, category, text)
                        SELECT
                                '{0}'
                                ,'{1}'
                                ,'{2}'
                                ,'{3}'
                                ,'{4}'
                                ;
                       ", fl.Name
                        , fl.Prerequisite
                        , fl.Modifier
                        , fl.Category
                        , String.Join("<br> ", fl.Text.ToArray())
                        );
                    }
                }

                if (fileType == "Classes")
                {
                    ArcReactor.Models.Class.compendium classes = 
                        FromXml<ArcReactor.Models.Class.compendium>(xmlDoc.ToString());
                    /*  class: name, hd, proficiency, spellAbility 
                               autolevel: level 
                                          feature: name, optional, proficiency 
                                                   modifier: category, [value] 
                                                   text: [value] 
                               autolevel: level 
                                          slots: [value] 
                        spell: classes, components, duration, level, name, range, school, time 
                               text: [value] 
                        
                        for attributes, search XML file for: ">  */

                    var classList = (from r in xmlDoc.Descendants("class")
                                     select new
                                     {
                                         Name = r.Element("name").Value.Replace("'", ""),
                                         HD = r.Element("hd").Value.Replace("'", ""),
                                         Prof = r.Element("proficiency").Value.Replace("'", ""),
                                         SpellAbility = (string)r.Element("spellAbility") ?? "",
                                         AutoLevel = (from v in r.Elements("autolevel").Where(x => x.Element("slots") == null)
                                                      select new
                                                      {
                                                          Level = (string)v.Attribute("level"),
                                                          Feature = (from e in v.Elements("feature")
                                                                     select new
                                                                     {
                                                                         FeatureName = e.Element("name").Value.Replace("'", ""),
                                                                         Optional = (string)e.Attribute("optional") ?? "",
                                                                         Proficiency = (string)e.Element("proficiency") ?? "",
                                                                         Modifier = (string)e.Element("modifier") ?? "",
                                                                         Category = (string)e.Element("modifier") != null
                                                                             ? (string)e.Element("modifier").Attribute("category") ?? "" : "",
                                                                         Text = e.Elements("text").Where(x => x.Value != "")
                                                                            .Select(x => x.Value.Replace("'", "")).ToList()
                                                                     }).ToList()
                                                      }
                                                      ).ToList(),
                                         Slots = (from v in r.Elements("autolevel").Where(x => x.Element("slots") != null)
                                                  select new
                                                  {
                                                      Level = (string)v.Attribute("level"),
                                                      Slots = v.Element("slots").Value.Replace("'", "")
                                                  }
                                                  ).ToList()
                                     });

                    var spellList = (from r in xmlDoc.Descendants("spell")
                                     select new
                                     {
                                         Classes = r.Element("classes").Value.Replace("'", ""),
                                         Components = r.Element("components").Value.Replace("'", ""),
                                         Duration = ((string)r.Element("duration") ?? "").Replace("'", ""),
                                         Level = r.Element("level").Value.Replace("'", ""),
                                         Name = r.Element("name").Value.Replace("'", ""),
                                         Range = ((string)r.Element("range") ?? "").Replace("'", ""),
                                         School = r.Element("school").Value.Replace("'", ""),
                                         Time = ((string)r.Element("time") ?? "").Replace("'", ""),
                                         Text = r.Elements("text").Where(x => x.Value != "").Select(x => x.Value.Replace("'", "")).ToList()
                                     });

                    s = @"
CREATE TABLE dbo.Class (Class_ID INT IDENTITY(1,1),Name VARCHAR(MAX), hd VARCHAR(MAX), prof VARCHAR(MAX), spell VARCHAR(MAX))

CREATE TABLE dbo.Class_Levels (Class_id INT, level VARCHAR(MAX), featureName VARCHAR(MAX), optional VARCHAR(MAX), proficiency VARCHAR(MAX), modifier VARCHAR(MAX), category VARCHAR(MAX), text VARCHAR(MAX))

CREATE TABLE dbo.Class_Slots (Class_id INT, level VARCHAR(MAX), slots VARCHAR(MAX))

CREATE TABLE dbo.Class_Spells (Class_id INT, classes VARCHAR(MAX), components VARCHAR(MAX), duration VARCHAR(MAX), level VARCHAR(MAX), name VARCHAR(MAX), range VARCHAR(MAX), school VARCHAR(MAX), time VARCHAR(MAX), text VARCHAR(MAX))

";

                    foreach (var cl in classList)
                    {
                        s += String.Format(@"

                        INSERT dbo.Class (Name, hd, prof, spell)
                        SELECT
                                '{0}'
                                ,'{1}'
                                ,'{2}'
                                ,'{3}'
                                ;
                       ", cl.Name
                        , cl.HD
                        , cl.Prof
                        , cl.SpellAbility
                        );

                        foreach (var lvl in cl.AutoLevel)
                        {
                            foreach (var ft in lvl.Feature)
                            {
                                s += String.Format(@"

                                INSERT dbo.Class_Levels (class_id, level, featureName, optional, proficiency, modifier, category, text)
                                SELECT
                                        (SELECT TOP 1 class_id from dbo.Class where name = '{0}')
                                        ,'{1}'
                                        ,'{2}'
                                        ,'{3}'
                                        ,'{4}'
                                        ,'{5}'
                                        ,'{6}'
                                        ,'{7}'
                                        ;
                                ", cl.Name
                                , lvl.Level
                                , ft.FeatureName
                                , ft.Optional
                                , ft.Proficiency
                                , ft.Modifier
                                , ft.Category
                                , String.Join("<br> ", ft.Text.ToArray())
                                );
                            }
                        }

                        foreach (var sl in cl.Slots)
                        {
                            s += String.Format(@"
                        
                                INSERT dbo.Class_Slots (class_id, level, slots)
                                SELECT
                                        (SELECT TOP 1 class_id from dbo.Class_1 where name = '{0}')
                                        ,'{1}'
                                        ,'{2}'
                                        ;
                                ", cl.Name
                                 , sl.Level
                                 , sl.Slots
                                 );
                        }

                        var spells = (from r in spellList.Where(x => cl.Name.Any(stringToCheck => x.Classes.Contains(cl.Name)))
                                        select r).ToList();
                        if (spells.Count > 0)
                        {
                            foreach(var sp in spells)
                            {
                                s += String.Format(@"
                        
                                INSERT dbo.Class_Spells (class_id, classes, components, duration, level, name, range, school, time, text)
                                SELECT
                                        (SELECT TOP 1 class_id from dbo.Class_1 where name = '{0}')
                                        ,'{1}'
                                        ,'{2}'
                                        ,'{3}'
                                        ,'{4}'
                                        ,'{5}'
                                        ,'{6}'
                                        ,'{7}'
                                        ,'{8}'
                                        ,'{9}'
                                        ;
                                ", cl.Name
                                , sp.Classes
                                , sp.Components
                                , sp.Duration
                                , sp.Level
                                , sp.Name
                                , sp.Range
                                , sp.School
                                , sp.Time
                                , String.Join("<br> ", sp.Text.ToArray())
                                 );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var debug = 1;
            }

            return s;
        }

        protected T FromXml<T>(String xml)
        {
            T returnedXmlClass = default(T);

            try
            {
                using (TextReader reader = new StringReader(xml))
                {
                    try
                    {
                        returnedXmlClass =
                            (T)new XmlSerializer(typeof(T)).Deserialize(reader);
                    }
                    catch (InvalidOperationException ex)
                    {
                        // String passed is not XML
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return returnedXmlClass;
        }
    }
}
