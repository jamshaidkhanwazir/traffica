﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Analytics;
using Firebase.Database;
using Firebase.Unity.Editor;

[Serializable]
public class User
{
    public string username;
    public int levelNumber;
    public int coins;
    public string email;
    public string password;
    public string vehicle2;
    public string vehicle3;
    public string vehicle4;
}

public class FirebaseManager : MonoBehaviour
{
    private FirebaseAuth auth;
    private DatabaseReference database;

    private const string usersTableName = "users";

    public static FirebaseManager _instance;
    public static FirebaseManager Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);

        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            if (task.Result == DependencyStatus.Available)
            {
                InitializeFirebase();
            }
            else
            {
                Debug.Log("Failed to resolve firebase dependencies. Error: " + task.Result);
            }
        });
    }

    private void InitializeFirebase()
    {
        FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://drive-and-learn.firebaseio.com/");

        auth = FirebaseAuth.DefaultInstance;
        database = FirebaseDatabase.DefaultInstance.RootReference;
        Debug.Log("Initialized Firebase Successfully");
    }

    public void LoginUser(string email, string password, Action<LoginResult> onCompleted)
    {
        StartCoroutine(LoginUserCouroutine(email, password, onCompleted));
    }

    public void RegisterUser(User user, Action<RegisterResult> onCompleted)
    {
        StartCoroutine(RegisterUserCouroutine(user, onCompleted));
    }

    public void WriteUser(User user, Action<RegisterResult> onCompleted)
    {
        StartCoroutine(WriteUserCouroutine(user, onCompleted));
    }

    public void GetUser(string userId, Action<User, ReadUserResult> onCompleted)
    {
        StartCoroutine(ReadUserCoroutine(userId, onCompleted));
    }

    public void GetUsers(Action<List<User>, GetUsersResult> onCompleted)
    {
        StartCoroutine(GetUsersCoroutine(onCompleted));
    }

    public void UpdateLevelNumber(int levelNumber, Action<UpdateData> onCompleted)
    {
        StartCoroutine(UpdateLevelCouroutine(levelNumber, onCompleted));
    }

    public void UpdateCoins(int coins, Action<UpdateData> onCompleted)
    {
        StartCoroutine(UpdateCoinsCouroutine(coins, onCompleted));
    }

    public void UpdateVehicleState(string vehicleName, Action<UpdateData, string> onCompleted)
    {
        StartCoroutine(UpdateVehicleStateCouroutine(vehicleName, onCompleted));
    }






    private IEnumerator LoginUserCouroutine(string _email, string _password, Action<LoginResult> onCompleted)
    {
        var task = auth.SignInWithEmailAndPasswordAsync(_email, _password);
        yield return new WaitUntil(() => task.IsCompleted);

        if (task.IsFaulted)
        {
            Debug.Log("Sign In with Email And Password encountered an error: " + task.Exception);
            onCompleted.Invoke(LoginResult.Error);
        }
        else if (task.IsCanceled)
        {
            Debug.Log("Sign In with Email And Password was canceled");
            onCompleted.Invoke(LoginResult.Error);
        }
        else
        {
            Debug.Log("Successfully logged-in " + _email);
            onCompleted?.Invoke(LoginResult.Successfull);
        }
    }

    private IEnumerator RegisterUserCouroutine(User user, Action<RegisterResult> onCompleted)
    {
        var task = auth.CreateUserWithEmailAndPasswordAsync(user.email, user.password);
        yield return new WaitUntil(() => task.IsCompleted);

        if (task.IsFaulted)
        {
            Debug.Log("Failed to register user, Cause: " + task.Exception);
            onCompleted.Invoke(RegisterResult.Error);
        }
        else if (task.IsCanceled)
        {
            Debug.Log("Task cancelled, Cause: " + task.Exception);
            onCompleted.Invoke(RegisterResult.Error);
        }
        else if (task.IsCompleted)
        {
            Debug.Log("Successfully registered user " + user.email);
            WriteUser(user, onCompleted);
        }
    }

    private IEnumerator WriteUserCouroutine(User user, Action<RegisterResult> onCompleted)
    {
        string json = JsonUtility.ToJson(user);
        var task = database.Child(usersTableName).Child(auth.CurrentUser.UserId).SetRawJsonValueAsync(json);
        yield return new WaitUntil(() => task.IsCompleted);

        if (task.IsFaulted)
        {
            Debug.Log("Error! " + user.username + " not added to firebase");
            onCompleted.Invoke(RegisterResult.Error);
        }
        else
        {
            Debug.Log(user.username + " Successfully! added to firebase");
            onCompleted.Invoke(RegisterResult.Successfull);
        }
    }

    private IEnumerator ReadUserCoroutine(string userId, Action<User, ReadUserResult> onCompleted)
    {
        var task = database.Child(usersTableName).Child(userId).GetValueAsync();
        yield return new WaitUntil(() => task.IsCompleted);

        Dictionary<string, object> firebaseuser = (Dictionary<string, object>)task.Result.Value;
        User user = new User();
        bool flag = false;
        if (firebaseuser.Count == 1)                                                                        //Bug of firebase (sometime it doesn't returns the whole table and just returns a single attribute of table)
        {
            StartCoroutine(ReadUserCoroutine(userId, onCompleted));
        }
        else
        {
            flag = true;
            user = new User()
            {
                username = firebaseuser["username"].ToString(),
                levelNumber = Convert.ToInt32(firebaseuser["levelNumber"].ToString()),
                coins = Convert.ToInt32(firebaseuser["coins"].ToString()),
                email = firebaseuser["email"].ToString(),
                password = firebaseuser["password"].ToString(),
                vehicle2 = firebaseuser["vehicle2"].ToString(),
                vehicle3 = firebaseuser["vehicle3"].ToString(),
                vehicle4 = firebaseuser["vehicle4"].ToString()
            };
        }

        if (task.IsCompleted && flag)
        {
            onCompleted?.Invoke(user, ReadUserResult.Successfull);
        }
        else
        {
            Debug.Log("Error: Could not fetch user data");
            onCompleted?.Invoke(user, ReadUserResult.Error);
        }
    }

    private IEnumerator GetUsersCoroutine(Action<List<User>, GetUsersResult> onCompleted)
    {
        var getUsersTask = database.Child(usersTableName).GetValueAsync();
        yield return new WaitUntil(() => getUsersTask.IsCompleted);

        if (getUsersTask.IsCompleted)
        {
            Dictionary<string, object> allUsersDict = (Dictionary<string, object>)getUsersTask.Result.Value;
            List<User> usersList = new List<User>();

            if (allUsersDict != null)
            {
                foreach (var singleUser in allUsersDict)
                {
                    Dictionary<string, object> userDict = (Dictionary<string, object>)singleUser.Value;
                    User user = new User()
                    {
                        username = userDict["username"].ToString(),
                        levelNumber = Convert.ToInt32(userDict["levelNumber"].ToString()),
                    };

                    usersList.Add(user);
                }
                onCompleted?.Invoke(usersList, GetUsersResult.Successfull);
            }
            else if (allUsersDict == null)
            {
                onCompleted?.Invoke(usersList, GetUsersResult.Error);
            }
        }
        else
        {
            Debug.Log("Error");
            var usersList = new List<User>();
            onCompleted?.Invoke(usersList, GetUsersResult.Error);
        }
    }

    private IEnumerator UpdateLevelCouroutine(int levelNumber, Action<UpdateData> onCompleted)
    {
        var task = database.Child(usersTableName).Child(auth.CurrentUser.UserId).Child("levelNumber").SetValueAsync(levelNumber);
        yield return new WaitUntil(() => task.IsCompleted);

        if (task.IsFaulted)
        {
            onCompleted?.Invoke(UpdateData.Error);
        }
        else
        {
            onCompleted?.Invoke(UpdateData.Successfull);
        }
    }

    private IEnumerator UpdateCoinsCouroutine(int coins, Action<UpdateData> onCompleted)
    {
        var task = database.Child(usersTableName).Child(auth.CurrentUser.UserId).Child("coins").SetValueAsync(coins);
        yield return new WaitUntil(() => task.IsCompleted);

        if (task.IsFaulted)
        {
            onCompleted?.Invoke(UpdateData.Error);
        }
        else
        {
            onCompleted?.Invoke(UpdateData.Successfull);
        }
    }

    private IEnumerator UpdateVehicleStateCouroutine(string vehicleName, Action<UpdateData, string> onCompleted)
    {
        var task = database.Child(usersTableName).Child(auth.CurrentUser.UserId).Child(vehicleName).SetValueAsync(State.Unlocked.ToString());
        yield return new WaitUntil(() => task.IsCompleted);

        if (task.IsFaulted)
        {
            onCompleted?.Invoke(UpdateData.Error, vehicleName);
        }
        else
        {
            onCompleted?.Invoke(UpdateData.Successfull, vehicleName);
        }
    }
}

public enum LoginResult
{
    Error,
    Successfull
}

public enum RegisterResult
{
    Error,
    Successfull
}

public enum ReadUserResult
{
    Error,
    Successfull
}

public enum GetUsersResult
{
    Error,
    Successfull
}

public enum UpdateData
{
    Error,
    Successfull
}