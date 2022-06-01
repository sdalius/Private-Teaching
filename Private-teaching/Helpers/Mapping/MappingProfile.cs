using AutoMapper;
using Private_teaching.Auth.DTO.Requests;
using Private_teaching.Auth.DTO.Responses;
using Private_teaching.Entities.Questionnaire;
using Private_teaching.Models.DTO;
using Private_teaching.Models.DTO.Responses;
using Private_teaching.Models.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace Private_teaching.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUsers, Teachers>();
            CreateMap<Teachers, TeacherDTOResponse>();
            CreateMap<ApplicationUsers, Student>();
            CreateMap<Student, StudentDTOResponse>();
            CreateMap<Subjects, SubjectDTO>().ReverseMap();
            CreateMap<SubjectDTO, PassedTestsOnSubjects>()
                .ForMember(dest => dest.Subjects, act => act.MapFrom(src => src)).ReverseMap();

            CreateMap<Offers, OfferDTORequest>().ReverseMap();
            CreateMap<Offers, OfferDTOResponse>();
            CreateMap<BookedTimes, BookedTimesOnlyDTOResponse>();
            CreateMap<BookedTimes, BookingTimeDTOResponse>()
                .ForMember(dest => dest.Subjects, act => act.MapFrom(src => src.Booking.Offers.Subjects))
                .ForMember(dest => dest.Teachers, act => act.MapFrom(src => src.Booking.Offers.Teachers))
                .ForMember(dest => dest.Student, act => act.MapFrom(src => src.Student));
            CreateMap<BookTimeDTO, BookedTimes>();

            CreateMap<Questions, QuestionsWithOptionsDTO>();
            //CreateMap<QuestionAnswers, QuestionAnswersDTO>();
            CreateMap<QuestionOptions, QuestionOptionDTOResponse>();
            CreateMap<JwtSecurityToken, TokenDTOResponse>();
        }
    }
}
