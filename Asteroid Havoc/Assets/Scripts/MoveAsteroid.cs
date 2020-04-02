using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveAsteroid : MonoBehaviour
{
    private float speed;
    public GameObject asteroidManager;
    private Vector3 offset;
    public Vector3 offsetRange;
    public float minSpeed;
    public float maxSpeed;
    private ParticleSystem MPS;
    public Material[] materialColor;



    private Material currentMaterial;
    void Start()
    {
        MPS = GetComponent<ParticleSystem>();
        StartCoroutine(SetVariables());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
       
    }
  
    public IEnumerator SetVariables()
    {
        offset = new Vector3(Random.Range(offsetRange.x, -offsetRange.x), Random.Range(offsetRange.y, -offsetRange.y), Random.Range(offsetRange.z, -offsetRange.z));
        transform.position = asteroidManager.transform.position + offset;
        speed = Random.Range(minSpeed, maxSpeed);
        int whichColor = Random.Range(0, 99);
        var thisRenderer = gameObject.GetComponent<Renderer>();
        ParticleSystem.MainModule myParticle = MPS.main;
        if (whichColor < 50)
        {
            Debug.Log(whichColor);
            gameObject.tag = "Pink";
            currentMaterial = materialColor[0];
            thisRenderer.material = currentMaterial;
            myParticle.startColor = new Color(255, 0, 255, 255);
            yield return true;
        }
        else if (whichColor >= 50)
        {
            Debug.Log("Green");
            gameObject.tag = "Green";
            currentMaterial = materialColor[1];
            thisRenderer.material = currentMaterial;
            myParticle.startColor = new Color(0, 255, 0, 255);
            yield return true;
        }
        
    }
}
