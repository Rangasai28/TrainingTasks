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
            cnfg.CreateMap<BankVm, Bank>();
            cnfg.CreateMap<BranchVm, Branch>();
        });

        return mapper.CreateMapper();

    }
}
