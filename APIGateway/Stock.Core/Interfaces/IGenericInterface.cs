using Stock.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock.Core.Interfaces
{
    public interface IGenericInterface<T>
    {
        #region Base CRUD
        T GetById(Guid id);
        BaseResponse AddProduct(T Data);
        BaseResponse UpdateData(T Data);
        BaseResponse DeleteProduct(Guid id);
        BaseResponse<List<T>> Get(int page, int size, string search);
        #endregion
        #region List Side
        BaseResponse RemoveList(List<Guid> dataIds);
        BaseResponse UpdateList(List<T> dataList);
        #endregion
    }
}
