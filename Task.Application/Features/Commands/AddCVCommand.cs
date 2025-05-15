using Task.Application.Common.Response;
using Task.Application.Features.ViewModels;
using Task.Application.Interfaces;

namespace Task.Application.Features.Commands
{
    public class AddCVCommand : IRequest<ResponseVM>
    {
        public CVRequestModel CVRequest { get; set; }
    }
    public class AddCVCommandHandler : IRequestHandler<AddCVCommand, ResponseVM>
    {

        private readonly ICVManagerService _CVManagerService;

        public AddCVCommandHandler(ICVManagerService CVManagerService)
        {
            _CVManagerService = CVManagerService;
        }
        public async Task<ResponseVM> Handle(AddCVCommand request, CancellationToken cancellationToken)
        {
            return await _CVManagerService.AddCV(request.CVRequest);
        }
    }
}
