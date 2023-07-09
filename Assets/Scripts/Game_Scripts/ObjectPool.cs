using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private Queue<GameObject> pooledObjects;
    [SerializeField] private GameObject[] objectPrefab;
    [SerializeField] private int poolSize;

    private void Awake(){
        pooledObjects = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(objectPrefab[0]);
            obj.SetActive (false);
            pooledObjects.Enqueue(obj);
        }
    }

    public GameObject GetPooledObject(){
        GameObject obj = pooledObjects.Dequeue();
        obj.SetActive(true);
        pooledObjects.Enqueue(obj);
        return obj;
    }

    public void BulletType(int t){
        pooledObjects.Clear();
        Debug.Log("object clear");
        pooledObjects = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(objectPrefab[t]);
            obj.SetActive (false);
            pooledObjects.Enqueue(obj);
        }
    }
}
