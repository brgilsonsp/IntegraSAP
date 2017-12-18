using System.Collections.Generic;

namespace BL.ObjectMessages
{
    public interface DatasOfRequest<T>
    {
        IList<T> GetListObjectForRequest();
    }
}
