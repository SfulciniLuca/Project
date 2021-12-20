using UnityEngine;

public class Intro : MonoBehaviour
{
    public GameObject CanvasIntro2, CanvasMenu;

    public void Next()
    {
        gameObject.SetActive(false);
        CanvasIntro2.gameObject.SetActive(true);
    }

    public void Play()
    {
        gameObject.SetActive(false);
        CanvasMenu.gameObject.SetActive(true);
    }
}
