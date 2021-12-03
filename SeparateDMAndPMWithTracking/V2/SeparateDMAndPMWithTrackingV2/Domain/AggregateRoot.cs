using System;

namespace SeparateDMAndPMWithTrackingV2.Domain
{
    public abstract class AggregateRoot<T> where T : class, ICloneable
    {
        protected readonly T _state;

        public AggregateRoot(T state)
        {
            if (state == null)
                throw new ArgumentNullException(nameof(state));

            _state = state;
        }

        public T GetState()
        {
            return _state.Clone() as T;
        }
    }
}
