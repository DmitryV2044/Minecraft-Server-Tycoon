using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Services
{
    public class UpdateService : MonoBehaviour
    {
        public static event Action OnUpdate;
        public static event Action OnFixedUpdate;

        private void Update() => OnUpdate?.Invoke();

        private void FixedUpdate() => OnFixedUpdate?.Invoke();

    }

}
