using AutoMapper;
using eAdvertise.Application.DTOs.Advertise;
using eAdvertise.Application.Interfaces.Repositories;
using eAdvertise.Application.ViewModels.Advertise;
using eAdvertise.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace eAdvertise.Application.Features.Advertise.Query
{
    public record GetAllAdvertisesQuery(Guid userId) : IRequest<List<AdvertiseVM>>;

    public sealed class GetAllAdvertisesHandler : IRequestHandler<GetAllAdvertisesQuery, List<AdvertiseVM>>
    {
        private readonly ICarRepositoryAsync _CarRepositoryAsync;
        private readonly IMobileRepositoryAsync _MobileRepositoryAsync;
        private readonly IMiscRepositoryAsync _MiscRepositoryAsync;
        private readonly IMapper _mapper;
        public GetAllAdvertisesHandler(ICarRepositoryAsync CarRepositoryAsync , IMobileRepositoryAsync mobileRepositoryAsync , IMiscRepositoryAsync miscRepositoryAsync, IMapper mapper)
        {
            _CarRepositoryAsync = CarRepositoryAsync;
            _MobileRepositoryAsync = mobileRepositoryAsync;
            _MiscRepositoryAsync = miscRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<List<AdvertiseVM>> Handle(GetAllAdvertisesQuery request, CancellationToken cancellationToken)
        {
            var _adverticesVM = new List<AdvertiseVM>();

            var _cars = await _CarRepositoryAsync.FindAllByConditionAsync(a => a.CreatedBy == request.userId.ToString(), new[] { "Images"});
           _adverticesVM.AddRange(_mapper.Map<List<AdvertiseVM>>(_cars));

            var _mobiles = await _MobileRepositoryAsync.FindAllByConditionAsync(a => a.CreatedBy == request.userId.ToString(), new[] { "Images"});
            _adverticesVM.AddRange(_mapper.Map<List<AdvertiseVM>>(_mobiles));

            var _miscs = await _MiscRepositoryAsync.FindAllByConditionAsync(a => a.CreatedBy == request.userId.ToString(), new[] { "Images"});
            _adverticesVM.AddRange(_mapper.Map<List<AdvertiseVM>>(_miscs));

            return _adverticesVM;
        }
    }
}
