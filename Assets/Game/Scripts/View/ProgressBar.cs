using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image _line;

    private float _percent;

    public void SetProgress(int value, int max)
    {
        if (max == 0)
            _percent = 0;
        else
            _percent = (float)value / max * 100;

        _line.fillAmount = _percent / 100;
    }
}