using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_QLBQA.Services.BaseService
{
    public interface IBaseService<T> where T  : class, new()
    {
        T GetByID(int Id);
        DbSet<T> GetAll();
        T Insert(T entity);
        T Update(T entity);
        bool Delete(int Id);
        List<D> GetListDataSource<D>(string filter = "") where D : class;
        void loadData<D>(DataGridView d) where D : class;
        void loadComboBox(ComboBox b,string valueName = "Name");
    }
}
