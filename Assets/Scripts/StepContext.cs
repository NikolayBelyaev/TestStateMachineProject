using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepContext : MonoBehaviour
{
    public List<string> Steps;
    public QuestView View;

    public StepContext(List<string> steps)
    {
        Steps = steps;
    }
}
