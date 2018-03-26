using System.Collections.Generic;

namespace Spartacus.Common
{
    public interface IConstraint
    {
        bool Verify(IList<Variable> variables);
    }
}