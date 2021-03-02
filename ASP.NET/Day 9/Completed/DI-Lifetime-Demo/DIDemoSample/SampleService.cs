using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIDemoSample
{
    public class SampleService : ITransientService, IScopedService, ISingletonService
    {
        Guid guidObj;

        public SampleService()
        {
            guidObj = Guid.NewGuid();
        }
        public Guid GetInstanceId()
        {
            return guidObj;
        }
    }
}
