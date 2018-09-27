using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineBookShop.Data.Interfaces;

namespace OnlineBookShop.Data.Repos
{
    public class BaseRepository : IRepository
    {
        public IDbConnection Connection { get; set; }
    }
}
