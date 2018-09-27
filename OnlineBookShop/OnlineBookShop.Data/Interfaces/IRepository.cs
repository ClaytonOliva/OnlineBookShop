using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBookShop.Data.Interfaces
{
    public interface IRepository
    {
        IDbConnection Connection { get; set; }
    }
}
