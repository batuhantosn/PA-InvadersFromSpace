using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public GameObject bulletPrefab;
    public const float maxX = 3.4f;
    public const float minX = -3.4f;

    //private float speed = 3f;
    private bool isShooting = false;
    //private float cooldown = 0.5f;
    [SerializeField] private ObjectPool ObjectPool = null;

    public ShipStats shipStats;
    private Vector2 offScreenPos = new Vector2(0,-20f);
    private Vector2 startPos = new Vector2(0,-6.5f);

    private float dirX;

    private void Start() {
        shipStats.currentHealth = shipStats.maxHealth;
        shipStats.currenLifes = shipStats.maxLife;
        transform.position = startPos;
        UIManager.UpdateHealthBar(shipStats.currentHealth);
        UIManager.UpdateLives(shipStats.currenLifes);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)&& transform.position.x > minX)
        {
            transform.Translate(Vector2.left*Time.deltaTime*shipStats.shipSpeed);
        }
        if (Input.GetKey(KeyCode.D)&& transform.position.x < maxX)
        {
            transform.Translate(Vector2.right*Time.deltaTime*shipStats.shipSpeed);
        }
        if(Input.GetKey(KeyCode.Space) && !isShooting){
            StartCoroutine(Shoot());
        }

        dirX = Input.acceleration.x;
        //Debug.Log(dirX);
        if (dirX <= -0.1f && transform.position.x > minX)
        {
            transform.Translate(Vector2.left*Time.deltaTime*shipStats.shipSpeed);
        }
        if (dirX >= 0.1f && transform.position.x < maxX)
        {
            transform.Translate(Vector2.right*Time.deltaTime*shipStats.shipSpeed);
        }

    }
    public void ShootButton(){
        if (!isShooting)
        {
            StartCoroutine(Shoot());
        }
    }

    public void AddHealth(){
        if (shipStats.currentHealth == shipStats.maxHealth)
        {
            UIManager.UpdateScore(250);
        }else
        {
            shipStats.currentHealth++;
            UIManager.UpdateHealthBar(shipStats.currentHealth);
        }
    }

    public void AddLife(){
        if (shipStats.currenLifes == shipStats.maxLife)
        {
            UIManager.UpdateScore(1000);
        }else
        {
            shipStats.currenLifes++;
            UIManager.UpdateLives(shipStats.currenLifes);
        }
    }

    private IEnumerator Shoot(){
        isShooting = true;
        //Instantiate(bulletPrefab,transform.position,Quaternion.identity);
        GameObject obj = ObjectPool.GetPooledObject();
        obj.transform.position = gameObject.transform.position;
        yield return new WaitForSeconds(shipStats.fireRate);
        isShooting = false;
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            //Debug.Log("Vurulduk");
            other.gameObject.SetActive(false);
            TakeDamage();
        }
    }
    private IEnumerator Respawn(){
        transform.position = offScreenPos;
        yield return new WaitForSeconds(2);
        shipStats.currentHealth = shipStats.maxHealth;
        transform.position = startPos;
        UIManager.UpdateHealthBar(shipStats.currentHealth);
    }
    public void TakeDamage(){
        shipStats.currentHealth--;
        UIManager.UpdateHealthBar(shipStats.currentHealth);
        if (shipStats.currentHealth <=0)
        {
            shipStats.currenLifes--;
            UIManager.UpdateLives(shipStats.currenLifes);
            if(shipStats.currenLifes <=0){
            Debug.Log("Game Over");
            }
            else{
            Debug.Log("Respawn");
            StartCoroutine(Respawn());
            }
        }
        
            
    }
}
