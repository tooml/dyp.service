﻿using dyp.messagehandling.pipeline;
using dyp.messagehandling.pipeline.messagecontext;
using dyp.messagehandling.pipeline.messagecontext.messagehandling.pipeline.messagecontext;
using dyp.messagehandling.pipeline.processoroutput;
using nblackbox.contract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dyp.messagehandling
{
    public class MessagePump : IDisposable, IMessagePump
    {
        private class Pipeline
        {
            public Func<IMessage, IMessageContext> LoadContext;
            public Func<IMessage, IMessageContext, Output> Process;
            public Action<IRecordedEvent[]> UpdateContext;
        }

        private readonly Dictionary<Type, Pipeline> _messagePipelineDirectory = new Dictionary<Type, Pipeline>();

        private readonly IBlackBox _es;


        public MessagePump() { }

        public MessagePump(IBlackBox es)
        {
            _es = es;
            _es.OnRecorded += (record) => UpdateContexts(new IRecordedEvent[] { record });
        }


        public void Register<TMessage>(IMessageContextManager ctxManager, IMessageProcessor processor)
            => Register<TMessage>(ctxManager.Load, processor.Process, ctxManager.Update);

        public void Register<TMessage>(Func<IMessage, IMessageContext> load,
                                       Func<IMessage, IMessageContext, Output> process,
                                       Action<IRecordedEvent[]> update)
        {
            _messagePipelineDirectory[typeof(TMessage)] = new Pipeline
            {
                LoadContext = load,
                Process = process,
                UpdateContext = update
            };
        }


        public IMessage Handle(IMessage inputMessage)
        {
            var pipeline = _messagePipelineDirectory[inputMessage.GetType()];
            return Handle(pipeline, inputMessage);
        }

        private IMessage Handle(Pipeline pipeline, IMessage inputMessage)
        {
            var context = pipeline.LoadContext(inputMessage);
            var output = pipeline.Process(inputMessage, context);
            return Dispatch(output);
        }

        private IMessage Dispatch(Output output)
        {
            switch (output)
            {
                case CommandOutput co:
                    _es.Record(co.Events);
                    return co.Status;
                case QueryOutput qo:
                    return qo.Result;
                case NotificationOutput no:
                    no.Commands.ToList().ForEach(cmd => Handle(cmd));
                    return new NoResponse();
            }
            throw new InvalidOperationException("Unknown output type: " + output.GetType());
        }

        private void UpdateContexts(IRecordedEvent[] events)
        {
            foreach (var update in _messagePipelineDirectory.Values
                                                            .Select(handlers => handlers.UpdateContext))
                update(events);
        }

        public void Dispose() { }
    }
}