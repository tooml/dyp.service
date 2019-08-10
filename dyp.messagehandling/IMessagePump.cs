using dyp.messagehandling.pipeline;
using dyp.messagehandling.pipeline.messagecontext;
using dyp.messagehandling.pipeline.messagecontext.messagehandling.pipeline.messagecontext;
using dyp.messagehandling.pipeline.processoroutput;
using nblackbox.contract;
using System;

namespace dyp.messagehandling
{
    public interface IMessagePump
    {
        void Register<TMessage>(IMessageContextManager ctxManager, IMessageProcessor processor);

        void Register<TMessage>(Func<IMessage, IMessageContext> load,
                                Func<IMessage, IMessageContext, Output> process,
                                Action<IRecordedEvent[]> update);

        IMessage Handle(IMessage inputMessage);
    }
}
