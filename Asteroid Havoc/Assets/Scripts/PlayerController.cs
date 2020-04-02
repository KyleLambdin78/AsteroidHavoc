using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
 
    public RectTransform playerTransform;
    public RectTransform staticObject;
    public Image aimReticle;
    public Camera cam;
    public Text scoreText;
    public float currScore;

    
    void Start()
    {
        Cursor.visible = false;
        scoreText.text = "Asteroids:" + currScore;
    }

   
    void Update()
    {
        MoveController();
        if (Input.GetMouseButtonDown(0))
        {
            FirePink();
        }
        if (Input.GetMouseButtonDown(1))
        {
            FireGreen();
        }
        
    }
    public void MoveController()
    {
        Vector3 pos = Input.mousePosition;
        pos.z = staticObject.position.z;
        playerTransform.position = cam.ScreenToWorldPoint(pos);
    }
    public void FirePink()
    {
        aimReticle.color = new Color32(255, 0, 255, 255);
        var pinkRay = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(pinkRay, out hit))   
        {
            Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.gameObject.CompareTag("Pink"))
            {
                hit.collider.gameObject.GetComponent<MoveAsteroid>().SetVariables();
                currScore += 1;
                scoreText.text = "Asteroids Destroyed:" + currScore;
            }
            
        }
    }
    public void FireGreen()
    {
        aimReticle.color = new Color32(0, 255, 0, 255);
        var greenRay = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(greenRay, out hit) && (hit.transform.gameObject.CompareTag("Green")))
        {
            hit.collider.gameObject.GetComponent<MoveAsteroid>().SetVariables();
            currScore += 1;
            scoreText.text = "Asteroids Destroyed:" + currScore;
        }
    }
    
}
