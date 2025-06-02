using Domain.Entities.Base;
using Domain.Enums;

namespace Domain.Entities
{
    public class User : Entity<Guid> // Наследуем от Entity<Guid>
    {
        public string Name { get; }
        public int Age { get; }
        public Gender Gender { get; }
        public decimal Weight { get; }
        public decimal Height { get; }
        public ActivityLevel ActivityLevel { get; }

        public User(Guid id, string name, int age, Gender gender,
                  decimal weight, decimal height, ActivityLevel activityLevel)
                  : base(id) // Передаем id в базовый класс
        {
            Name = name;
            Age = age;
            Gender = gender;
            Weight = weight;
            Height = height;
            ActivityLevel = activityLevel;
        }

        // Для EF Core
        protected User() : base(Guid.NewGuid()) { }
    }
}