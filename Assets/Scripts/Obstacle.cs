using UnityEngine;

public class Obstacle : MonoBehaviour
{
    const float velocity = 3f;
    private Vector2 position;
    private Rigidbody2D obstacle;

    private bool passed;
    private GameObject player;

    // Use this for initialization
    void Start()
    {
    	player = GameObject.FindWithTag("Player");
    	int points = player.GetComponent<Player>().GetPoints();

    	obstacle = GetComponent<Rigidbody2D>();
        obstacle.velocity = new Vector2(velocity * -1, 0);
        obstacle.position = new Vector3(Screen.width/100, Random.Range(-0.8f, 1.5f), 0);
    }

    void Update () {

        Vector2 screenPosition = Camera.main.WorldToScreenPoint(obstacle.position);
        if (screenPosition.x < ((Screen.width / 2) * 1.1) *-1 )
        {
            Destroy(gameObject, 0.1f);
        }

		if (!passed) {
	        
	        if (obstacle.position.x < player.GetComponent<Rigidbody2D>().position.x){
        		player.GetComponent<Player>().CountPoint();
				passed = true;
	        }
	    }
    }

   
}