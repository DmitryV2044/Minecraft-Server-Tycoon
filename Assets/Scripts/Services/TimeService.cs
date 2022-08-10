using System.Collections;
using UnityEngine;
using System;

namespace Services
{ 
    public class TimeService : Singleton<TimeService>
    {
        [SerializeField] private int _timeScale;
        [SerializeField] private int _timeFromStart;
        [SerializeField] private DateTime _globalDatetime;

        public int TimeScale => _timeScale;
        public int TimeFromStart => _timeFromStart;
        public DateTime GlobalTime => _globalDatetime;

        public override void Awake()
        {
            base.Awake();
            _globalDatetime = new DateTime(0, 0, 0, 15, 7, 2022);
            StartCoroutine(TimeCounter());
        }

        IEnumerator TimeCounter()
        {
            while (true)
            {
                yield return new WaitForSeconds(1f);
                _globalDatetime.Seconds += 1;
            }
        }
    }


}
