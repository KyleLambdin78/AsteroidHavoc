using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveAsteroid : MonoBehaviour
{
    private float speed;
    public GameObject asteroidManager;
    private Vector3 offset;
    public float offsetRange;
    public float minSpeed;
    public float maxSpeed;
    public Material[] materialColor;



    private Material currentMaterial;
    void Start()
    {
        SetVariables();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
       
    }
    private void OnTriggerEnter(Collider other)
    {
        SetVariables();
    }
    public void SetVariables()
    {
        offset = new Vector3(Random.Range(offsetRange, -offsetRange), Random.Range(offsetRange, -offsetRange), Random.Range(offsetRange, -offsetRange));
        transform.position = asteroidManager.transform.position + offset;
        speed = Random.Range(minSpeed, maxSpeed);
        int whichColor = Random.Range(0, 99);
        var thisRenderer = gameObject.GetComponent<Renderer>();
        if (whichColor < 50)
        {
            Debug.Log(whichColor);
            gameObject.tag = "Pink";
            currentMaterial = materialColor[0];
            thisRenderer.material = currentMaterial;
        }
        else if (whichColor >= 50)
        {
            Debug.Log("Green");
            gameObject.tag = "Green";
            currentMaterial = materialColor[1];
            thisRenderer.material = currentMaterial;
        }
        
    }
}
