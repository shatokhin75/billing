﻿namespace Business.Actions
{
    using Data;

    internal abstract class PerformableAction : IPerformableAction
    {
        public abstract void Perform();

        public IBillingContext DbContext { get; set; }
    }
}
