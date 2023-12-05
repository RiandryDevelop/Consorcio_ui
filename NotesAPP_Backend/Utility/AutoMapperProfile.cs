using AutoMapper;
using NotesAPP_Backend.DTOs;
using NotesAPP_Backend.Models;
using System.Globalization;


namespace NotesAPP_Backend.Utility
{
    public class AutoMapperProfile: Profile
    {
     public AutoMapperProfile() {

            CreateMap<TagsName, TagsNameDTO>().ReverseMap();

            CreateMap<NotesScheme, NotesSchemeDTO>()
                .ForPath(destination => destination.TagNameId, option => option
                    .MapFrom(origen => origen.TagName.TagNameId))
                .ForPath(destination => destination.CreationDate, option => option
                    .MapFrom(origen => origen.CreationDate.Value.ToString("MM/dd/yyyy")));

            CreateMap<NotesSchemeDTO, NotesScheme>()
                .ForPath(destination => destination.TagName.TagNameId, option => option
                    .Ignore())
                .ForPath(destination => destination.CreationDate, option => option
                    .MapFrom(origen => DateTime.ParseExact(origen.CreationDate, "MM/dd/yyyy", CultureInfo.InvariantCulture)));



        }
    }
}
