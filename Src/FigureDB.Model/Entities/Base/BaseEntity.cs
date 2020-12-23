using System;

namespace FigureDB.Model.Entities.Base
{
    public abstract class BaseEntity<T> where T : struct
    {
        public T Id { get; set; }
        public bool IsRemove { get; set; } = false;
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public DateTime? ModifyTime { get; set; }
    }
}
