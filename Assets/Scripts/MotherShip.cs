using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShip : MonoBehaviour
{
    public int scoreValue;

    private const float MAX_LEFT = -5;
    private float speed = 5;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime*speed);
        if (transform.position.x <= MAX_LEFT)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("FriendlyBullet"))
		{
            UIManager.UpdateScore(scoreValue);
			other.gameObject.SetActive(false);
			Destroy(gameObject);
		}
    }
}
