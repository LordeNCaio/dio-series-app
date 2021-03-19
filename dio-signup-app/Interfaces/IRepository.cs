using System;
using System.Collections.Generic;
using System.Text;

namespace dio_signup_app.Interfaces
{
    interface IRepository<T>
    {
        List<T> ListItem();
        T FindById(int id);
        int NextId();

        void Create(T entity);
        void Update(int id, T entity);
        void Delete(int id);

    }
}
