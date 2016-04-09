using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeScreenAutoRef : MonoBehaviour {

    private Image fadeScreen;
    private Color _transparentColor;
    private Color _opaqueColor;
    public const float _fadeTime = 3.0f;
    private float _fadeTimer;

    // Use this for initialization
    void Start () {
        GameManager.Instance.fadeScreen = this;
        fadeScreen = GetComponent<Image>();
        FadeIn();
	}

    public void FadeIn()
    {
        _opaqueColor = new Color(fadeScreen.color.r,
                                    fadeScreen.color.g,
                                    fadeScreen.color.b,
                                    fadeScreen.color.a);

        _transparentColor = new Color(fadeScreen.color.r,
                                        fadeScreen.color.g,
                                        fadeScreen.color.b,
                                        0.0f);

        StopCoroutine(FadeInDelayed());
        _fadeTimer = 0.0f;
        StartCoroutine(FadeInDelayed());
        }
        

    private IEnumerator FadeInDelayed()
    {
        while (_fadeTimer < _fadeTime)
        {
            _fadeTimer = _fadeTimer + Time.deltaTime;
            fadeScreen.color = Color.Lerp(_opaqueColor, _transparentColor, _fadeTimer / _fadeTime);
            yield return new WaitForEndOfFrame();
        }
    }

    public void FadeOut()
    {

    }

    private IEnumerator FadeOutDelayed()
    {
        while (_fadeTimer < _fadeTime)
        {
            _fadeTimer = _fadeTimer + Time.deltaTime;
            fadeScreen.color = Color.Lerp( _transparentColor, _opaqueColor, _fadeTimer / _fadeTime);
            yield return new WaitForEndOfFrame();
        }
    }

}
