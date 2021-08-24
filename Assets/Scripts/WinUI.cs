using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class WinUI : MonoBehaviour
{
    [Header("UI Reference: ")]
    [SerializeField] private GameObject uiCanvas;
    [SerializeField] private Text uiWinnerText;
    [SerializeField] private Button uiRestartButton;

    [Header("Board Reference: ")]
    [SerializeField] private Board board;

    private void Start()
    {
        uiRestartButton.onClick.AddListener(() => SceneManager.LoadScene(1));
        board.OnWinAction += OnWinEvent;

        uiCanvas.SetActive(false);
    }

    private void OnWinEvent(Mark mark, Color color)
    {
        uiWinnerText.text = (mark == Mark.None) ? "Nobody Wins" :  mark.ToString() + " Wins ";
        uiWinnerText.color = color;

        uiCanvas.SetActive(true);
    }

    private void OnDestroy()
    {
        uiRestartButton.onClick.RemoveAllListeners();
        board.OnWinAction -= OnWinEvent;
    }
}
