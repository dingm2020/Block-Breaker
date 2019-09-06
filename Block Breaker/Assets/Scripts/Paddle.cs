using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    
    // Configuration parameters
    [SerializeField] private float screenWidth = 16f, minX = 1f, maxX = 15f;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        float mousePos = Input.mousePosition.x / Screen.width * screenWidth;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePos, minX, maxX);
        transform.position = paddlePos;
    }
}
