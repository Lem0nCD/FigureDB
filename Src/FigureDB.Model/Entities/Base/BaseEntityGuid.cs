using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.Model.Entities.Base
{
    public class BaseEntityGuid : BaseEntity<Guid>
    {
        public BaseEntityGuid()
        {
            Id = Guid.NewGuid();
        }
    }
}
