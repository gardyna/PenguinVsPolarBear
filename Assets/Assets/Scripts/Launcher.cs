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
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.T)) {
            Fire();
        }
        foreach(GameObject o in m_crates) {
            if (IsOut(o)) {
                o.SetActive(false);
            }
        }
	}

    public void Fire() {
        GameObject h = m_crates[0];
        print("FIRE!!!");
        h.SetActive(true);
        h.GetComponent<Hazard>().isworking = true;
        h.transform.position = this.transform.position;
        m_crates.RemoveAt(0);
        m_crates.Add(h);
    }

    private bool IsOut(GameObject o) {
        return m_outBox.IsTouching(o.GetComponent<Collider2D>());
    }
}
