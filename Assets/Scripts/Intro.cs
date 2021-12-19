using UnityEngine;

public class Intro : MonoBehaviour
{
    public GameObject CanvasIntro2, CanvasMenu;

    public void Next()
    {
        CanvasIntro2.gameObject.SetActive(true);
    }

    public void Play()
    {
        CanvasMenu.gameObject.SetActive(true);
    }
}
