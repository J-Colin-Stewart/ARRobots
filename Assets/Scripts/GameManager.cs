using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Canvas gameOverCanvas;
    public TMP_Text livesText;

    public int lives = 10;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void LoseLife()
    {
        lives--;

        // Update the life counter

        // Game over if lives are less than 0
        if (lives < 0)
        {
            // Display GAME OVER
        }
    }

    public void RestartGame()
    {
        lives = 10;
        livesText.text = "LIVES : " + lives.ToString();
    }
}
