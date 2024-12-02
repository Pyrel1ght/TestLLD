using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour, IInteractable
{
    [SerializeField]GameObject finishScreen;


    public void Interact()
    {
        finishScreen.SetActive(true);
        Time.timeScale = 0f;
    }
}
