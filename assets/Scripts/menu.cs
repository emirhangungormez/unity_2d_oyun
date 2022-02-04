using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    public GameObject dataBoard;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public void Playbutton()
    {
        SceneManager.LoadScene(1);
    }

    public void DataBoardButton()
    {
        dataManager.Instance.LoadData(); // en kaydedilmiş veriler "LoadData" metoduna çağrılır.

        dataBoard.transform.GetChild(2).GetComponent<Text>().text = "Kullanılan çark:" + dataManager.Instance.totalShotBullet.ToString();
        dataBoard.transform.GetChild(3).GetComponent<Text>().text = "Öldürülen düşman:" +dataManager.Instance.totalEnemyKilled.ToString();
        // "2" ve "3" dataBoard objesinin içerisindeki "text'lerin" indeks sırasını belirtmektedir.
        // sayı sıralaması değiştirilirse kod çalışmayacaktır.
        dataBoard.SetActive(true); // aktifliğini aç.
    }

    public void xbutton()
    {
        dataBoard.SetActive(false); // aktifliğini kapat.
    }
} 
