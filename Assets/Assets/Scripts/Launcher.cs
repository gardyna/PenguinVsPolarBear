using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour {

    [SerializeField]
    private GameObject m_projectile;
    [SerializeField]
    private Collider2D m_outBox;

    [SerializeField]
    private List<GameObject> m_crates;
    [SerializeField]
    private List<GameObject> m_cielings;

	// Use this for initialization
	void Start () {
		foreach(GameObject h in m_crates) {
            h.SetActive(false);
        }
        foreach (GameObject h in m_cielings) {
            h.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.T)) {
            FireIce();
        }
        foreach(GameObject o in m_crates) {
            if (IsOut(o)) {
                o.SetActive(false);
            }
        }
        foreach(GameObject o in m_cielings) {
            if (IsOut(o)) {
                o.SetActive(false);
            }
        }
	}

    public void FireBox() {
        GameObject h = m_crates[0];
        print("FIRE!!!");
        h.SetActive(true);
        h.GetComponent<Hazard>().isworking = true;
        h.transform.position = this.transform.position;
        m_crates.RemoveAt(0);
        m_crates.Add(h);
    }

    public void FireIce() {
        GameObject i = m_cielings[0];
        print("Fire: ice");
        i.SetActive(true);
        i.GetComponent<Hazard>().isworking = true;
        i.transform.position = new Vector2(this.transform.position.x,
                                           this.transform.position.y+3);
        m_cielings.RemoveAt(0);
        m_cielings.Add(i);
    }

    private bool IsOut(GameObject o) {
        return m_outBox.IsTouching(o.GetComponent<Collider2D>());
    }
}
