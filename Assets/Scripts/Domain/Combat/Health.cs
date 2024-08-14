using System;

namespace STA.Domain.Combat
{
    public class Health
    {
        public event Action<float> OnDamaged;
        public event Action<float> OnHealed;
        public bool IsDead { get; private set; }
        public float Value { get; private set; }
        public float MaxValue { get; }

        public Health(float maxValue)
        {
            IsDead = false;
            Value = maxValue;
            MaxValue = maxValue;
        }

        public void Die()
        {
            IsDead = true;
            Damage(MaxValue);
        }

        public void Revive()
        {
            IsDead = false;
            Heal(MaxValue);
        }

        private void Heal(float value)
        {
            Value += value;
            OnHealed?.Invoke(Value);
        }

        public void TryHeal(float value)
        {
            if (IsDead == true)
                return;

            if (Value + value > MaxValue)
            {
                Value = MaxValue;
                return;
            }

            Heal(value);

            OnHealed?.Invoke(Value);
        }

        private void Damage(float damage)
        {
            Value -= damage;
            OnDamaged?.Invoke(Value);
        }

        public void TryDamage(float damage)
        {
            if (IsDead == true)
                return;

            if (Value - damage <= damage)
            {
                Die();
                return;
            }

            Damage(damage);
        }
    }
}