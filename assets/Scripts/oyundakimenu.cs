using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class oyundakimenu : MonoBehaviour
{
    public GameObject inGameScreen, pauseScreen;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

       public void PauseButton()
    {
        Time.timeScale = 0; // oyunu durdurur.
        inGameScreen.SetActive(false); // oyun sahnesini kapatır.
        pauseScreen.SetActive(true); // pause sahnesini açar.

    }
// pause sahnesini açar.
       public void PlayButton()
    {
        Time.timeScale = 1; // oyunu devam ettirir.
        pauseScreen.SetActive(false); // pause sahnesini kapatır.
        inGameScreen.SetActive(true); // oyun sahnesini kapatır.
    }

    public void RePlayButton()
    {
        Time.timeScale = 1; // oyunu devam ettirir. (emin olmak için)
        SceneManager.LoadScene(1); // (1'i) oyun sahnesini yeniden yükler.
    }

    public void HomeButton()
    {
        Time.timeScale = 1;
        dataManager.Instance.SaveData(); // verileri kaydeder.
        SceneManager.LoadScene(0); // (0'ı) menü sahnesini yükler.
    }
}


