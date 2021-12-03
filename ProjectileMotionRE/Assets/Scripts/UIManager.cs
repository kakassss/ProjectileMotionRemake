using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] TextMeshProUGUI ballSpeedText;
    [SerializeField] Slider ballSpeedSlider;

    [SerializeField] TextMeshProUGUI ballHeightText;
    [SerializeField] Slider ballHeightSlider;

    [SerializeField] TextMeshProUGUI ballDesPosText;

    [Header("Ball Speed/Height")]
    [SerializeField] [Range(1, 100)] int ballSpeedMin;
    [SerializeField] [Range(1, 100)] int ballSpeedMax;

    [SerializeField] [Range(1,100)] int ballHeightMin;
    [SerializeField] [Range(1,100)] int ballHeightMax;

    private void Start()
    {
        ballSpeedSlider.minValue = ballSpeedMin;
        ballSpeedSlider.maxValue = ballSpeedMax;

        ballHeightSlider.minValue = ballHeightMin;
        ballHeightSlider.maxValue = ballHeightMax;
    }
    public Ball ballUI(Ball ball)
    {
        ballSpeedText.text = "Speed:" + ball.speed.ToString("0");
        ball.speed = ballSpeedSlider.value;

        ballHeightText.text = "Height:" + ball.launchHeight.ToString("0");
        ball.launchHeight = ballHeightSlider.value;

        return ball;
    }
    public Ball DesPosBall(Ball ball)
    {
        ballDesPosText.text = "DestinationPos:" + ball.endPos.ToString();
        return ball;
    }
}
