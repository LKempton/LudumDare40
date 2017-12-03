using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlayPulse : MonoBehaviour {

    [SerializeField]
    private SpriteRenderer overlay;

    [SerializeField]
    private Color start;
    [SerializeField]
    private Color end;

    [SerializeField]
    private float pulseSpeed;

    private void OnEnable()
    {
        StartCoroutine(ColourPulse(pulseSpeed));
    }

    public void TogglePulse(bool isOn)
    {
        if (!isOn)
            overlay.enabled = false;
        else if (isOn)
            overlay.enabled = true;
    }

    IEnumerator ColourPulse(float duration)
    {
        bool isRising = true;

        while (true)
        {
            if (isRising)
            {
                float t = 0;

                while (t < 1)
                {
                    overlay.color = Color.Lerp(start, end, t);
                    t += Time.deltaTime / duration;
                    yield return null;
                }

                isRising = false;
            }
            else if (!isRising)
            {
                float t = 0;

                while (t < 1)
                {
                    overlay.color = Color.Lerp(end, start, t);
                    t += Time.deltaTime / duration;
                    yield return null;
                }
                isRising = true;
            }
        }
    }
}
