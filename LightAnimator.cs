using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAnimator : MonoBehaviour
{
    private Light lightComponent;
    private float timer;
    public float candleEffectDelay = 0.07f;

    void Start()
    {
        this.timer = candleEffectDelay;
        this.lightComponent = GetComponent<Light>();
    }

    void Update()
    {
        this.timer -= Time.deltaTime;
        if (this.timer <= 0) {
            this.lightComponent.range = Random.Range(16f, 20f);
            this.timer = candleEffectDelay;
        }
    }
}
