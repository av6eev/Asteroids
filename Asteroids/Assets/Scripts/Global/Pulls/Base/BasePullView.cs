﻿using UnityEngine;

namespace Global.Pulls.Base
{
    public abstract class BasePullView<T> : MonoBehaviour where T : BasePullElementView
    {
        [field: SerializeField] public Transform PullRoot { get; private set; }
        public T ElementPrefab { get; set; }
        public virtual int Count { get; set; }

        public T CreateObject()
        {
            return Instantiate(ElementPrefab, PullRoot);
        }
    }
}