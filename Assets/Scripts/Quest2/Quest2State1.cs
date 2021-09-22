using Core;
using UnityEngine;

namespace Quest2
{
    public class Quest2State1 : StateBase<QuestContext>
    {
        public override void OnEnter()
        {
            base.OnEnter();
            
            Context.View.SetColor(Color.green);
            Context.CoroutineService.WaitForTime(2f).Then(() => QuestStepActivatorService.ActivateNext(Sequence));

        }
    }
}
