using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Actions
{
    using Data;

    internal abstract class PerformableAction<T> : IPerformableAction<T>
    {
        public abstract T Perform();

        public IBillingContext DbContext { get; set; }
    }
}
