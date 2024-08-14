using STA.Domain.Combat;
using STA.View.Combat;

namespace STA.Presentation.Combat
{
    public class HealthPresenter
    {
        private Health _health;
        private IHealthView _healthView;

        public HealthPresenter(Health health, IHealthView healthView)
        {
            _health = health;
            _healthView = healthView;
        }

    }
}
