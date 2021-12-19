using UnityEngine;
using UnityEngine.UI;

public class Statistics : MonoBehaviour
{
    public GameObject StatCorrect, StatNotCorrect, StatGems, CanvasHome, Coin1, Coin2;
    public void Update()
    {
        Coin1.gameObject.SetActive(false);
        Coin2.gameObject.SetActive(false);
        StatNotCorrect.GetComponent<Text>().text = (PlayerMovement.totalNotCorrect).ToString();
        StatCorrect.GetComponent<Text>().text = (PlayerMovement.totalCorrect).ToString();
        StatGems.GetComponent<Text>().text = (PlayerMovement.collectedCoins).ToString();
    }
    public void Home()
    {
        gameObject.SetActive(false);
        CanvasHome.gameObject.SetActive(true);
    }
}
