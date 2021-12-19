using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Collision : MonoBehaviour
{
    public List<float> possiblePosition;
    private Vector2 newPos11, newPos21, newPos12, newPos22, newPos13, newPos23;
    private void OnTriggerEnter2D(Collider2D other)
    {
        int rand = Random.Range(0, possiblePosition.Count);
        int rand2 = Random.Range(0, possiblePosition.Count);
        
        newPos11.x = possiblePosition.ElementAt(rand);
        newPos11.y = 6f;
        newPos21.x = possiblePosition.ElementAt(rand2);
        newPos21.y = 6f;
        
        newPos12.x = possiblePosition.ElementAt(rand);
        newPos12.y = 8f;
        newPos22.x = possiblePosition.ElementAt(rand2);
        newPos22.y = 8f;
        
        newPos13.x = possiblePosition.ElementAt(rand);
        newPos13.y = 10f;
        newPos23.x = possiblePosition.ElementAt(rand2);
        newPos23.y = 10f;
        
        if (other.gameObject.name == "Coin")
        {
            PlayerMovement.collectedCoins += 1;
            PlayerMovement.coinCounter += 1;
            switch (Home.level)
            {
                case 1:
                { 
                    other.gameObject.transform.position = newPos11;
                    break;
                }
                case 2:
                { 
                    other.gameObject.transform.position = newPos12;
                    break;
                }
                case 3:
                { 
                    other.gameObject.transform.position = newPos13;
                    break;
                }
            }
            // other.gameObject.transform.position = newPos;
        }
        if (other.gameObject.name == "Coin2")
        {
            PlayerMovement.collectedCoins += 1;
            PlayerMovement.coinCounter += 1;
            switch (Home.level)
            {
                case 1:
                { 
                    other.gameObject.transform.position = newPos21;
                    break;
                }
                case 2:
                { 
                    other.gameObject.transform.position = newPos22;
                    break;
                }
                case 3:
                { 
                    other.gameObject.transform.position = newPos23;
                    break;
                }
            }
            // other.gameObject.transform.position = newPos2;
        }
    }
}
