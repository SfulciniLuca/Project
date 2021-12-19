using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class FunFact : MonoBehaviour
{
    public GameObject Txt;
    private int coinSaver1, coinSaver2;
    public String[] factEarth, factSoil, factSea, factBuilding, factSky, factSpace;
    public int rand;

    void Awake()
    {
        rand = Random.Range(0, factEarth.Length);
        if (PlayerMovement.earth) 
            Txt.GetComponent<Text>().text = factEarth[rand];
        else if (PlayerMovement.soil)
            Txt.GetComponent<Text>().text = factSoil[rand];
        else if (PlayerMovement.sea)
            Txt.GetComponent<Text>().text = factSea[rand];
        else if (PlayerMovement.building)
            Txt.GetComponent<Text>().text = factBuilding[rand];
        else if (PlayerMovement.sky)
            Txt.GetComponent<Text>().text = factSky[rand];
        else if (PlayerMovement.space)
            Txt.GetComponent<Text>().text = factSpace[rand];
    }
}
    
    
    
    
