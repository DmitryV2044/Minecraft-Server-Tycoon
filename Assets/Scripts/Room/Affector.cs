using UnityEngine;
using Services;

namespace Room
{
    public abstract class Affector<T> : MonoBehaviour
    {
        protected AffectorConfig<T> config;
        protected int level;

        private void Start() => TimeService.Instance.GlobalTime.OnHourChanged += Affect;

        public abstract void Affect();
    }

}
