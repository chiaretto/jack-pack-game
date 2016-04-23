using UnityEngine;
using System.Collections;

public class Smoke : MonoBehaviour {

    public Vector2 velocity = new Vector2(0, 0);
    public Vector2 forca = new Vector2(0, 0);
    public Vector2 position;
    public Rigidbody2D smoke;
    public GameObject player;

    private float alpha;

    private float rotation;
    public float scale = 0.2f;

    void Start()
    {
        this.smoke = GetComponent<Rigidbody2D>();
        this.smoke.velocity = velocity;
        this.smoke.position = new Vector3(0, 0, 0);

        
        this.smoke.transform.localScale = new Vector3(scale, scale, scale);

        this.rotation = Random.Range(0f, 360f);
        this.smoke.rotation = this.rotation;

        //GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
    }

    void Update () {

        this.smoke.AddForce(new Vector2(0, Random.Range(8f,9f)));
        float scale = 0.01f;
        if (this.smoke.transform.localScale.x <= 2)
        {
            this.smoke.transform.localScale += new Vector3(scale, scale, scale);
        }
        else
        {
            this.smoke.transform.localScale = new Vector3(2, 2, 2);
        }

        this.alpha -= 0.05f;
        //this.player.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, this.alpha);
        //GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);

        // Remover ao sair da tela
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(this.smoke.position);
        if (screenPosition.y > Screen.height || screenPosition.y < 0 || screenPosition.x > Screen.width || screenPosition.x < 0)
        {
            Destroy(this.gameObject, 0.1f);
        }
    }
}