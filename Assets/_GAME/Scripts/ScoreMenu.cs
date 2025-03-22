using UnityEngine;
using TMPro;

public class ScoreMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreValueLabel;

    public void ChangeScore(int value)
    {
        scoreValueLabel.text = value.ToString();
    }
}