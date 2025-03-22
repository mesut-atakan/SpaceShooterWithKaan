using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button exitButton;

    private void OnEnable()
    {
        resumeButton.onClick.AddListener(gameManager.ClosePauseMenu);
        exitButton.onClick.AddListener(Application.Quit);
    }
    private void OnDisable()
    {
        resumeButton.onClick.RemoveListener(gameManager.ClosePauseMenu);
        exitButton.onClick.RemoveListener(Application.Quit);
    }
}
