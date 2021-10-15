using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TextMeshProUGUI bestScoreText;

    private void Start()
    {
        BestScoreText();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
        if (UnityEditor.EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }

    public void CurrentUser()
    {
        Debug.Log(inputField.text);
        DataManager.instance.currentName = inputField.text;
    }

    public void BestScoreText()
    {
        if (DataManager.instance.name == null)
        {
            bestScoreText.text = "Best Score: : 0";
        }
        else
        {
            bestScoreText.text = "Best Score: " + DataManager.instance.userName + " : " + DataManager.instance.bestScore;
        }
    }
}
