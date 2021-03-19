using dio_signup_app.Entities;
using dio_signup_app.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace dio_signup_app.Repositories
{
    class SeriesRepository : IRepository<Series>
    {
        private List<Series> _series = new List<Series>();

        public void Create(Series entity)
        {
            _series.Add(entity);
        }

        public void Delete(int id)
        {
            var inst = _series.Find(s => s.Id == id);
            _series.Remove(inst);
        }

        public Series FindById(int id)
        {
            var index = _series.FindIndex(s => s.Id == id);
            if(index != -1)
            {
                return _series[index];
            }
            return null;            
        }

        public List<Series> ListItem()
        {
            return _series;
        }

        public int NextId()
        {
            return _series.Count;
        }

        public void Update(int id, Series entity)
        {
            var index = _series.FindIndex(s => s.Id == id);
            if (index != -1)
            {
                _series[index] = entity;
            }                        
        }
    }
}
