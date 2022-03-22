using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VY.MenuActions.Dtos;
using VY.MenuActions.Infraestructure.Contracts.Entities;

namespace VY.MenuActions.Business.Impl.Mapping_Profiles
{
    public class MenuActionProfile : Profile
    {
        public MenuActionProfile()
        {
            CreateMap<MenuActionDto, MenuAction>()
                .ForMember(x => x.Id, opt => opt.MapFrom(y => y.Id))
                .ForMember(x => x.InverseReportsToNavigation, opt => opt.MapFrom(y => y.InverseReportsToNavigation))
                .ForMember(x => x.Name, opt => opt.MapFrom(y => y.Name))
                .ForMember(x => x.ReportsToNavigation, opt => opt.MapFrom(y => y.ReportsToNavigation))
                .ForMember(x => x.Action, opt => opt.MapFrom(y => y.Action))
                .ReverseMap();
        }
    }
}
