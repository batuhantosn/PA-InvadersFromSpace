using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMaster : MonoBehaviour
{
    [SerializeField] private ObjectPool ObjectPool = null;
    public GameObject bulletPrefab;
    private Vector3 hMoveDistance = new Vector3(0.05f,0,0);
    private Vector3 vMoveDistance = new Vector3(0,0.15f,0);

    private const float MAX_LEFT = -3.3f;
    private const float MAX_RIGHT = 3.3f;
    public static List<GameObject> allAliens = new List<GameObject>();

    private bool movingRight;
    private float moveTimer = 0.01f;
    private float moveTime = 0.005f;
    private const float MAX_MOVESPEED = 0.02f;
    private float shootTimer = 3f;
    private const float ShootTime = 3f;
    public GameObject motherShipPrefab;
    private Vector3 motherShipSpawnPos = new Vector3(5f,5.75f,0);

    private float motherShipTimer = 60f;
    private const float MOTHERSHIP_MIN = 15f;
    private const float MOTHERSHIP_MAX = 60f;
    private const float START_Y = 1.7f;
    private bool entering = true;

    void Start()
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Alien"))
        {
            allAliens.Add(go);
        }
    }

    void Update()
    {

        if (entering)
        {
            transform.Translate(Vector2.down*Time.deltaTime*10);
            if (transform.position.y <= START_Y)
            {
                entering = false;
            }
        }
        else
        {
            if (moveTimer <= 0)
        {
            MoveEnemies();
        }
        if (shootTimer <= 0)
        {
            Shoot();
        }
        if (motherShipTimer<=0)
        {
            SpawnMotherShip();
        }
        moveTimer -= Time.deltaTime;
        shootTimer -= Time.deltaTime;
        motherShipTimer -= Time.deltaTime;
        }
        
    }

    private void MoveEnemies(){

        int hitMax = 0;
        if (allAliens.Count>0)
        {
            for (int i = 0; i < allAliens.Count; i++)
            {
                if (movingRight)
                {
                    allAliens[i].transform.position += hMoveDistance;
                }else
                {
                    allAliens[i].transform.position -=hMoveDistance;
                }
                if (allAliens[i].transform.position.x > MAX_RIGHT || allAliens[i].transform.position.x < MAX_LEFT)
                {
                    hitMax++;
                }
            }
            if (hitMax>0)
            {
                for (int i = 0; i < allAliens.Count; i++)
                {
                    allAliens[i].transform.position-=vMoveDistance;
                }
                movingRight = !movingRight;
            }
        }
        moveTimer = GetMoveSpeed();
    }
    private void SpawnMotherShip(){
        Instantiate(motherShipPrefab,motherShipSpawnPos,Quaternion.identity);
        motherShipTimer = Random.Range(MOTHERSHIP_MIN,MOTHERSHIP_MAX);
    }

    private void Shoot(){
        Vector2 pos = allAliens[Random.Range(0,allAliens.Count)].transform.position;
        //Instantiate(bulletPrefab,pos,Quaternion.identity);
        GameObject obj = ObjectPool.GetPooledObject();
        obj.transform.position = pos;
        shootTimer = ShootTime;
    }

    private float GetMoveSpeed(){
        float f = allAliens.Count * moveTime;
        if (f < MAX_MOVESPEED)
        {
            return MAX_MOVESPEED;
        }else{
            return f;
        }
    }
}
