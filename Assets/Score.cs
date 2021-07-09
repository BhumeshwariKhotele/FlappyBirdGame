using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text score;
    int coin;

    public void ScoreIncrement()
    {
        coin++;
        score.text = "Coin :" + coin;
    }
}
