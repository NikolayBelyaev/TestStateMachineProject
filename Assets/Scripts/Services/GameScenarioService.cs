using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GameScenarioService : MonoBehaviour
{
    public static List<GameStepModel> GameSteps { get; private set; }
    

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


    private async void Start()
    {
        var download = await DownloadScenarioSteps();
        GameSteps = download.ToList();
        StartGameSequence();
    }

    public void StartGameSequence()
    {
        if (GameSteps == null)
        {
            throw new NullReferenceException("Game steps were not downloaded from the CDN for the moment");
        }
        
        QuestStepActivatorService.CreateStateMachine();
    }
}
