using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class MenuUI : MonoBehaviour, ISceneManagement<string>
    {
        [SerializeField] private TextMeshProUGUI bestScore;
        [SerializeField] private TextMeshProUGUI userNameTMP;

        private void Awake()
        {
            OnUserNameChange(GameManager.Instance.currentUser.UserName);
            userNameTMP.text = GameManager.Instance.currentUser.UserName;
        }
        

        public void Play()
        {
            GameManager.Instance.AddUser(userNameTMP.text);
            SceneTranslation("Main");
        }

        public void OnUserNameChange(string userName)
        {
            if (GameManager.Instance.LoadUser(userName, out UserData user))
                bestScore.text = "Best Score : " + user.Scores[0].ScorePoint;
            else
                bestScore.text = "";
        }
        
        public void SetUserName(string userName)
        {
            OnUserNameChange(userName);
            userNameTMP.text = userName;
        }
        
        public void SceneTranslation(string sceneName) => SceneManager.LoadScene(sceneName);
    
        public void Quit()
        {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
        }

        private static MenuUI _instance;
        public static MenuUI Instance
        {
            get
            {
                if (!_instance) _instance = FindObjectOfType<MenuUI>();
                return _instance;
            }
        }
    }
}
