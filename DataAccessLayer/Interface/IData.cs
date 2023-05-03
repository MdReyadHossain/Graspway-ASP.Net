using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface IData<TYPE, ID, RET>
    {
        List<TYPE> Get();
        RET Add(TYPE obj);
        RET Update(TYPE obj);
        bool Delete(ID id);
    }
}
