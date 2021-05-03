using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreenSet : MonoBehaviour
{
    public GameObject FadeScreen;
    public GameObject FadeIntoScreen;
    public GameObject Main;
    public GameObject Story;
    public GameObject MenuMusic;
    public GameObject MainMusic;


    public void FadingOut(){
        FadeScreen.GetComponent<Animation>().Play("FadeOutIntro");
        StartCoroutine(ExecuteAfterTime(4));
        MenuMusic.GetComponent<Animation>().Play("MenuFadeOut");
    }

   IEnumerator ExecuteAfterTime(float time)
 {
     yield return new WaitForSeconds(time);
        Main.SetActive(false);
        Story.SetActive(true);
        MenuMusic.SetActive(false);
        MainMusic.SetActive(true);
        FadeIntoScreen.GetComponent<Animation>().Play("FadeInIntro");
    }
}
