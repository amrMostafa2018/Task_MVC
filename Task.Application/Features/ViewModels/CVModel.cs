using Task.Domain.Entities;

namespace Task.Application.Features.ViewModels
{
    public class CVModel : CVRequestModel
    {
        public int Id { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                //CreateMap<CV, CVModel>()
                    //.ForMember(d => d.FullName, opt => opt.MapFrom(s => s.PersonalInformation.FullName))
                    //.ForMember(d => d.CityName, opt => opt.MapFrom(s => s.PersonalInformation.CityName))
                    //.ForMember(d => d.Email, opt => opt.MapFrom(s => s.PersonalInformation.Email))
                    //.ForMember(d => d.MobileNumber, opt => opt.MapFrom(s => s.PersonalInformation.MobileNumber))
                    //.ReverseMap();
                
            }
        }
    }
}
