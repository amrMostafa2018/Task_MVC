﻿using Ardalis.SharedKernel;
using AutoMapper;
using Task.Application.Common.Exceptions;
using Task.Application.Common.Response;
using Task.Application.Features.ViewModels;
using Task.Application.Interfaces;
using Task.Domain.Entities;
using Task.Infrastructure.Specifications.CVSpecifications;
using FluentValidation.Results;

namespace Task.Infrastructure.Services
{
    public class CVManagerService
        //:ICVManagerServices
    {
        //private readonly IRepository<CV> _repository;
        //private readonly IMapper _mapper;
        //public CVManagerService(IRepository<CV> repository, IMapper mapper)
        //{
        //    _repository = repository;
        //    _mapper = mapper;
        //}
        //public async Task<ResponseVM> AddCV(CVRequestModel CVRequest)
        //{
        //    var CV = MappedModelToEntity(CVRequest);
        //    await _repository.AddAsync(CV);
        //    return new ResponseVM
        //    {
        //        Data = CV.Id
        //    };
        //}

        //public async Task<ResponseVM<CVModel>> GetCVDetailsById(int cvId)
        //{
        //    var spec = new getCVByIdSpec(cvId);
        //    var Cv = await _repository.FirstOrDefaultAsync(spec);
        //    if (Cv == null)
        //        throw new ValidationException(new ValidationFailure[] { new ValidationFailure("Get CV Error", $"CV with ID {cvId} : not exist") });
        //    var CVModel = _mapper.Map<CVModel>(Cv);
        //    return new ResponseVM<CVModel>()
        //    {
        //        Data = CVModel
        //    };
        //}

        //public async Task<ResponseVM<List<CVModel>>> GetCVs()
        //{
        //    var spec = new getAllCVsSpec();
        //    var CVList = await _repository.ListAsync(spec);
        //    var Data = _mapper.Map<List<CVModel>>(CVList);
        //    return new ResponseVM<List<CVModel>>()
        //    {
        //        Data = Data
        //    };
        //}

        //public async Task<bool> UpdateCV(CVRequestModel CVUpdateRequest)
        //{
        //    var spec = new getCVByIdSpec(CVUpdateRequest.Id);
        //    var GetCvBySpec = await _repository.FirstOrDefaultAsync(spec);
        //    if (GetCvBySpec == null)
        //        throw new ValidationException(new ValidationFailure[] { new ValidationFailure("Get CV Error", $"CV with ID {CVUpdateRequest.Id} : not exist") });
        //    _mapper.Map(CVUpdateRequest, GetCvBySpec);
        //    //_mapper.Map(CVUpdateRequest, GetCvBySpec.ExperienceInformation);
        //    //_mapper.Map(CVUpdateRequest, GetCvBySpec.PersonalInformation);
        //    await _repository.UpdateAsync(GetCvBySpec);
        //    return true;
        //}
        //public async Task<bool> DeleteCV(int cvId)
        //{
        //    var spec = new getCVByIdSpec(cvId);
        //    var Cv = await _repository.FirstOrDefaultAsync(spec);
        //    if (Cv == null)
        //        throw new ValidationException(new ValidationFailure[] { new ValidationFailure("Get CV Error", $"CV with ID {cvId} : not exist") });
        //    await _repository.DeleteAsync(Cv);
        //    return true;
        //}


        //private CV MappedModelToEntity(CVRequestModel CVRequestModel)
        //{
        //    var CV = _mapper.Map<CV>(CVRequestModel);
        //   // CV.PersonalInformation = _mapper.Map<PersonalInformation>(CVRequestModel);
        //   // CV.ExperienceInformation = _mapper.Map<ExperienceInformation>(CVRequestModel);
        //    return CV;
        //}
    }
}
