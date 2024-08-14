
namespace STA.Domain.Combat
{
    public class Health
    {
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
            Value = 0;
        }

        public void Revive()
        {
            IsDead = false;
            Value = MaxValue;
        }

        private void Add(float value)
        {
            Value += value;
        }

        public void TryAdd(float value)
        {
            if (IsDead == true)
                return;

            if (Value + value > MaxValue)
            {
                Value = MaxValue;
                return;
            }

            Add(value);

        }

        private void Substract(float damage)
        {
            Value -= damage;
        }

        public void TrySubstract(float damage)
        {
            if (IsDead == true)
                return;

            if (Value - damage <= damage)
            {
                Die();
                return;
            }

            Substract(damage);
        }
    }
}