using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Activity,Activity>(); // we are mapping command class bhitra ko activity to activity
        }
    }
}