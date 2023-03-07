using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class MainUI : MonoBehaviour
    {
        [SerializeField] private Text bestScore;
        private void Awake() => SetupBestScore();
        private string GetBestScoreText(UserData user) => $"Best Score : {user.UserName} : {user.Scores[0].ScorePoint}";

        public void SetupBestScore() => bestScore.text = GetBestScoreText(GameManager.Instance.currentUser);
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                SceneManager.LoadScene("Menu");
        }

        private static MainUI _instance;
        public static MainUI Instance
        {
            get
            {
                if (!_instance) _instance = FindObjectOfType<MainUI>();
                return _instance;
            }
        }
    }
}