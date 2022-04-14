using System;

namespace FB.NewOrders.Domain.Models
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}