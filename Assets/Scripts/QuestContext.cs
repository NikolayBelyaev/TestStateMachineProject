using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

public class QuestContext : IStateContext
{
    public List<GameStepModel> GameSteps;
    public QuestView View;

    public QuestContext(List<GameStepModel> gameSteps)
    {
        GameSteps = gameSteps;
    }
}
