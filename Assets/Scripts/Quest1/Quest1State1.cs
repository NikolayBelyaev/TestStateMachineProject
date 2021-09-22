using System;
using Core;
using UnityEngine;

namespace Quest1
{
    public class Quest1State1 : StateBase<QuestContext>
    {
        public override void OnEnter()
        {
            base.OnEnter();
            
            Context.View.SetColor(Color.black);
        }
    }
}