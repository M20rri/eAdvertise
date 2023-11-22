using AutoMapper;
using eAdvertise.Application.DTOs.Advertise;
using eAdvertise.Application.ViewModels.Advertise;
using eAdvertise.Domain.Entities;

namespace eAdvertise.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            //CreateMap<Advertise, AdvertiseVM>()
            //.ForMember(dest => dest.Id, target => target.MapFrom(src => src.Id))
            //.ForMember(dest => dest.Title, target => target.MapFrom(src => src.Title))
            //.ForMember(dest => dest.PostDate, target => target.MapFrom(src => src.Created))
            //.ForMember(dest => dest.Images, target => target.MapFrom(src => src.Images))
            ////.ForMember(dest => dest.InternalStorage, target => target.MapFrom(src => src))
            //.ForMember(dest => dest.IsPremium, target => target.MapFrom(src => src.IsPremium)).ReverseMap();

            CreateMap<Car, AdvertiseVM>()
            .ForMember(dest => dest.Id, target => target.MapFrom(src => src.Id))
            .ForMember(dest => dest.Title, target => target.MapFrom(src => src.Title))
            .ForMember(dest => dest.PostDate, target => target.MapFrom(src => src.Created))
            .ForMember(dest => dest.Images, target => target.MapFrom(src => src.Images))
            .ForMember(dest => dest.Mileage, target => target.MapFrom(src => src.Mileage))
            .ForMember(dest => dest.IsPremium, target => target.MapFrom(src => src.IsPremium)).ReverseMap();

            CreateMap<Misc, AdvertiseVM>()
            .ForMember(dest => dest.Id, target => target.MapFrom(src => src.Id))
            .ForMember(dest => dest.Title, target => target.MapFrom(src => src.Title))
            .ForMember(dest => dest.PostDate, target => target.MapFrom(src => src.Created))
            .ForMember(dest => dest.Images, target => target.MapFrom(src => src.Images))
            .ForMember(dest => dest.IsPremium, target => target.MapFrom(src => src.IsPremium)).ReverseMap();


            CreateMap<Mobile, AdvertiseVM>()
            .ForMember(dest => dest.Id, target => target.MapFrom(src => src.Id))
            .ForMember(dest => dest.Title, target => target.MapFrom(src => src.Title))
            .ForMember(dest => dest.PostDate, target => target.MapFrom(src => src.Created))
            .ForMember(dest => dest.Images, target => target.MapFrom(src => src.Images))
            .ForMember(dest => dest.InternalStorage, target => target.MapFrom(src => src.InternalStorage))
            .ForMember(dest => dest.IsPremium, target => target.MapFrom(src => src.IsPremium)).ReverseMap();


            CreateMap<Car, CarDto>().ReverseMap();
            CreateMap<Misc, MiscDto>().ReverseMap();
            CreateMap<Mobile, MobileDto>().ReverseMap();
            CreateMap<Image, ImageDto>().ReverseMap();
        }
    }
}