﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour {

    [SerializeField]
    private float m_speed = 0.11f;


    private bool working = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate() {
        this.GetComponent<Rigidbody2D>().transform.Translate(new Vector2(-m_speed, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        PlatformCharacter2D player = collision.gameObject.GetComponent<PlatformCharacter2D>();
        if (player && working) {
            print(player.IsJumping());
            if (!player.IsJumping()) {
                working = false;
                StartCoroutine(player.Fail());
            }
        }
        
    }
}
