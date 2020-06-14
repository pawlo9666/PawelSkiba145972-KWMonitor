using KoronaWirusMonitor3.Models;
using KWMonitor.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KWMonitor.Profile
{
    public class KWMProfile : AutoMapper.Profile
    {
        public KWMProfile()
        {
            CreateMap<Country, CountryDTO>()
                .ReverseMap();


            CreateMap<Region, RegionDTO>()
                .ForMember(Region => Region.Country, opt => opt.MapFrom(region => region.Country))
                .ReverseMap();
            CreateMap<Region, CreateRegion>()
                .ForMember(Region => Region.CountryID , opt => opt.MapFrom(region => region.CountryID))
                .ReverseMap();

            CreateMap<District, DistrictDTO>()
                .ForMember(District => District.Region, opt => opt.MapFrom(district => district.Region))
                .ReverseMap();
            CreateMap<District, CreateDistrict>()
                .ForMember(District => District.RegionID, opt => opt.MapFrom(district => district.RegionId))
                .ReverseMap();

            CreateMap<City, CityDTO>()
            .ForMember(District => District.District, opt => opt.MapFrom(district => district.District))
            .ReverseMap();
            CreateMap<City, CreateCity>()
                .ForMember(City => City.DistrictId, opt => opt.MapFrom(city => city.DistrictId))
                .ReverseMap();

        }
    }
}
