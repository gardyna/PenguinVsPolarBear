using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour {

    [SerializeField]
    private float m_speed = 0.2f;
    [SerializeField]
    private bool m_isCrate;

    public bool isworking = false;
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
        if (player && isworking) {
            if (!IsAwoiding(player)) {
                isworking = false;
                StartCoroutine(player.Fail());
            }
        }
        
    }

    private bool IsAwoiding(PlatformCharacter2D player) {
        if (m_isCrate) {
            return player.IsJumping();
        }else {
            return player.IsSliding();
        }
        return false;
    }
}
