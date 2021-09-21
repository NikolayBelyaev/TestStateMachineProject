using System;
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
            var targetStateType = Type.GetType("Quest1.Quest1State1");
            Context.CoroutineService.WaitForTime(2).Then(() => Sequence.ActivateState(targetStateType));
        }
    }
}