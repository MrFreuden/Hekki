using Hekki.App;
using Hekki.Domain.Models;

namespace Hekki.Infrastructure
{
    public class RegulationsRep
    {
        public static Regulation GetRegulation()
        {
            return new TestRegulation();
        }
    }
}
