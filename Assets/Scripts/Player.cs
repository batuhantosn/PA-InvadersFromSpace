using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    public const float maxX = 2.18f;
    public const float minX = -2.18f;

    private float speed = 3f;
    private bool isShooting = false;
    private float cooldown = 0.5f;
    [SerializeField] private ObjectPool ObjectPool = null;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)&& transform.position.x > minX)
        {
            transform.Translate(Vector2.left*Time.deltaTime*speed);
        }
        if (Input.GetKey(KeyCode.D)&& transform.position.x < maxX)
        {
            transform.Translate(Vector2.right*Time.deltaTime*speed);
        }
        if(Input.GetKey(KeyCode.Space) && !isShooting){
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot(){
        isShooting = true;
        //Instantiate(bulletPrefab,transform.position,Quaternion.identity);
        GameObject obj = ObjectPool.GetPooledObject();
        obj.transform.position = gameObject.transform.position;
        yield return new WaitForSeconds(cooldown);
        isShooting = false;
    }
}
