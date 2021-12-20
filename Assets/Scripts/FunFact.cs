using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class FunFact : MonoBehaviour
{
    public GameObject Txt;
    private int coinSaver1, coinSaver2;
    public String[] factEarth, factSoil, factSea, factBuilding, factSky, factSpace;
    public int rand;

    public void Awake()
    {
        rand = Random.Range(0, factEarth.Length);
        if (PlayerMovement.earth == true) 
            Txt.GetComponent<TextMeshProUGUI>().text = factEarth[rand];
        if (PlayerMovement.soil == true)
            Txt.GetComponent<TextMeshProUGUI>().text = factSoil[rand];
        if (PlayerMovement.sea == true)
            Txt.GetComponent<TextMeshProUGUI>().text = factSea[rand];
        if (PlayerMovement.building == true)
            Txt.GetComponent<TextMeshProUGUI>().text = factBuilding[rand];
        if (PlayerMovement.sky == true)
            Txt.GetComponent<TextMeshProUGUI>().text = factSky[rand];
        if (PlayerMovement.space == true)
            Txt.GetComponent<TextMeshProUGUI>().text = factSpace[rand];
    }
}
    
    
    
    
