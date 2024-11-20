using api_personal.DTOS.OutputDTO;
using api_personal.Entities;
using AutoMapper;

namespace api_personal.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AcademiaEntity, AcademiaOutputDTO>()
                .ForMember(dest => dest.Id, map => map.MapFrom(src => $"{src.Aca_id}"))
                .ForMember(dest => dest.Nome, map => map.MapFrom(src => src.Aca_nome))
                .ForMember(dest => dest.Latitude, map => map.MapFrom(src => src.Aca_latitude))
                .ForMember(dest => dest.Longitude, map => map.MapFrom(src => src.Aca_longitude))
                .ForMember(dest => dest.Endereco, map => map.MapFrom(src => src.Aca_endereco))
                .ForMember(dest => dest.Telefone, map => map.MapFrom(src => src.Aca_telefone))
                .ForMember(dest => dest.Email, map => map.MapFrom(src => src.Aca_email))
                .ForMember(dest => dest.Logo, map => map.MapFrom(src => src.Aca_logo))
                .ReverseMap();

            CreateMap<PersonalEntity, PersonalOutputDTO>()
                .ForMember(dest => dest.Id, map => map.MapFrom(src => $"{src.Per_id}"))
                .ForMember(dest => dest.Nome, map => map.MapFrom(src => src.Per_nome))
                .ForMember(dest => dest.Telefone, map => map.MapFrom(src => src.Per_telefone))
                .ForMember(dest => dest.CREF, map => map.MapFrom(src => src.Per_cref))
                .ForMember(dest => dest.Especialidade, map => map.MapFrom(src => src.Per_especialidade))
                .ForMember(dest => dest.Foto, map => map.MapFrom(src => src.Per_foto))
                .ForMember(dest => dest.Ativo, map => map.MapFrom(src => src.Per_ativo))
                .ForMember(dest => dest.Confirmado, map => map.MapFrom(src => src.Per_confirmado))
                .ForMember(dest => dest.Email, map => map.MapFrom(src => src.Per_email))
                .ReverseMap();

            CreateMap<AcademiaPersonalEntity, AcademiaPersonalOutputDTO>()
                .ForMember(dest => dest.Id, map => map.MapFrom(src => $"{src.Acp_id}"))
                .ForMember(dest => dest.AcademiaId, map => map.MapFrom(src => $"{src.Acp_aca_id}"))
                .ForMember(dest => dest.PersonalId, map => map.MapFrom(src => $"{src.Acp_per_id}"))
                .ForMember(dest => dest.Valor, map => map.MapFrom(src => $"{src.Acp_valor}"))
                .ForMember(dest => dest.DataInicio, map => map.MapFrom(src => $"{src.Acp_data_inicio}"))
                .ReverseMap();
        }
    }
}
