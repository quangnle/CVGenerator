using CVGenerator.Entities;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVGenerator.Models
{
    public class Reference : TReference, IConvertibleModel<TReference>
    {
        private TReference _entity;

        public void Bind(TReference entity)
        {
           
        }

        public TReference GetEntity()
        {
            _entity = new TReference();
            Update(_entity);
            return _entity;
        }
        
        public void Update(TReference entity)
        {
            entity.InjectFrom(this);
        }
    }
}