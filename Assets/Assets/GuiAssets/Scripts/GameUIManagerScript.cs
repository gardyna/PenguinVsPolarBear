using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUIManagerScript : MonoBehaviour {
    [SerializeField]
    private PlatformCharacter2D m_penguin;
    [SerializeField]
    private PlatformCharacter2D m_bear;

    [SerializeField]
    private Animator m_gameOverDialog;
    [SerializeField]
    private Text m_penguinFinalScore;
    [SerializeField]
    private Text m_bearFinalScore;

    [SerializeField]
    private Text m_penguinScore;
    [SerializeField]
    private Text m_bearScore;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        m_penguinScore.text = string.Format("Score: {0}", m_penguin.GetScore()).ToString();
        m_bearScore.text = string.Format("Score: {0}", m_bear.GetScore()).ToString();
	}

    public void GameOver() {
        m_penguinFinalScore.text = string.Format("Penguin: {0}", m_penguin.GetScore());
        m_bearFinalScore.text = string.Format("Bear: {0}", m_bear.GetScore());
        m_gameOverDialog.SetBool("isHidden", false);
    }

    public void GoToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
