using Ardalis.Specification;
using Task.Domain.Entities;
namespace Task.Infrastructure.Specifications.CVSpecifications
{
    public class getAllCVsSpec : Specification<CV>
    {
        public getAllCVsSpec()
        {
            Query
                .Include(n => n.PersonalInformation)
                .Include(e => e.ExperienceInformation);
        }
    }

}
