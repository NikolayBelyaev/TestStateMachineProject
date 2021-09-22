using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core;
using UnityEngine;

public class GameScenarioService : MonoBehaviour
{
    public List<GameStepModel> GameSteps { get; private set; }
    public GameStepModel CurrentStep;

    private IStateMachine _gameStateMachine;

    public GameStepModel NextStep
    {
        get
        {
            var nextIndex = GameSteps.IndexOf(CurrentStep) + 1;
            return nextIndex == GameSteps.Count ? null : GameSteps[nextIndex];
        }
    }

// Fake downloader/parser
    private async Task<List<GameStepModel>> DownloadScenarioSteps()
    {
        return new List<GameStepModel>()
        {
            new GameStepModel("1", "1"),
            new GameStepModel("1", "2"),
            new GameStepModel("2", "1")
        };
    }

    private string TargetType => $"{CurrentStep.Quest_ID}.{CurrentStep.Quest_ID}{CurrentStep.Step_ID}";

    private async void Start()
    {
        var download = await DownloadScenarioSteps();
        GameSteps = download.ToList();
    }

    public void StartGameSequence()
    {
        if (GameSteps == null)
        {
            throw new NullReferenceException("Game steps were not downloaded from the CDN for the moment");
        }

        _gameStateMachine = StateMachine.Create(new QuestContext(GameSteps));
        CurrentStep = GameSteps[0];

        var initStateType = Type.GetType(TargetType);
        _gameStateMachine.StartSequence(initStateType );
    }
}
