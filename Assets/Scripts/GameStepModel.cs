using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStepModel
{
    public string Quest_ID { get; private set; }
    public string Step_ID { get; private set; }
    public string Char_ID { get; private set; }
    public string Phrase { get; private set; }
    public string Option_A { get; private set; }
    public string Option_A_stepID { get; private set; }
    public string Option_B { get; private set; }
    public string Option_B_stepID { get; private set; }
    public string Scene_ID { get; private set; }
    public string Char_Animation_ID { get; private set; }

    public GameStepModel(string questID, string stepID)
    {
        Quest_ID = questID;
        Step_ID = stepID;
    }
}
