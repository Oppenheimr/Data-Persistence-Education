using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class ScoreboardUI : MonoBehaviour
    {
        [SerializeField] private UserTemplate userTemplate;
        private List<UserTemplate> _userTemplates = new List<UserTemplate>(); 
        private Transform _userRoot;
        
        private void Awake()
        {
            _userRoot = userTemplate.transform.parent;
            var users = GameManager.Instance.LoadUsers();
            if(users.Length == 0)
                Destroy(userTemplate);
            else
            {
                _userTemplates.Add(userTemplate);
                while (_userTemplates.Count != users.Length)
                    _userTemplates.Add(Instantiate(userTemplate,_userRoot));

                for (int i = 0; i < users.Length; i++)
                    _userTemplates[i].SetupUserTemplate(users[i]);
                
            }
        }
        
        public void OnBackButton() => SceneManager.LoadScene("Menu");
    }
}