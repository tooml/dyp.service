
namespace dyp.data
{
    public class Team
    {
        public Competitor Member_one { get; set; }
        public Competitor Member_two { get; set; }

        public string Get_team_name()
        {
            return string.Concat(Member_one.Person.Get_person_full_name(), " / ", 
                                 Member_two.Person.Get_person_full_name());
        }
    }
}
