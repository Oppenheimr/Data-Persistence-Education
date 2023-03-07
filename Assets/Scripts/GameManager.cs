using System;
using System.IO;
using System.Linq;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public UserData currentUser;

    private void Awake()
    {
        if (!Instance)
            Instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);  
    }

    public void SaveScore(int score)
    {
        for (int i = 0; i < currentUser.Scores.Length; i++)
        {
            if (currentUser.Scores[i].ScorePoint < score)
            {
                Score[] newScores = new Score[currentUser.Scores.Length];
                newScores = currentUser.Scores;
                for (int j = i+1 ; j < currentUser.Scores.Length; j++) 
                    newScores[j] = currentUser.Scores[j - 1];
                
                newScores[i].ScorePoint = score;
                newScores[i].Time = DateTimeOffset.Now;
                currentUser.Scores = newScores;
                break;
            }
        }
        UpdateUser(currentUser);
    }

    public void UpdateUser(UserData userData)
    {
        var users = LoadUsers();
        
        for (int i = 0; i < users.Length; i++)
            if (users[i].UserName == userData.UserName)
                users[i] = userData;
        
        SaveUsers(users);
    }
    
    public void SaveUsers(UserData[] users)
    {
        string json = JsonUtility.ToJson(new Users(){UserArray = users});
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void AddUser(string userName)
    {
        bool foundUser = false;
        var users = LoadUsers();

        foreach (var user in users)
        {
            if (user.UserName != userName) continue;
            foundUser = true;
            currentUser = user;
        }

        if (foundUser) return;
        
        UserData[] data = new UserData[users.Length + 1];
        for (int i = 0; i < users.Length; i++)
            data[i] = users[i];

        var newUser = new UserData()
        {
            UserName = userName,
            Scores = new Score[]
            {
                new Score(){ScorePoint = 0,Time = new DateTimeOffset()},
                new Score(){ScorePoint = 0,Time = new DateTimeOffset()},
                new Score(){ScorePoint = 0,Time = new DateTimeOffset()}
                
            }
        };
        data[users.Length] = newUser;
        
        SaveUsers(data);
        currentUser = newUser;
    }

    public bool LoadUser(string userName, out UserData user)
    {
        user = new UserData();
        string path = Application.persistentDataPath + "/savefile.json";
        if (!File.Exists(path)) return false;
        
        string json = File.ReadAllText(path);
        UserData[] usersData = JsonUtility.FromJson<Users>(json).UserArray;
        foreach (var data in usersData)
        {
            if (NameIsEquals(userName,data.UserName))
            {
                user = data;
                return true;
            }
        }
        return false;
    }

    public UserData[] LoadUsers()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            UserData[] usersData = JsonUtility.FromJson<Users>(json).UserArray;
            return usersData;
        }

        return Array.Empty<UserData>();
    }

    private bool NameIsEquals(string inputName, string refName)
    {
        var inName = inputName.ToCharArray().ToList();
        var rName = refName.ToCharArray().ToList();
        rName.RemoveAt(rName.Count - 1);
        
        if (inName.Count != rName.Count)
            return false;
        for (int i = 0; i < inName.Count; i++)
            if (inName[i] != rName[i])
                return false;
        return true;
    }
    
    public static GameManager Instance;
}

[System.Serializable]
public class Users
{
    public UserData[] UserArray; //Best 3 Scores
}

[System.Serializable]
public struct UserData
{
    public string UserName;
    public Score[] Scores; //Best 3 Scores
}

[System.Serializable]
public struct Score
{
    public int ScorePoint;
    public DateTimeOffset Time;
}