using nblackbox.contract;

namespace dyp.messagehandling.pipeline.processoroutput
{
    public class CommandOutput : Output
    {
        public CommandStatus Status { get; }
        public IEvent[] Events { get; }

        public CommandOutput(Success status, IEvent[] events)
        {
            Status = status;
            Events = events;
        }

        public CommandOutput(Failure failure)
        {
            Status = failure;
            Events = new IEvent[0];
        }
    }
}