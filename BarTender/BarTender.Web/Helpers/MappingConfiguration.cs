namespace BarTender.Web.Helpers
{
    using AutoMapper;
    using BarTender.Data.Models;
    using BarTender.Web.Models.Account.InputModels;

    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            this.CreateMap<RegisterInputModel, User>();
        }
    }
}
