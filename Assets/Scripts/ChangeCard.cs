using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ChangeCard : MonoBehaviour
{
    public Sprite[] sprite, sprite2, sprite3;
    public String[] names, names2, names3;
    public int[] valori, valori2, valori3;
    private int soft = 1, hard = 0;
    public int val, rand, coinSaver1, coinSaver2;
    public static int totalQuestions, funfactCounter = 0;
    public GameObject Photo, Txt, Timer;
    public GameObject Coin1, Coin2;
    public GameObject CanvasCorrect, CanvasWrong, CanvasFunFact, Canvas;
    public float timeLeft = 5.0f, timeFunFact;
    public Home home;
    private bool randomUpdate = true;
    public Button click;
    public void Update()
    {
        Coin1.gameObject.SetActive(false);
        Coin2.gameObject.SetActive(false);
        switch (home.letter)
        {
            case 1:
            { 
                ChangeImg();
                break;
            }
            case 2:
            {
                ChangeImg2();
                break;
            }
            case 3:
            {
                ChangeImg3();
                break;
            }
        }
        
        timeLeft -= Time.deltaTime;
        Timer.GetComponent<Text>().text = (Mathf.Round(timeLeft * 10.0f) * 0.1f).ToString();
        
        if (timeLeft <= 0.0f)
        {
            PlayerMovement.totalNotCorrect += 1;
            CanvasWrong.gameObject.SetActive(true);
            gameObject.SetActive(false);
            timeLeft = 5.0f;
            randomUpdate = true;
        }
    }
    public void ChangeImg()
    {
        if (randomUpdate)
        {
            rand = Random.Range(0, sprite.Length);
            randomUpdate = false;
            Photo.GetComponent<Image>().overrideSprite = sprite[rand];
            Txt.GetComponent<Text>().text = names[rand];
            val = valori[rand];
        }
    }
    public void ChangeImg2()
    {
        if (randomUpdate)
        {
            rand = Random.Range(0, sprite2.Length);
            randomUpdate = false;
            Photo.GetComponent<Image>().overrideSprite = sprite2[rand];
            Txt.GetComponent<Text>().text = names2[rand];
            val = valori2[rand];
        }
    }
    public void ChangeImg3()
    {
        if (randomUpdate)
        {
            rand = Random.Range(0, sprite3.Length);
            randomUpdate = false;
            Photo.GetComponent<Image>().overrideSprite = sprite3[rand];
            Txt.GetComponent<Text>().text = names3[rand];
            val = valori3[rand];
        }
    }
    public void SoftSound()
    {
        if (val == soft)
        {
            PlayerMovement.totalCorrect += 1;
            CanvasCorrect.gameObject.SetActive(true);
        }
        else 
        {
            PlayerMovement.totalNotCorrect += 1;
            CanvasWrong.gameObject.SetActive(true);
        }
        gameObject.SetActive(false);
        timeLeft = 5.0f;
        randomUpdate = true;
        
        totalQuestions = PlayerMovement.totalCorrect + PlayerMovement.totalNotCorrect - funfactCounter;
        //Debug.Log(totalQuestions);
        if (totalQuestions == 10) //break with fun fact after every 10 questions
        {
            Button btn = click.GetComponent<Button>();
            btn.onClick.AddListener(Continue);
            coinSaver1 = PlayerMovement.coinCounter;
            coinSaver2 = PlayerMovement.collectedCoins;
            CanvasFunFact.gameObject.SetActive(true);
            Canvas.gameObject.SetActive(false);
            funfactCounter += 10;
        }
    }
    public void HardSound()
    {
        if (val == hard)
        {
            PlayerMovement.totalCorrect += 1;
            CanvasCorrect.gameObject.SetActive(true);
        }
        else
        {
            PlayerMovement.totalNotCorrect += 1;
            CanvasWrong.gameObject.SetActive(true);
        }
        gameObject.SetActive(false);
        timeLeft = 5.0f;
        randomUpdate = true;

        totalQuestions = PlayerMovement.totalCorrect + PlayerMovement.totalNotCorrect - funfactCounter;
        //Debug.Log(totalQuestions);
        if (totalQuestions == 10) //break with fun fact after every 10 questions
        {
            Button btn = click.GetComponent<Button>();
            btn.onClick.AddListener(Continue);
            coinSaver1 = PlayerMovement.coinCounter;
            coinSaver2 = PlayerMovement.collectedCoins;
            CanvasFunFact.gameObject.SetActive(true);
            Canvas.gameObject.SetActive(false);
            funfactCounter += 10;
        }
    }
    public void Continue()
    {
        CanvasFunFact.gameObject.SetActive(false);
        Canvas.gameObject.SetActive(true);
        PlayerMovement.coinCounter = coinSaver1;
        PlayerMovement.collectedCoins = coinSaver2;
    }
}
