using Core;
using UnityEngine;

namespace Quest1
{
    public class Quest1State2 : StateBase<Quest1Context>
    {
        public override void OnEnter()
        {
            base.OnEnter();
            
            Context.View.Image.color = Color.red;
            Context.CoroutineService.WaitForTime(2).Then(() => Sequence.ActivateState<Quest1State1>());
        }
    }
}