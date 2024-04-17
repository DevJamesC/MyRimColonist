using MyRimColonist;

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
        public RimworldBackstory[] TraitList;
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

            childhoodBackstoryList = DataProvider.GetChildBackstoryList();
            adultBackstoryList = DataProvider.GetAdultBackstoryList();
            TraitList = DataProvider.GetTraitList();
            Subjects = DataProvider.GetSubjectData();


        }

        public int GetNetSkillVal(string subjectName)
        {
            int returnVal = 0;
            int childModVal = 0;
            int adultModVal = 0;

            RimworldBackstory childBackstory = childhoodBackstoryList[ChildhoodBackstoryIndex];
            RimworldBackstory adultBackstory = adultBackstoryList[AdultBackstoryIndex];
            RimworldSubjectData subjectData = Subjects.Where(subj => subj.Name.Equals(subjectName)).First();

            List<RimworldSubjectData> childDatas = new(childBackstory.SubjectStatChanges.Where(subj => subj.Name.Equals(subjectName)));
            if (childDatas.Count > 0) { childModVal = childDatas[0].Level; }

            List<RimworldSubjectData> adultDatas = new(adultBackstory.SubjectStatChanges.Where(subj => subj.Name.Equals(subjectName)));
            if (adultDatas.Count > 0) { adultModVal = adultDatas[0].Level; }

            returnVal = Math.Clamp(subjectData.Level + childModVal + adultModVal, 0, 20);
            return returnVal;
        }

        public string GetPassionString(string subjectName)
        {
            RimworldSubjectData subjectData = Subjects.Where(subj => subj.Name.Equals(subjectName)).First();
            string passionString = subjectData.Passion;
            if (passionString == "Normal")
            {
                passionString = "";
            }
            return passionString;
        }
    }

    public class RimworldSubjectData
    {
        public string Name { get; set; } = "NA";
        public int Level { get; set; } = 0;
        public string Passion => PassionStringFromVal(PassionVal);
        public int PassionVal { get; set; } = 1;

        public bool Disabled { get; set; } = false;

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
        public string Source { get; set; }

        public RimworldBackstory()
        {
            Name = "";
            Description = "";
            DisabledTasks = new string[0];
            SubjectStatChanges = new List<RimworldSubjectData>();
            Source = "";
        }
    }
}