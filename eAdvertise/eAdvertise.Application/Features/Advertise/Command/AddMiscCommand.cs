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
    public record AddMiscCommand(MiscDto model, Guid userId) : IRequest<Guid>;
    public sealed class AddMiscHandler : IRequestHandler<AddMiscCommand, Guid>
    {
        private readonly IAdvertiseRepositoryAsync _advertiseRepositoryAsync;
        private readonly IMapper _mapper;

        public AddMiscHandler(IAdvertiseRepositoryAsync advertiseRepositoryAsync, IMapper mapper)
        {
            _advertiseRepositoryAsync = advertiseRepositoryAsync;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(AddMiscCommand request, CancellationToken cancellationToken)
        {
            var _car = _mapper.Map<Misc>(request.model)
                 .Create(request.userId.ToString(), DateTime.UtcNow);

            await _advertiseRepositoryAsync.AddAsync(_car);

            return _car.Id;
        }
    }
}
