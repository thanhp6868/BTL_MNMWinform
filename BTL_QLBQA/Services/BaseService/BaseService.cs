using BTL_QLBQA.Components;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_QLBQA.Services.BaseService
{
    public class BaseService<T> : IBaseService<T> where T : class, new() 
    {
        protected readonly BTL_QLBQA.DataAccess.QLBQA_dbContext dbContext;
        public BaseService()
        {
            dbContext = new DataAccess.QLBQA_dbContext();
        }
        public BaseService(DataAccess.QLBQA_dbContext db)
        {
            dbContext = db;
        }
        public bool Delete(int Id)
        {
            DialogResult res = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                var entity = dbContext.Set<T>().Find(Id);
                dbContext.Set<T>().Remove(entity);
                dbContext.SaveChanges();
                return true;
            }
            else 
            {                 
                return false;
                       
            }
        }

        public DbSet<T> GetAll()
        {
            return dbContext.Set<T>();
        }

        public T GetByID(int Id)
        {
            return dbContext.Set<T>().Find(Id);
        }

        public List<D> GetListDataSource<D>(string filter = "") where D : class
        {
            return GetAll().ToList<T>().Select(T => Program.mapper.Map<D>(T)).ToList();
        }

        public T Insert(T entity)
        {
            dbContext.Set<T>().Add(entity);
            dbContext.SaveChanges();
            return entity;
        }

        public void loadComboBox(ComboBox b, string valueName = "Name")
        {
            try
            {
                formHelper.comboBoxLoad<T>(b, GetAll().ToList(), "Id", valueName);
            }
            catch
            {
                MessageBox.Show("Khởi tạo ComboBox " + b.Name + "thất bại");
            }
        }

        public void loadData<D>(DataGridView d) where D : class
        {
            formHelper.loadDatagridView<D>(d, GetListDataSource<D>());
        }

        public T Update(T entity)
        {
            dbContext.Set<T>().AddOrUpdate(entity);
            dbContext.SaveChanges();
            return entity;
        }

    }
}
