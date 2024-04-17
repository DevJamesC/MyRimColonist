using WebApplication1.Models;

namespace MyRimColonist
{
    public static class DataProvider
    {

        public static string[] sources = new string[] { "Base", "BioTech", "Ideology", "Royalty", "Anomaly", "Vanilla Skills Expanded", "Vanilla Traits Expanded", "Vanilla Backgrounds Expanded" };

        public static RimworldSubjectData[] GetSubjectData()
        {
            return new RimworldSubjectData[]
            {
                new RimworldSubjectData("Shooting"),
                new RimworldSubjectData("Melee"),
                new RimworldSubjectData("Construction"),
                new RimworldSubjectData("Mining"),
                new RimworldSubjectData("Cooking"),
                new RimworldSubjectData("Plants"),
                new RimworldSubjectData("Animals"),
                new RimworldSubjectData("Crafting"),
                new RimworldSubjectData("Artisting"),
                new RimworldSubjectData("Medical"),
                new RimworldSubjectData("Social"),
                new RimworldSubjectData("Intellectual"),
            };
        }

        public static RimworldBackstory[] GetTraitList()
        {
            return new RimworldBackstory[] {
                new RimworldBackstory(){
                    Name="Gourmand",
                    Description="NAME's life revolves around food. S/He gets hungry quickly, and if s/he is in a bad mood, s/he will often satisfy her/his-self by eating.",
                    SubjectStatChanges = new List<RimworldSubjectData>(){ new RimworldSubjectData("Cooking") {Level=4 } },
                    Source=sources[0]

                },
                new RimworldBackstory(){
                    Name="Test 1",
                    Description="Test trait 1",
                    Source=sources[1]
                },
                new RimworldBackstory(){
                    Name="Test 2",
                    DisabledTasks=new string[]{ "Violent"},
                    Description="Test 2- no violent",
                    Source=sources[2]
                },
            };
        }

        public static RimworldBackstory[] GetChildBackstoryList()
        {
            return new RimworldBackstory[] {
                new RimworldBackstory(){
                    Name="Colony Child",
                    Description="Born and raised in the colony",
                    Source=sources[0]

                },
                new RimworldBackstory(){
                    Name="Test 1",
                    SubjectStatChanges = new List<RimworldSubjectData>(){ new RimworldSubjectData("Shooting") {Level=2 }, new RimworldSubjectData("Mining") {Level=-1 } },
                    Description="Test child backstory",
                    Source=sources[1]
                },
                new RimworldBackstory(){
                    Name="Test 2",
                    DisabledTasks=new string[]{ "Violent", "Cooking"},
                    SubjectStatChanges = new List<RimworldSubjectData>(){ new RimworldSubjectData("Mining") {Level=5 }, new RimworldSubjectData("Social") {Level=-3 } },
                    Description="Test child backstory- no violence or cooking",
                    Source=sources[2]
                },
            };
        }

        public static RimworldBackstory[] GetAdultBackstoryList()
        {
            return new RimworldBackstory[] {
                new RimworldBackstory(){
                    Name="Colonist",
                    Description="Lived in the colony all your life",
                    Source=sources[0]
                },
                 new RimworldBackstory(){
                    Name="Test 1",
                    DisabledTasks=new string[]{"Social"},
                    SubjectStatChanges = new List<RimworldSubjectData>(){ new RimworldSubjectData("Medical") {Level=3 } },
                    Description="Test adult backstory- no social",
                    Source=sources[1]
                },
                 new RimworldBackstory(){
                    Name="Test 2",
                    DisabledTasks=new string[]{"Dumb Labor"},
                    SubjectStatChanges = new List<RimworldSubjectData>(){ new RimworldSubjectData("Artisting") {Level=3 },new RimworldSubjectData("Animals") {Level=2 },new RimworldSubjectData("Plants") {Level=-2 } },
                    Description="Test adult backstory- no dumb labor",
                    Source=sources[2]
                },
            };
        }
    }
}
