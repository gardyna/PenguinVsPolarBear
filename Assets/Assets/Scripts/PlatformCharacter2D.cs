﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCharacter2D : MonoBehaviour {

    [SerializeField]
    private float m_jumpForce = 400f;
    [SerializeField]
    private LayerMask m_whatIsGround;

    [SerializeField]
    private AudioClip m_yayClip;

    private Rigidbody2D m_rigidbody;
    private bool m_grounded = true;
    private Transform m_groundCheck;
    private Animator m_anim;
    private bool m_sliding = false;
    private bool m_isfail = false;

    private int score = 100;

    private AudioSource[] sounds;

    // Use this for initialization
    void Start () {
        sounds = GetComponents<AudioSource>();
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_groundCheck = transform.Find("GroundCheck");
        m_anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate() {
        m_grounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_groundCheck.position, .2f, m_whatIsGround);
        for(int i = 0; i < colliders.Length; i++) {
            if(colliders[i].gameObject != gameObject) {
                m_grounded = true;
            }
        }
        m_anim.SetBool("Grounded", m_grounded);
        m_anim.SetBool("Sliding", m_sliding);
    }

    public void Move(bool crouch, bool m_Jump) {
        if (m_Jump && m_grounded) {
            Jump();
        }
        if (crouch) {
            m_sliding = true;
        } else {
            m_sliding = false;
        }

        m_anim.SetBool("IsFail", m_isfail);
    }

    private void Jump() {
        print("jump");
        m_grounded = false;
        m_rigidbody.AddForce(new Vector2(0f, m_jumpForce));
    }

    public int GetScore() {
        return score;
    }

    public bool IsJumping() {
        return !m_grounded;
    }

    public bool IsSliding() {
        return m_sliding;
    }

    public IEnumerator Fail() {
        m_isfail = !m_isfail;
        //GetComponent<AudioSource>().Play();
        sounds[0].Play();
        score = score < 0 ? 0 : score-1;
        yield return new WaitForSeconds(.5f);
        m_isfail = !m_isfail;
    }

    public void Yay() {
        sounds[1].Play();
        //GetComponent<AudioSource>().PlayOneShot(m_yayClip);
    }
}
