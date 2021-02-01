using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface IEntity
    {
        bool Delete(string name);

        bool Update();

        DataSet GetAll();

        DataSet Search(string name);

        DataTable GetAllWithOneColumn(string colName);

        bool Add();
    }
}
