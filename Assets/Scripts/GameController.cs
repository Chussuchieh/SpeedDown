using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject UIPanel;
    public GameObject LoadPanel;
    public Slider loadSlider;
    public Text progressText;
    public Text timeCounter;
    public Text gamePassedText;
    private float surviveTime;
    private bool levelOver;
    bool lastLevel;
    private void Awake() 
    {
        instance=this;
    }
    private void OnEnable() 
    {
        UIPanel.transform.GetChild(1).gameObject.SetActive(PlayerPrefs.GetInt("currentLevel")>0);
    }
    private void FixedUpdate() 
    {
        if(timeCounter!=null & !levelOver)
        {
            surviveTime+=Time.fixedDeltaTime;
            timeCounter.text=surviveTime.ToString("00");
            if(surviveTime>60) GameOver(true);
        }
        
    }
    public void GameOver(bool passed)
    {
        UIPanel.SetActive(true);
        levelOver=true;
        if(SceneManager.GetActiveScene().buildIndex == 4) lastLevel=true;
        UIPanel.transform.GetChild(1).gameObject.SetActive(passed & !lastLevel);
        if(passed)
        {
            Time.timeScale=0;
            if(lastLevel) gamePassedText.gameObject.SetActive(true);
            else PlayerPrefs.SetInt("currentLevel",SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void NewGame()
    {
        StartCoroutine(LoadLevel(1));
        PlayerPrefs.SetInt("currentLevel",0);
    }
    public void RestartGame()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }
    public void NextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex+1));
    }
    public void LoadGame()
    {
        StartCoroutine(LoadLevel(PlayerPrefs.GetInt("currentLevel")+1));
    }
    public void BackMenu()
    {
        StartCoroutine(LoadLevel(0));
    }
    IEnumerator LoadLevel(int sceneIndex)
    {
        Time.timeScale=1;
        LoadPanel.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation=false;
        while(!operation.isDone)
        {
            loadSlider.value=operation.progress;
            progressText.text=operation.progress*100+"%";
            if(operation.progress>=.9f)
            {
                loadSlider.value=1;
                progressText.text=operation.progress*100+"%";
                operation.allowSceneActivation=true;
            }
            yield return null;
        }
    }
}
