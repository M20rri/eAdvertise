using AutoMapper;
using eAdvertise.Application.DTOs.Advertise;
using eAdvertise.Application.Interfaces.Repositories;
using eAdvertise.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace eAdvertise.Application.Features.Advertise.Command
{
    public record AddCarCommand(CarDto model, Guid userId) : IRequest<Guid>;

    public sealed class AddCarHandler : IRequestHandler<AddCarCommand, Guid>
    {
        private readonly IAdvertiseRepositoryAsync _advertiseRepositoryAsync;
        private readonly IMapper _mapper;
        public AddCarHandler(IAdvertiseRepositoryAsync advertiseRepositoryAsync, IMapper mapper)
        {
            _advertiseRepositoryAsync = advertiseRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(AddCarCommand request, CancellationToken cancellationToken)
        {
            var _car = _mapper.Map<Car>(request.model)
               .Create(request.userId.ToString(), DateTime.UtcNow);

            await _advertiseRepositoryAsync.AddAsync(_car);

            return _car.Id;
        }
    }
}
