using Task.Application.Common.Response;
using Task.Application.Features.ViewModels;
using Task.Application.Interfaces;

namespace Task.Application.Features.Commands
{
    public class UpdateCVCommand : IRequest<ResponseVM>
    {
        public CVRequestModel CVRequest { get; set; }
    }
    public class UpdateCVCommandHandler 
        //: IRequestHandler<UpdateCVCommand, ResponseVM>
    {

        //private readonly ICVManagerService _CVManagerService;

        //public UpdateCVCommandHandler(ICVManagerService CVManagerService)
        //{
        //    _CVManagerService = CVManagerService;
        //}
        //public async Task<ResponseVM> Handle(UpdateCVCommand request, CancellationToken cancellationToken)
        //{
        //    return new ResponseVM()
        //    {
        //        Data = await _CVManagerService.UpdateCV(request.CVRequest),
        //    };
        //}
    }
}
