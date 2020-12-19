using System;

namespace FigureDB.Model.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool IsRemove { get; set; } = false;
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public DateTime? ModifyTime { get; set; }
    }
}
