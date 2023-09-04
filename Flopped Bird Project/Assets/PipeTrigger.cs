using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeTrigger : MonoBehaviour
{
    public LogicScript logic;
    AudioSource PointSfx;
    public bool isAlive;

    // Start is called before the first frame update
    void Start()
    {
        //looks for an object in game with the tag "Logic", then looks for a component with script
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        PointSfx = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        isAlive = GameObject.Find("BlackBird").GetComponent<BirdScript>().isAlive;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3 && isAlive)
        {
            logic.AddScore(1);
            PointSfx.Play();
        }
    }
}
