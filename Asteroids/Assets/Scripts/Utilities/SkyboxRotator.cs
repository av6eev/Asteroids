using UnityEngine;

namespace Utilities
{
    public class SkyboxRotator : MonoBehaviour
    {
        private static readonly int Rotation = Shader.PropertyToID("_Rotation");
        [field: SerializeField] public float Speed { get; private set; }

        public void LateUpdate()
        {
            RenderSettings.skybox.SetFloat(Rotation, Time.time * Speed);
        }
    }
}