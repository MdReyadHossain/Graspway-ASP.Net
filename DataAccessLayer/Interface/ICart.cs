using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    interface ICart<TYPE, ID, RET>
    {
        List<TYPE> GetCart(ID id);
        TYPE Get(ID id);
        RET Add(TYPE obj);
        RET Update(TYPE obj);
        bool Delete(ID id);
    }
}
