using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerScript : MonoBehaviour {

    [SerializeField]
    private Animator m_startButton;
    [SerializeField]
    private Animator m_howToButton;
    [SerializeField]
    private Animator m_settingsButton;
    [SerializeField]
    private Animator m_settingsDialog;
    [SerializeField]
    private Animator m_howToDialog;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame() {
        SceneManager.LoadScene("Main");
    }

    public void OpenSettings() {
        SetAllButtonsVisible(false);
        m_settingsDialog.SetBool("isHidden", false);
    }

    public void CloseSettings() {
        m_settingsDialog.SetBool("isHidden", true);
        SetAllButtonsVisible(true);
    }

    public void OpenHowTo() {
        SetAllButtonsVisible(false);
        m_howToDialog.SetBool("isHidden", false);
    }

    public void CloseHowTo() {
        m_howToDialog.SetBool("isHidden", true);
        SetAllButtonsVisible(true);
    }

    private void SetAllButtonsVisible(bool visible) {
        visible = !visible;
        m_startButton.SetBool("isHidden", visible);
        m_howToButton.SetBool("isHidden", visible);
        m_settingsButton.SetBool("isHidden", visible);
    }
}
