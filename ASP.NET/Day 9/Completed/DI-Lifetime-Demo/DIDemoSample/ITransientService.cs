﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIDemoSample
{
    public interface ITransientService
    {
        Guid GetInstanceId();
    }

}
