using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Player : MonoBehaviour
{
    public Animator _animacao;

    const float VELOCIDADELIMITEVOO = 2.5f;
    const float VELOCIDADELIMITEQUEDA = -2.5f;
    const float FORCAJETPACK = 9.5f;
    private bool voando;
    public float _velocidadeY;
    private Rigidbody2D player;

	private Text pontuacao;
    private int score;
    static int record;

	private bool die = false;

	public AudioClip jetpack_clip_up;
	public AudioClip jetpack_clip_down;
	public AudioClip jetpack_clip_die;
  	public AudioClip player_count_point;

	AudioSource jetpack_audio;
  	AudioSource player_point_audio;
    public AudioSource[] sounds = null;

    void Start()
    {
		Time.timeScale = 1f;

        player = GetComponent<Rigidbody2D>();
       _animacao = GetComponentInChildren<Animator>();

        jetpack_audio = sounds[0];
        player_point_audio = sounds[1];
    }

    // Update is called once per frame
    void Update()
    {
        // Identifica a acao
        if (Input.GetMouseButton(0) || Input.touchCount > 0 || Input.GetKey(KeyCode.Space))
        {
            voando = true;
        }
        else
        {
            voando = false;
        }

        // Decteta fuga do limite do cenário
        DetectaLimiteCenario();

        // Voando
		if(!die){
			ControleDeVoo();
		}
        
        // Atualiza pontos
        AtualizaPontos();
    }

    // Mata quando o personagem sai do cenario
    void DetectaLimiteCenario()
    {
        // Die by being off screen
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.y > Screen.height || screenPosition.y < 0)
        {
            Die();
        }
    }

    // Die by collision
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Obstaculo")
        {
            Die();
        }
        
    }

	void PararTrilhaSonora(){
		AudioSource camera_audio = (AudioSource)GameObject.FindWithTag("MainCamera").GetComponent<AudioSource>();
		camera_audio.Stop ();
	}

    // Recarrega a cena
	void Die()
    {
		PararTrilhaSonora ();

		die = true;

		jetpack_audio.loop = false;
		jetpack_audio.clip = jetpack_clip_die;
		jetpack_audio.volume = 1f;
		jetpack_audio.Play ();

		Time.timeScale = 0f;
        
		StartCoroutine(Pause(1));
    }

    private IEnumerator Pause(int p)
    {
        Time.timeScale = 0.001f;
        float pauseEndTime = Time.realtimeSinceStartup + 1;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        Time.timeScale = 1;

		//SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		SceneManager.LoadScene ("menu");
    }

    void ControleDeVoo()
    {
        _animacao.SetBool("voando", voando);

        // Flying
        if (voando) {
			// UP
			// Audio
			jetpack_audio.loop = true;
			jetpack_audio.clip = jetpack_clip_up;
			jetpack_audio.volume = 1f;

			if (!jetpack_audio.isPlaying) {
				jetpack_audio.Play ();
			}

            // Angulo do personagem
            if (player.rotation < 350) {
                player.rotation ++;
            } else {
                player.rotation = 350f;
            }

            // Força de voo
            if (player.velocity.y < VELOCIDADELIMITEVOO) {
                player.AddForce(new Vector2(0, FORCAJETPACK));
            }
        }
        else {
			// DOWN
			// Audio
			jetpack_audio.loop = true;
			jetpack_audio.clip = jetpack_clip_down;
			jetpack_audio.volume = 0f;

			if (!jetpack_audio.isPlaying) {
				jetpack_audio.Play ();
			}


            // Angulo do personagem
            if (player.rotation > 330) {
                player.rotation -= 0.5f;
            } else {
                player.rotation = 330;
            }
            
            // Força de queda
            if (player.velocity.y < VELOCIDADELIMITEQUEDA) {
                player.velocity = new Vector2(0, VELOCIDADELIMITEQUEDA);
            } 
           
        }

        this._velocidadeY = this.player.velocity.y;
    }

    public void CountPoint()
    {
      	player_point_audio.loop = false;
        player_point_audio.clip = player_count_point;
        player_point_audio.volume = 1f;
        player_point_audio.Play ();

        ++this.score;
        if (this.score <= Player.record)
            return;
        Player.record = this.score;
    }

    public int GetPoints()
    {
        return this.score;
    }

    private void AtualizaPontos()
    {
        this.pontuacao = GameObject.FindWithTag("Pontuacao").GetComponent<Text>();
        this.pontuacao.text = this.score.ToString() + "\n" + Player.record.ToString();
    }

}
