using Ardalis.Specification;
using Task.Domain.Entities;
namespace Task.Infrastructure.Specifications.CVSpecifications
{
    public class getCVByIdSpec : Specification<CV>
    {
        public getCVByIdSpec(int id)
        {
            Query
                .Where(item => item.Id == id).Include(p => p.PersonalInformation).Include(e => e.ExperienceInformation);
        }
    }

}
