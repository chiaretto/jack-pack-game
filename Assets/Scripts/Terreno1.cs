using UnityEngine;

public class Terreno1 : MonoBehaviour
{
    const float velocity = 6f;
    private Vector2 position;
    private Rigidbody2D obstacle;

    void Start()
    {
    	obstacle = GetComponent<Rigidbody2D>();
        obstacle.velocity = new Vector2(velocity * -1, 0);
        // obstacle.position = new Vector3(Screen.width/100, Random.Range(-4.6f, -3.6f), 0);
    }

    void Update () {

        Vector2 screenPosition = Camera.main.WorldToScreenPoint(obstacle.position);
        if (screenPosition.x < ((Screen.width / 2) * 1.1) *-1 )
        {
            Destroy(gameObject);
        }

    }

}