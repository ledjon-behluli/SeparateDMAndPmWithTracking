using System;

namespace SeparateDMAndPMWithTrackingV2.Domain
{
    public class Status
    {
        private IBankAccountState _state;

        public Status(IBankAccountState state)
        {
            if (state.Frozen)
                ThrowIfNoReason(state.Reason);

            _state = state;
        }

        public void Freeze(string reason)
        {
            ThrowIfNoReason(reason);

            _state.Frozen = true;
            _state.Reason = reason;
        }

        public void Unfreeze()
        {
            _state.Frozen = false;
            _state.Reason = string.Empty;
        }


        private void ThrowIfNoReason(string reason)
        {
            if (string.IsNullOrEmpty(reason))
                throw new Exception(
                    "A reason must exist for a frozen account");
        }
    }
}
