using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class PlayerMovement : MonoBehaviour
{
    public float increment, speed, timeLeft = 3.0f;
    public Vector2 targetPos;
    public static int collectedCoins = 0, coinCounter = 0, totalCorrect = 0, totalNotCorrect = 0, totalQuestions;
    private int coinSaver1, coinSaver2;
    private Vector2 newPos, newPos2;
    public GameObject Canvas1, Canvas2, Canvas3, CanvasMenu, CanvasHome, CanvasMessage, CanvasFinish, CanvasStat, CanvasNoLives;
    public GameObject Coin1, Coin2, TxtBar1, TxtBar2, Baloon1, Baloon2, Baloon3, Baloon4;
    public Home home;
    private double val;
    private bool boolBackGround = false, updateCoins = false, boolBaloon = false;
    public static bool earth = true, soil, sea, building, sky, space;
    public static AudioSource audioSource;
    public AudioClip bgMusic;

    public void Awake()
    {
        targetPos = transform.position;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgMusic;
    }

    public void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        val = home.prob; // val defines the difficulty of the game (Easy, Medium, Hard)
        if (coinCounter >= 5)
        {
            updateCoins = true;
            if (Random.value > val) // decides if either sound or picture is presented, based on difficulty
            {
                updateCoins = false;
                Canvas3.gameObject.SetActive(true);
            }
            else
            {
                updateCoins = false;
                Canvas2.gameObject.SetActive(true);
            }

            coinCounter -= 5;
        }

        if (totalNotCorrect == 5) // removing 1 baloon every 5 wrong answer
        {
            Baloon3.gameObject.SetActive(false);
        }
        if (totalNotCorrect == 10)
        {
            Baloon2.gameObject.SetActive(false);
        }
        if (totalNotCorrect == 15)
        {
            Baloon1.gameObject.SetActive(false);
        }
        if (totalNotCorrect == 20)
        {
            Baloon4.gameObject.SetActive(false);
            CanvasNoLives.gameObject.SetActive(true);
            Canvas1.gameObject.SetActive(false);
            Canvas2.gameObject.SetActive(false);
            Coin1.gameObject.SetActive(false);
            Coin2.gameObject.SetActive(false);
        }

        if (totalCorrect == 5) // code to change te background after x correct answers
        {
            coinSaver1 = coinCounter;
            coinSaver2 = collectedCoins; 
            timeLeft -= Time.deltaTime;
            CanvasMessage.gameObject.SetActive(true);
            if (timeLeft <= 0.0f)
            {
                boolBackGround = true;
            }

            if (boolBackGround)
            {
                CanvasMessage.gameObject.SetActive(false);
                timeLeft = 3.0f;
                home.BG1.gameObject.SetActive(false);
                home.BG2.gameObject.SetActive(true);
                coinCounter = coinSaver1;
                collectedCoins = coinSaver2;
            }

            earth = false; // to link fun facts to background
            soil = true;
        }
        else if (totalCorrect == 10)
        {
            boolBackGround = false;    
            coinSaver1 = coinCounter;
            coinSaver2 = collectedCoins;
            timeLeft -= Time.deltaTime;
            CanvasMessage.gameObject.SetActive(true);
            if (timeLeft <= 0.0f)
            { 
                boolBackGround = true;
            }

            if (boolBackGround)
            {
                CanvasMessage.gameObject.SetActive(false); 
                timeLeft = 3.0f;
                home.BG2.gameObject.SetActive(false);
                home.BG3.gameObject.SetActive(true);
                coinCounter = coinSaver1;
                collectedCoins = coinSaver2;
            }

            soil = false;
            sea = true;
        }
        else if (totalCorrect == 15)
        {
            boolBackGround = false;    
            coinSaver1 = coinCounter;
            coinSaver2 = collectedCoins;
            timeLeft -= Time.deltaTime;
            CanvasMessage.gameObject.SetActive(true);
            if (timeLeft <= 0.0f)
            {
                boolBackGround = true;
            }

            if (boolBackGround)
            {
                CanvasMessage.gameObject.SetActive(false);
                timeLeft = 3.0f; 
                home.BG3.gameObject.SetActive(false); 
                home.BG4.gameObject.SetActive(true);
                coinCounter = coinSaver1; 
                collectedCoins = coinSaver2;
            }

            sea = false;
            building = true;
        }
        else if (totalCorrect == 20)
        {
            boolBackGround = false;    
            timeLeft -= Time.deltaTime;
            CanvasMessage.gameObject.SetActive(true);
            coinSaver1 = coinCounter;
            coinSaver2 = collectedCoins;
            if (timeLeft <= 0.0f)
            {
                boolBackGround = true;
            }

            if (boolBackGround)
            { 
                CanvasMessage.gameObject.SetActive(false);
                timeLeft = 3.0f;
                home.BG4.gameObject.SetActive(false);
                home.BG5.gameObject.SetActive(true); 
                coinCounter = coinSaver1;
                collectedCoins = coinSaver2;
            }

            building = false;
            sky = true;
        }
        else if (totalCorrect == 25)
        {
            boolBackGround = false;
            timeLeft -= Time.deltaTime;
            CanvasMessage.gameObject.SetActive(true);
            coinSaver1 = coinCounter;
            coinSaver2 = collectedCoins;
            if (timeLeft <= 0.0f)
            {
                boolBackGround = true;
            }

            if (boolBackGround)
            {
                CanvasMessage.gameObject.SetActive(false); 
                timeLeft = 3.0f; 
                home.BG5.gameObject.SetActive(false);
                home.BG6.gameObject.SetActive(true);
                coinCounter = coinSaver1;
                collectedCoins = coinSaver2;
            }

            sky = false;
            space = true;
        }
        else if (totalCorrect == 30)
        {
            boolBackGround = false;   
            CanvasFinish.gameObject.SetActive(true);
            Canvas1.gameObject.SetActive(false);
            Canvas2.gameObject.SetActive(false);
            home.BG6.gameObject.SetActive(false);
            Coin1.gameObject.SetActive(false);
            Coin2.gameObject.SetActive(false);
        }

        TxtBar1.GetComponent<TMP_Text>().text = "Gemme raccolte: " + collectedCoins.ToString();
        TxtBar2.GetComponent<TMP_Text>().text = "Risposte esatte: " + totalCorrect.ToString();
    }

    public void MoveLeft()
        {
            if (transform.position.x > -2)
            {
                targetPos = new Vector2(transform.position.x - increment, transform.position.y);
            }
        }
    public void MoveRight()
        {
            if (transform.position.x < 2)
            {
                targetPos = new Vector2(transform.position.x + increment, transform.position.y);
            }
        }

    public void Pause()
        {
            Time.timeScale = 0;
            audioSource.Pause();
            Canvas1.gameObject.SetActive(false);
            Canvas2.gameObject.SetActive(false);
            Coin1.gameObject.SetActive(false);
            Coin2.gameObject.SetActive(false);
            CanvasMenu.gameObject.SetActive(true);
        }

    public void Resume()
        {
            Time.timeScale = 1;
            audioSource.Play();
            Canvas1.gameObject.SetActive(true);
            Coin1.gameObject.SetActive(true);
            Coin2.gameObject.SetActive(true);
            Canvas2.gameObject.SetActive(false);
            CanvasMenu.gameObject.SetActive(false);
        }

    public void Home()
        {
            Time.timeScale = 0;
            audioSource.Pause();
            Canvas1.gameObject.SetActive(false);
            Canvas2.gameObject.SetActive(false);
            CanvasMenu.gameObject.SetActive(false);
            CanvasFinish.gameObject.SetActive(false);
            CanvasNoLives.gameObject.SetActive(false);
            CanvasHome.gameObject.SetActive(true);
        }

    public void Statistics()
        {
            Time.timeScale = 0;
            audioSource.Pause();
            CanvasStat.gameObject.SetActive(true);
            Canvas1.gameObject.SetActive(false);
            Canvas2.gameObject.SetActive(false);
            CanvasMenu.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }

