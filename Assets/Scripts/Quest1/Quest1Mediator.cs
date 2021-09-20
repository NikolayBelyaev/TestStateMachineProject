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
            stateMachine.StartSequence<Quest1State1>();
        }
    }
}