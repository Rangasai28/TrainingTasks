using AutoMapper;
using DigitalBankingApi.Core.Models;
using DigitalBankingApi.ViewModels;
namespace DigitalBankingApi.Configurations;

public class AutoMapperConfiguration
{
    public static IMapper IntializeMapper()
    {
        var mapper = new MapperConfiguration(cnfg =>
        {
            cnfg.CreateMap<RegistrationVm, Customer>();
           // cnfg.CreateMap<StudentDtoPut, Student>();
        });

        return mapper.CreateMapper();

    }
}
