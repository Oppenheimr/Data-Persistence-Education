using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserTemplate : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI userName;
    [SerializeField] private TextMeshProUGUI bestScore;
    [SerializeField] private TextMeshProUGUI secondaryScore;
    [SerializeField] private TextMeshProUGUI tertiaryScore;

    public void SetupUserTemplate(UserData user)
    {
        userName.text = user.UserName;
        bestScore.text = GetScoreText("Best", user.Scores[0].ScorePoint);
        secondaryScore.text = GetScoreText("Secondary", user.Scores[1].ScorePoint);
        tertiaryScore.text = GetScoreText("Tertiary", user.Scores[2].ScorePoint);
    }

    private string GetScoreText(string order, int score) => $"{order} Score : {score}";
}
