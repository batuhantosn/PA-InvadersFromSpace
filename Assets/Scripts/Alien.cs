using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public int scoreValue;
    public GameObject expolosion;

    public void Kill(){
        AlienMaster.allAliens.Remove(gameObject);
        Instantiate(expolosion,transform.position,Quaternion.identity);
        gameObject.SetActive(false);
    }
}
