using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int CoinsToCollect;
    public PlayerGatherer Gatherer;
    public CameraController PlayerCamera;
    public GameObject PauseMenu;
    public GameObject DeathMenu;
    public GameObject SuccessMenu;
    public Text CoinText;

    private void Awake()
    {
        ResumeGame();
    }

    private void Update()
    {
        UpdateCoinText();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    void UpdateCoinText()
    {
        StringBuilder sb = new();
        sb.Append("Coins: ");
        sb.Append(Gatherer.CoinsCollected.ToString());
        sb.Append("/");
        sb.Append(CoinsToCollect);

        CoinText.text = sb.ToString();
    }

    public bool AllCoinsCollected()
    {
        return Gatherer.CoinsCollected >= CoinsToCollect;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        EnableCursor();
        PauseMenu.SetActive(true);

        Time.timeScale = 0f;
        PlayerCamera.enabled = false;
    }

    public void ResumeGame()
    {
        DisableCursor();
        PauseMenu.SetActive(false);
        DeathMenu.SetActive(false);
        SuccessMenu.SetActive(false);

        Time.timeScale = 1f;
        PlayerCamera.enabled = true;
    }

    public void CommitDeath()
    {
        EnableCursor();
        DeathMenu.SetActive(true);

        Time.timeScale = 0f;
        PlayerCamera.enabled = false;
    }

    public void CommitSuccess()
    {
        EnableCursor();
        SuccessMenu.SetActive(true);

        Time.timeScale = 0f;
        PlayerCamera.enabled = false;
    }

    public void EnableCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void DisableCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void QuitMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
