﻿using Global;
using Global.Base;
using UnityEngine;
using Utilities.Interfaces;

namespace Game.CamerasUpdaters.Base
{
    public abstract class BaseCameraFollowUpdater : IUpdater
    {
        protected Camera Camera { get; set; }
        public abstract Vector3 Offset { get; set; }

        public abstract void Update(IGlobalEnvironment environment);

        protected abstract Vector3 GetTarget(Vector3 shipPosition);
    }
}