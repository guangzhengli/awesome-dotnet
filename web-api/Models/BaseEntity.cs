﻿namespace Awesome_dotnet.Models
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
            : this(Guid.NewGuid())
        {
        }

        BaseEntity(Guid id)
        {
            Id = id;
        }

        public virtual Guid Id { get; protected set; }
    }
}