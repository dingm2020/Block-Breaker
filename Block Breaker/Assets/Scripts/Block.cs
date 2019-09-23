using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    [SerializeField] private AudioClip breakSound;
    
    // Cached reference
    private LevelHandler level;

    private void Start() {
        level = FindObjectOfType<LevelHandler>();
        level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.BlockDestroyed();
        //Debug.Log(collision.gameObject.name);
    }
}
