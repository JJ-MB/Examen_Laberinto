using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Cronometro : MonoBehaviour
{
    public string nombreEscenaACargar; // El nombre de la escena a la que deseas cambiar
    public TMP_Text textoCronometro;
    private float tiempoRestante = 120f; // 2 minutos en segundos

    void Update()
    {
        // Restamos tiempo del contador
        tiempoRestante -= Time.deltaTime;

        // Asegurémonos de que el tiempo restante no sea negativo
        tiempoRestante = Mathf.Max(tiempoRestante, 0f);

        // Calcula el tiempo en minutos y segundos
        int minutos = Mathf.FloorToInt(tiempoRestante / 60);
        int segundos = Mathf.FloorToInt(tiempoRestante % 60);
        float milisegundos = (tiempoRestante * 100) % 100;

        // Actualiza el texto del cronómetro
        textoCronometro.text = string.Format("{0:00}:{1:00}:{2:00}", minutos, segundos, milisegundos);
       
        if (tiempoRestante <= 0f)
        {
            SceneManager.LoadScene(nombreEscenaACargar);
            PlayerPrefs.SetInt("Game", 0);
            PlayerPrefs.Save();
        }
    }
}