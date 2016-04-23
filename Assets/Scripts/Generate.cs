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
        Floatings();

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
        // UpdateFloating();   

        if (Random.Range(-2f, 1f) > 0) {
            UpdateFloating();    
        }
        
        if (Random.Range(-50f, 1f) > 0) {
            // _index *= 2;
        }

        Instantiate(terreno, new Vector3(Screen.width/95, (float) y, -1), Quaternion.identity);

        Instantiate(terreno, new Vector3(Screen.width/95, (float) y + 9f, -1), Quaternion.identity);
    }

    void CreateObstaculo()
    {
        Instantiate(obstaculo, new Vector3(Screen.width/100, 0 , -2), Quaternion.identity);
    }

    private double _index;
    private float _posY = -4.5f;
    private float _radiusY = 0.2f;
    private float _frequencyY = 30f;
    private float _phase;
    private double y;

    private void Floatings() 
    {
        // _frequencyY = (1 + (Random.Range(0f, 1f) * 3)) / 2;
        _phase = Random.Range(0f, 1f) * (2 * Mathf.PI);
    }

    public void UpdateFloating()
    {
        y = _posY + Mathf.Sin ( (float) (_index * _frequencyY + _phase) ) * _radiusY;
        _index += .03;
    }
    
}