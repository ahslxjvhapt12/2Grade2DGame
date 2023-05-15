using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log(1);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}