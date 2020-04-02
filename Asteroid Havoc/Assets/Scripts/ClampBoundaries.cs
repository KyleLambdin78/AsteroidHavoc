using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampBoundaries : MonoBehaviour
{
    private Vector2 boundaries;
    void Start()
    {
        boundaries = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, boundaries.x, boundaries.x * -0.5f);
        viewPos.y = Mathf.Clamp(viewPos.y, boundaries.y, boundaries.y * -1.2f);
        transform.position = viewPos;
    }
}
