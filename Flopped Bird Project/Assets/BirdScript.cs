using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D BirdRigidBody;
    public float flapPower;
    public LogicScript logic;
    public bool isAlive = true;
    CircleCollider2D birdCollider;

    public GameObject WingUp;
    public GameObject WingDown;

    private Vector3 ogScale;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        birdCollider = GetComponent<CircleCollider2D>();
        birdCollider.isTrigger = false;
        ogScale = transform.localScale;
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && isAlive)
        {
            BirdRigidBody.velocity = Vector2.up * flapPower;
            WingUp.SetActive(true);
            WingDown.SetActive(false);
        }
        else if (!(Input.GetKey(KeyCode.Space)))
        {
            WingUp.SetActive(false);
            WingDown.SetActive(true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.GameOver();
        isAlive = false;
        birdCollider.isTrigger = true;
        BirdRigidBody.velocity = Vector2.zero;
        transform.localScale = new Vector3(ogScale.x, -1*ogScale.y, ogScale.z);
    }
}
