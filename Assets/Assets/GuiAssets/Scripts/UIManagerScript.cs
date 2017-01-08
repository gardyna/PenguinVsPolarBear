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

    [SerializeField]
    private Animator m_startSingleButton;

    public bool m_hardMode { get; set; }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Called when start button is pressed
    /// launches the main scene
    /// </summary>
    public void StartGame() {
        if (m_hardMode) {
            SceneManager.LoadScene("Main_Hard");
        } else {
            SceneManager.LoadScene("Main");
        }
    }

    public void StartSinglePlayer() {
        if (m_hardMode) {
            SceneManager.LoadScene("SinglePlayerMain_Hard");
        } else {
            SceneManager.LoadScene("SinglePlayerMain");
        }
    }

    /// <summary>
    /// Called when settings button is pressed
    /// brings forth the settings panel
    /// </summary>
    public void OpenSettings() {
        SetAllButtonsVisible(false);
        m_settingsDialog.SetBool("isHidden", false);
    }

    /// <summary>
    /// Called when the top right button on settings pannel is pressed
    /// goes back to main selection
    /// </summary>
    public void CloseSettings() {
        m_settingsDialog.SetBool("isHidden", true);
        SetAllButtonsVisible(true);
    }

    /// <summary>
    /// Called when "how to" button is pressed
    /// calls forth the how to panel
    /// </summary>
    public void OpenHowTo() {
        SetAllButtonsVisible(false);
        m_howToDialog.SetBool("isHidden", false);
    }

    /// <summary>
    /// Called when top right button on how to pannel is pressed
    /// goes back to main selection
    /// </summary>
    public void CloseHowTo() {
        m_howToDialog.SetBool("isHidden", true);
        SetAllButtonsVisible(true);
    }


    /// <summary>
    /// hides or un-hides the main menu buttons
    /// </summary>
    /// <param name="visible">weather the menu should be visible</param>
    private void SetAllButtonsVisible(bool visible) {
        visible = !visible;
        m_startButton.SetBool("isHidden", visible);
        m_howToButton.SetBool("isHidden", visible);
        m_settingsButton.SetBool("isHidden", visible);
        m_startSingleButton.SetBool("isHidden", visible);
    }
}
