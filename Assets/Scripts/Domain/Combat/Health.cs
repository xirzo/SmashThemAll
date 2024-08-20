using System;
using UnityEngine;

namespace STA.Domain.Combat
{
    public class Health : MonoBehaviour
    {
        public event Action<float> OnDamaged;
        public event Action<float> OnHealed;
        public bool IsDead { get; private set; }
        public float Value => _value;
        public float MaxValue => _maxValue;
        [SerializeField, Range(0, 100)] private float _value = 100f;
        [SerializeField, Range(0, 100)] private float _maxValue = 100f;

        public void Awake()
        {
            IsDead = false;
        }

        public void Die()
        {
            IsDead = true;
            Damage(_maxValue);
        }

        public void Revive()
        {
            IsDead = false;
            Heal(_maxValue);
        }

        private void Heal(float value)
        {
            _value += value;
            OnHealed?.Invoke(_value);
        }

        public void TryHeal(float value)
        {
            if (IsDead == true)
                return;

            if (_value + value > _maxValue)
            {
                _value = _maxValue;
                return;
            }

            Heal(value);

            OnHealed?.Invoke(_value);
        }

        private void Damage(float damage)
        {
            _value -= damage;
            OnDamaged?.Invoke(_value);
        }

        public void TryDamage(float damage)
        {
            if (IsDead == true)
                return;

            if (_value - damage <= damage)
            {
                Die();
                return;
            }

            Damage(damage);
        }
    }
}