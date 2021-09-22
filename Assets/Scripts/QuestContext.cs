using System.Collections;
using System.Collections.Generic;
using Core;
using Services;
using UnityEngine;

public class QuestContext : IStateContext
{
    public List<GameStepModel> GameSteps;
    public QuestView View;
    public QuestStepActivatorService QuestStepActivatorService;
    public CoroutineService CoroutineService;

    public QuestContext(List<GameStepModel> gameSteps, QuestView view, CoroutineService cs)
    {
        GameSteps = gameSteps;
        View = view;
        CoroutineService = cs;
    }
}
