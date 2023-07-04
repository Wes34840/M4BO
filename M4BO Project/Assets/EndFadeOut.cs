using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndFadeOut : MonoBehaviour
{
    
    public void FinishGame()
    {
        GlobalData.Money += 1000000;
        SceneManager.LoadScene("The End");
    }

}
