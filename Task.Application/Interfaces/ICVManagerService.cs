using Task.Application.Common.Response;
using Task.Application.Features.ViewModels;

namespace Task.Application.Interfaces
{
    public interface ICVManagerService
    {
        Task<ResponseVM<CVModel>> GetCVDetailsById(int cvId);
        Task<ResponseVM<List<CVModel>>> GetCVs();
        Task<ResponseVM> AddCV(CVRequestModel CVRequest);
        Task<bool> UpdateCV(CVRequestModel CVUpdateRequest);
        Task<bool> DeleteCV(int cvId);
    }
}
