using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour {

    [SerializeField]
    private float m_groundSpeed = 0.1f;

    [SerializeField]
    private List<GameObject> sprites;
    [SerializeField]
    public BoxCollider2D outBox;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // FixedUpdate is called once per physics frame
    private void FixedUpdate() {
        // move all objects allong the x axis
        foreach (GameObject obj in sprites){
            obj.transform.Translate(new Vector2(-m_groundSpeed, 0));
        }

        // if the leftmost object left the frame move it to the end
        GameObject o = sprites[0];
        if (isOutOfFrame(o)){
            o.GetComponent<Rigidbody2D>().MovePosition(new Vector2(sprites[sprites.Count - 1].transform.position.x + (((RectTransform)o.transform).rect.width*5), 
                                                                   o.transform.position.y));

            sprites.RemoveAt(0);
            sprites.Add(o);
        }
    }

    /**
     * Check if object has left frame on the left
     */
    private bool isOutOfFrame(GameObject obj){
        return outBox.IsTouching(obj.GetComponent<BoxCollider2D>());
    }
}
