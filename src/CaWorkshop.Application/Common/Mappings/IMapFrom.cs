namespace CaWorkshop.Application.Common.Mappings;
using AutoMapper;

public interface IMapFrom<TSource>
{
    void Mapping(Profile profile)
        => profile.CreateMap(typeof(TSource), destinationType: GetType());
}

