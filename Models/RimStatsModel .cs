namespace WebApplication1.Models
{
    public class RimStatsModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public int BiologicalAge { get; set; }
        public int ChronologicalAge { get; set; }
        public int ChildhoodBackstoryIndex { get; set; }
        public int AdultBackstoryIndex { get; set; }
        public RimworldSubjectData[] Subjects { get; set; }


        public RimworldBackstory[] childhoodBackstoryList;
        public RimworldBackstory[] adultBackstoryList;
        public RimStatsModel()
        {
            FirstName = "first";
            LastName = "last";
            NickName = "";
            BiologicalAge = 21;
            ChronologicalAge = 200;
            ChildhoodBackstoryIndex = 0;
            AdultBackstoryIndex = 0;

            //still need injuries and health conditions

            childhoodBackstoryList = new RimworldBackstory[] {
                new RimworldBackstory(){
                    Name="Colony Child",
                    Description="Born and raised in the colony"
                },
                new RimworldBackstory(){
                    Name="Test 1",
                    SubjectStatChanges = new List<RimworldSubjectData>(){ new RimworldSubjectData("Shooting") {Level=2 }, new RimworldSubjectData("Mining") {Level=-1 } },
                    Description="Test child backstory"
                },
                new RimworldBackstory(){
                    Name="Test 2",
                    DisabledTasks=new string[]{ "Violence", "Cooking"},
                    SubjectStatChanges = new List<RimworldSubjectData>(){ new RimworldSubjectData("Mining") {Level=5 }, new RimworldSubjectData("Social") {Level=-3 } },
                    Description="Test child backstory- no violence or cooking"
                },
            };

            adultBackstoryList = new RimworldBackstory[] {
                new RimworldBackstory(){
                    Name="Colonist",
                    Description="Lived in the colony all your life"
                },
                 new RimworldBackstory(){
                    Name="Test 1",
                    DisabledTasks=new string[]{"Social"},
                    SubjectStatChanges = new List<RimworldSubjectData>(){ new RimworldSubjectData("Medical") {Level=3 } },
                    Description="Test adult backstory- no social"
                },
                 new RimworldBackstory(){
                    Name="Test 2",
                    DisabledTasks=new string[]{"Dumb Labor"},
                    SubjectStatChanges = new List<RimworldSubjectData>(){ new RimworldSubjectData("Artisting") {Level=3 },new RimworldSubjectData("Animals") {Level=2 },new RimworldSubjectData("Plants") {Level=-2 } },
                    Description="Test adult backstory- no dumb labor"
                },
            };

            Subjects = new RimworldSubjectData[]
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
    }

    public class RimworldSubjectData
    {
        public string Name { get; set; } = "NA";
        public int Level { get; set; } = 0;
        public string Passion => PassionStringFromVal(PassionVal);
        public int PassionVal { get; set; } = 1;

        public RimworldSubjectData()
        {
        }
        public RimworldSubjectData(string name)
        {
            Name = name;
        }


        private string PassionStringFromVal(int val)
        {
            string returnVal = "NA";
            switch (val)
            {
                case 0: returnVal = "Apathy"; break;
                case 1: returnVal = "Normal"; break;
                case 2: returnVal = "Passon"; break;
                case 3: returnVal = "Burning Passion"; break;
                case 4: returnVal = "Critical Passion"; break;
            }
            return returnVal;
        }
    }

    public class RimworldBackstory
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string[] DisabledTasks { get; set; }
        public List<RimworldSubjectData> SubjectStatChanges { get; set; }

        public RimworldBackstory()
        {
            Name = "";
            Description = "";
            DisabledTasks = new string[0];
            SubjectStatChanges = new List<RimworldSubjectData>();
        }
    }
}