using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    interface IBussinessLayer<TEntity,TKey> where TEntity :class
    {
        List<TEntity> GetAllBLL();
        TEntity GetBLL(TKey key);
        bool SaveBLL(TEntity item);
        bool UpdateBLL(TEntity item);
        bool DeleteBLL(TEntity item);
    }
}
