﻿using System;

namespace Core
{
    public abstract class StateBase<TContext> : IDisposable, IState where TContext : class, IStateContext
    {
        protected TContext Context { get; private set; }
        protected IStateMachine StateMachine { get; private set; }
        
        protected  IStateSequence Sequence { get; private set; }
        
        public void Setup(IStateContext stateContext, IStateMachine stateMachine, IStateSequence sequence)
        {
            Context = stateContext as TContext;
            StateMachine = stateMachine;
            Sequence = sequence;
        }

        public virtual void OnEnter()
        {
        }

        public virtual void OnExit()
        {
            Dispose();
        }

        public virtual void Dispose()
        {
            Context = null;
            StateMachine = null;
            Sequence = null;
            
            GC.SuppressFinalize(this);
        }
    }
}