﻿using Global.Pulls.ParticleSystem.Hit.Base;
using UnityEngine;

namespace Global.Pulls.ParticleSystem.Hit
{
    public class HitView3D : MonoBehaviour, IHitView
    {
        public void ChangeVisibility(bool state) => gameObject.SetActive(state);
    }
}