using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatEffect : MonoBehaviour {

    // private fields
    private float startY = 0f;
    private float duration = 1f;
    private RectTransform rectTrans;

	// Use this for initialization
	void Start () {
        rectTrans = GetComponent<RectTransform>();
        startY = rectTrans.anchoredPosition.y;
	}
	
	// Update is called once per frame
	void Update () {
        var newY = startY + (startY + Mathf.Cos(Time.time / duration * 2) / .1f);
        rectTrans.anchoredPosition = new Vector2(rectTrans.position.x, newY);
	}
}
