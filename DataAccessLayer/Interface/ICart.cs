using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface ICart<TYPE, ID, RET>
    {
        List<TYPE> GetCart(ID id);
        TYPE Get(ID id);
        RET Add(TYPE obj);
        RET Update(TYPE obj);
        RET Checkout(ID id);
        bool Delete(ID id);
    }
}
