using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{

    Rigidbody2D birdRB;
    [SerializeField]
    float birdSpeed;

    int angle;
    int minAngle=-90;
    int maxAngle=20;
    Score scorer;
    // Start is called before the first frame update
    void Start()
    {
        birdRB = GetComponent<Rigidbody2D>();
        scorer = GameObject.Find("ScoreManager").GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            birdRB.velocity = Vector2.zero;
            birdRB.velocity = new Vector2(birdRB.velocity.x, birdSpeed);
        }
        BirdRotation();  
    }

    void BirdRotation()
    {
        if (birdRB.velocity.y > 0)
        {
            if (angle <= maxAngle)
            {
                angle = angle + 5;
            }
        }
        else if (birdRB.velocity.y < 0)
        {
            if (angle >= minAngle)
            {
                angle = angle - 5;
            }
        }

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            scorer.ScoreIncrement();
        }
    }
}
