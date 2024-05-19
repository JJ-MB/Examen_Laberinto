using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameText : MonoBehaviour
{
    public TMP_Text TextGame;
    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Game") == 0)
        {
            TextGame.text = string.Format("Game Over");
        }
        if(PlayerPrefs.GetInt("Game") == 1) 
        {
            TextGame.text = string.Format("Game Completado");
        }
    }
}
