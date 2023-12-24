using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Queries.GetByIdBrand
{
    public class GetByIdBrandQuery : IRequest<GetByIdBrandResponse>
    {
        public int Id { get; set; }

        public class GetByIdBrandQueryHandle : IRequestHandler<GetByIdBrandQuery, GetByIdBrandResponse>
        {

            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;
            private readonly BrandBusinessRules _brandBusinessRules;
         
            public GetByIdBrandQueryHandle(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandBusinessRules)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
                _brandBusinessRules = brandBusinessRules;
            }

            public async Task<GetByIdBrandResponse> Handle(GetByIdBrandQuery request, CancellationToken cancellationToken)
            {
                Brand brand = await  _brandRepository.GetAsync(b=>b.Id == request.Id);
                _brandBusinessRules.BrandShouldsExistWhenRequested(request.Id);
                GetByIdBrandResponse response = _mapper.Map<GetByIdBrandResponse>(brand);
                return response;
            }
        }
    }
}
