using UnityEngine;

namespace Affectors
{
    [CreateAssetMenu(fileName = "New Computer Config", menuName = "Config/Computer")]
    public class ComputerConfig : AffectorConfig<Computer>, ICanAffectMoney
    {
        [SerializeField, Range(0, 1000)] private int _affectingMoneyAmount;

        public int AffectingMoneyAmount => _affectingMoneyAmount;
    }

}

