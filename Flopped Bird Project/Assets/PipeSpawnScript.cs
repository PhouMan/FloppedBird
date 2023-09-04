using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject Pipe;
    public float SpawnRate = 2;
    private float timer = 0;
    public float offSetY = 5;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {   if (timer < SpawnRate)
        {
            timer += Time.deltaTime;
        }
        else if (GameObject.Find("BlackBird").GetComponent<BirdScript>().isAlive)
        {
            SpawnPipe();
            timer = 0;
        }

   
    }
    void SpawnPipe()
    {
        float minY = transform.position.y - offSetY;
        float maxY = transform.position.y + offSetY;
        Instantiate(Pipe, new Vector3(transform.position.x, Random.Range(minY, maxY), 0), transform.rotation);
    }
}
