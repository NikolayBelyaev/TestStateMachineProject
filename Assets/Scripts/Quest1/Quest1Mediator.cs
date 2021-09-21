using System;
using Core;
using Services;
using UnityEngine;

namespace Quest1
{
    public class Quest1Mediator : MonoBehaviour
    {
        private void OnEnable()
        {
            var view = FindObjectOfType<Quest1View>();
            var coroutineService = FindObjectOfType<CoroutineService>();
            var stateMachine = StateMachine.Create(new Quest1Context(view, coroutineService));
            
            var targetStateType = Type.GetType("Quest1.Quest1State1");
            //recommend to check if type implements IState or change something in StateMachine to use generic
            if (targetStateType == null || !typeof(IState).IsAssignableFrom(targetStateType))
            {
                throw new ArgumentException($"Wrong type {targetStateType?.FullName}. Type must implements IState");
            }
            
            stateMachine.StartSequence(targetStateType);
        }
    }
}