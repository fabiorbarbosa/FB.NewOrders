using System;

namespace FB.NewOrders.Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateChange { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}