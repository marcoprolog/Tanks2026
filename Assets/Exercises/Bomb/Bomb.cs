using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    //time until explosion
    public float timer = 10;

    Material bombMaterial;

    //variables to change the color of the bomb (making it pulse)
    Color colorOff = Color.black;
    Color colorOn = Color.red;
    public float colorChangeSpeed = 3;

    //Variables for range and damage of the explosion
    public float explosionRange = 10;
    public float bombDamage = 10;

    //reference to the explosion prefab, remember to add it in the inspector
    public GameObject m_ExplosionPrefab;
    private AudioSource m_ExplosionAudio;
    private ParticleSystem m_ExplosionParticles;

    //variables to refer to the range wheel
    public GameObject rangeWheel;
    SpriteRenderer rangeRenderer;

    private void Awake()
    {
        m_ExplosionParticles = Instantiate(m_ExplosionPrefab).GetComponent<ParticleSystem>();
        m_ExplosionAudio = m_ExplosionParticles.GetComponent<AudioSource>();

        m_ExplosionParticles.gameObject.SetActive(false);
    }

    // Use this for initialization
    void Start () {
        bombMaterial = GetComponent<Renderer>().material;

        //make the bomb explode after the specified time
        Invoke("Explode", timer);

        //scale the range wheel to the explosion range
        rangeWheel.transform.localScale = new Vector3(explosionRange, explosionRange, 1);
        rangeRenderer = rangeWheel.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        //shifts betweet the two colors for the bomb and the range
        //notice that I subtracted a color(0,0,0,0.5f), meaning I am increasing the transparency of the color
        bombMaterial.color = Color.Lerp(colorOff, colorOn, Mathf.PingPong(Time.time * colorChangeSpeed, 1));
        rangeRenderer.color = Color.Lerp(colorOff - new Color(0,0,0,0.5f), colorOn - new Color(0, 0, 0, 0.5f), Mathf.PingPong(Time.time * colorChangeSpeed, 1));
        
    }

    void Explode()
    {
        //find players and apply damage
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject player in players)
        {
            //if the distance is less than the range
            if (Vector3.Distance(player.transform.position, transform.position) <= explosionRange)
            {
                //apply damage
                player.GetComponent<Tanks.Complete.TankHealth>().TakeDamage(bombDamage);
            }
        }

        //start particle and audio effects
        m_ExplosionParticles.transform.position = transform.position;
        m_ExplosionParticles.gameObject.SetActive(true);
        m_ExplosionParticles.Play();
        m_ExplosionAudio.Play();

        Destroy(gameObject);
    }
}
