using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnAnimationEvent : MonoBehaviour
{
    public float delay;
    void Start()
    {
        Destroy(gameObject,GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
    }
}
