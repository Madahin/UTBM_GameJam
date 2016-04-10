using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using UnityEngine.UI;

public class CameraEffect : MonoBehaviour {

    private Fisheye _fisheye;
    private Image _cadreVieImage;

    private BarbieLife _life;

    private int lastlifePoint;
    private int maxlifepoint;
	// Use this for initialization
	void Start () {
        _fisheye = this.GetComponentInChildren<Fisheye>();
        
        _life = this.GetComponent<BarbieLife>();
        lastlifePoint = _life.life;
        maxlifepoint = _life.life;
        _cadreVieImage = GameManager.Instance.CadreVie.GetComponent<Image>();
	}

    bool ispressed = false;

	// Update is called once per frame
	void Update () {

        

        /*if (Input.GetKeyDown(KeyCode.E) && !ispressed)
        {
            _life.decreaseLife(1);
            ispressed = true;
        }

        if(ispressed && Input.GetKeyUp(KeyCode.E))
        {
            ispressed = false;
        }

        if (Input.GetKeyDown(KeyCode.R))
            _life.life = 5;*/

        if(lastlifePoint != _life.life)
        {
            lastlifePoint = _life.life;
            _fisheye.strengthX = Mathf.Lerp(0.0f, 0.7f, (float)1.0f - ((float)_life.life / (float)maxlifepoint));
            _fisheye.strengthY = Mathf.Lerp(0.0f, 0.7f, (float)1.0f - ((float)_life.life / (float)maxlifepoint));
            _cadreVieImage.color = new Color(_cadreVieImage.color.r,
                                            _cadreVieImage.color.g,
                                            _cadreVieImage.color.b,
                                            Mathf.Lerp(0.0f, 1.0f, (float)1.0f - ((float)_life.life / (float)maxlifepoint)));
            
        }
	}

    private void modifyEffects()
    {

    }
}
