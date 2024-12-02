using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    int CurrentLevelId;

    private void Awake()
    {
        CurrentLevelId = SceneManager.GetActiveScene().buildIndex;
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene(CurrentLevelId);
        
    }
}
