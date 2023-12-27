using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashSequence : MonoBehaviour
{
    public static int SplashScreen;
    // Start is called before the first frame update
    void Start()
    {
        if (SplashScreen == 0){
            StartCoroutine (ToOnBoarding ());
        }
        
    }

    IEnumerator ToOnBoarding ()
        {
            yield return new WaitForSeconds (3);
            SplashScreen = 1;
            SceneManager.LoadScene("OnBoarding");
        }
    
}
