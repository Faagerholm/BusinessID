using System;
using System.Collections.Generic;
using System.Text;

namespace Specifications
{
    public interface ISpecification<in TEntity>
    {
        IEnumerable<string> ReasonsForDissatisfaction { get; }
        bool IsSatisfiedBy(TEntity entity);
    }
}
