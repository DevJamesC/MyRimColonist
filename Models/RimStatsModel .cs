namespace WebApplication1.Models
{
    public class RimStatsModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public int BiologicalAge { get; set; }
        public int ChronologicalAge { get; set; }

        public RimworldSubjectData[] Subjects { get; set; }
        public RimStatsModel()
        {
            FirstName = "first";
            LastName = "last";
            NickName = "";
            BiologicalAge = 21;
            ChronologicalAge = 200;

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
}