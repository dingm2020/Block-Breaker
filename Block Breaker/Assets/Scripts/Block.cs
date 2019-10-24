using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {
    [SerializeField] private AudioClip breakSound;
    [SerializeField] private GameObject block_vfx;
    
    // Cached reference
    private LevelHandler level;

    private void Start() {
        level = FindObjectOfType<LevelHandler>();
        level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        DestroySFX();
        Destroy(gameObject);
        level.BlockDestroyed();
        DestroyVFX();
        //Debug.Log(collision.gameObject.name);
    }

    private void DestroySFX() {
        FindObjectOfType<GameStatus>().AddScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void DestroyVFX() {
        GameObject vfx = Instantiate(block_vfx, transform.position, transform.rotation);
        Destroy(vfx, 2f);
    }
}
