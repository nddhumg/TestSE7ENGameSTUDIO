using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : Singleton<EffectManager>
{
    [SerializeField] private ParticleSystem confettiExplosion;
    public void OnEffectConfettiExplosion(Vector3 position) {
        confettiExplosion.transform.localPosition = position;
        confettiExplosion.Play();
    }
}
