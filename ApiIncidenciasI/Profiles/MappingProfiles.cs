using ApiIncidenciasI.Dtos;
using Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiIncidenciasI.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Area, AreaDto>().ReverseMap();
        CreateMap<ContactCategory, ContactCategoryDto>().ReverseMap();
        CreateMap<Contact, ContactDto>().ReverseMap();
        CreateMap<ContactType, ContactTypeDto>().ReverseMap();
        CreateMap<DocType, DocTypeDto>().ReverseMap();
        CreateMap<IncidenceDetail, IncidenceDetailDto>().ReverseMap();
        CreateMap<Incidence, IncidenceDto>().ReverseMap();
        CreateMap<IncidenceLevel, IncidenceLevelDto>().ReverseMap();
        CreateMap<IncidenceType, IncidenceTypeDto>().ReverseMap();
        CreateMap<Place, PlaceDto>().ReverseMap();
        CreateMap<Role, RoleDto>().ReverseMap();
        CreateMap<State, StateDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<WorkTool, WorkToolDto>().ReverseMap();
    }
}