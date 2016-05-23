using UnityEngine;
using System.Collections;

public class Generate : MonoBehaviour
{
    public GameObject rocks;
    public GameObject smoke;
    public GameObject terreno;
    public GameObject obstaculo;
    public GameObject emitterSmoke;
    private float intervalSmokeGenerate = 0.05f;

    // Use this for initialization
    void Start()
    {
//        Floatings();

        UpdateFloating(); 

        InvokeRepeating("CreateSmoke", 0f, intervalSmokeGenerate);
        InvokeRepeating("CreateTerreno", 0f, 0.18f);
        InvokeRepeating("CreateObstaculo", 1f, 2f);    
    }

    void CreateObstacle()
    {
        Instantiate(rocks);
    }
    
    void CreateSmoke()
    {
        Instantiate(smoke, emitterSmoke.transform.position, Quaternion.identity);
    }

    void CreateTerreno()
    {
        //UpdateFloating();

      	/**
      	 * Criar uma aleatoriadade para criar padrões não lineares no terreno.
      	 */
        if (Random.Range(-2f, 1f) > 0) {
            UpdateFloating();
        }

      	/**
      	 * Criar uma aleatoriadade para criar padrões não lineares no terreno.
      	 */
        if (Random.Range(-50f, 1f) > 0) {
            _index *= 2;
        }

        Instantiate(terreno, new Vector3(Screen.width/95, (float) y, -1), Quaternion.identity);

        Instantiate(terreno, new Vector3(Screen.width/95, (float) y + 9f, -1), Quaternion.identity);
    }

    void CreateObstaculo()
    {
        Instantiate(obstaculo, new Vector3(Screen.width/100, 0 , 0), Quaternion.identity);
    }

    // Variavel incrmental para calcular o seno
    private double _index;

  	// Posicao centralizada do terreno
    private float _posY = -4.5f;

    // Angulo de inclinacao do relevo
    private float _radiusY = 0.5f;

  	// Distancia entre relevo alto e baixo
    private float _frequencyY = 30;

  	// Posicao do terreno
    public double y;

	/**
	 * Cria uma nova posição para o proximo terreno
     */
    public void UpdateFloating()
    {
        y = _posY + Mathf.Sin ( (float) (_index * _frequencyY ) ) * _radiusY;
        _index += .03;
    }
    
}