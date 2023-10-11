using UnityEngine;

namespace DefaultNamespace
{
    public class Bonus : Collidable
    {
        public BonusType bonusType;
        
        public enum BonusType
        {
            None,
            AddTime,
            AddShield,
            AddInvisible
        }
        
        protected override void OnCollide()
        {
            switch (bonusType)
            {
                case BonusType.AddTime:
                {
                    manager.AdjustTime(value);
                    break;
                }
                
                case BonusType.AddShield:
                {
                    manager.SetShieldActive(true);
                    break;
                }
                
                case BonusType.AddInvisible:
                {
                    manager.SetInvisible();
                    break;
                }
            }
            base.OnCollide();
        }
    }
}