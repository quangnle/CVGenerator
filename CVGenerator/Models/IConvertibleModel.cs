using CVGenerator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVGenerator.Models
{
    public interface IConvertibleModel<T> where T : IEntity
    {
        int Id { get; set; }
        void Update(T entity);
        T GetEntity();
    }
}