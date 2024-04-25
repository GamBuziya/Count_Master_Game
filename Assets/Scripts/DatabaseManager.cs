using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Firebase.Database;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = System.Object;

public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager Instance;
    
    private string _userId;
    private DatabaseReference _dbReference;

    private void Awake()
    {
        Instance = this;
        _userId = SystemInfo.deviceUniqueIdentifier;
        _dbReference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    public IEnumerator CreateOrReplaceScore(string levelName, int newScore)
    {
        var scoreData = _dbReference.Child("scores").Child(_userId).Child(levelName).Child("MaxScore").GetValueAsync();
    
        yield return new WaitUntil(predicate: () => scoreData.IsCompleted);
    
        if (scoreData.Result.Value != null) // Перевірка на наявність даних
        {
            DataSnapshot snapshot = scoreData.Result;
            int currentMaxScore = int.Parse(snapshot.Value.ToString());
        
            if (currentMaxScore < newScore)
            {
                string json = JsonUtility.ToJson(new LevelScore(levelName, newScore));
                _dbReference.Child("scores").Child(_userId).Child(levelName).SetRawJsonValueAsync(json);
            }
        }
        else
        {
            string json = JsonUtility.ToJson(new LevelScore(levelName, newScore));
            _dbReference.Child("scores").Child(_userId).Child(levelName).SetRawJsonValueAsync(json);
        }
    }



    public IEnumerator GetLevelName(Action<string> onCallback)
    {
        var levelnameData = _dbReference.Child("scores").Child(_userId).Child("LevelName").GetValueAsync();

        yield return new WaitUntil(predicate: () => levelnameData.IsCompleted);

        if (levelnameData != null)
        {
            DataSnapshot snapshot = levelnameData.Result;
            
            onCallback.Invoke(snapshot.Value.ToString());
        }
    }
    
    public IEnumerator GetLevelScore(string levelName, Action<int> onCallback)
    {
        var scoreData = _dbReference.Child("scores").Child(_userId).Child(levelName).Child("MaxScore").GetValueAsync();

        yield return new WaitUntil(predicate: () => scoreData.IsCompleted);

        if (scoreData != null && scoreData.Result.Value != null) // Додано перевірку на наявність даних
        {
            DataSnapshot snapshot = scoreData.Result;
            onCallback.Invoke(int.Parse(snapshot.Value.ToString()));
        }
        else
        {
            onCallback.Invoke(0);
        }
    }

}
