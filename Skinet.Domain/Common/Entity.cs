﻿namespace Skinet.Domain.Common
{
    public class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; } 
    }
}
