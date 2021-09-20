using Core;
using Services;

namespace Quest1
{
    public class Quest1Context : IStateContext
    {
        public Quest1View View;
        public CoroutineService CoroutineService;

        public Quest1Context(Quest1View view, CoroutineService coroutineService)
        {
            View = view;
            CoroutineService = coroutineService;
        }
    }
}