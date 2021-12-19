using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random=UnityEngine.Random;

public class Coins : MonoBehaviour
{
    private Vector2 newPos, newPos2, newPos3;
    public List<float> possiblePosition;
    private void Update()
    {
        transform.Translate(Vector2.down * Home.speed * Time.deltaTime);
        int rand = Random.Range(0, possiblePosition.Count);
        newPos.x = possiblePosition.ElementAt(rand);
        newPos.y = 6f;
        newPos2.x = possiblePosition.ElementAt(rand);
        newPos2.y = 8f;
        newPos3.x = possiblePosition.ElementAt(rand);
        newPos3.y = 10f;
        if (transform.position.y <= -3f)
        {
            switch (Home.level)
            {
                case 1:
                { 
                    transform.position = newPos;
                    break;
                }
                case 2:
                { 
                    transform.position = newPos2;
                    break;
                }
                case 3:
                { 
                    transform.position = newPos3;
                    break;
                }
            }
            // transform.position = newPos;
        }
    }
}

