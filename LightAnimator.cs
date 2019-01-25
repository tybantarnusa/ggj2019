using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAnimator : MonoBehaviour
{
    private Light light;
    private float timer;
    public float candleEffectDelay = 0.07f;

    void Start()
    {
        this.timer = candleEffectDelay;
        this.light = GetComponent<Light>();
    }

    void Update()
    {
        this.timer -= Time.deltaTime;
        if (this.timer <= 0) {
            this.light.range = Random.Range(16f, 20f);
            this.timer = candleEffectDelay;
        }
    }
}
