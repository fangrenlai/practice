using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Practice.Model.Common
{
    public class PaginationModel
    {
        public PaginationModel(int _page, int _rows, string _sort, string _order)
        {
            this.page = _page;
            this.rows = _rows;
            this.sort = _sort;
            this.order = _order;
        }
        // page=1&rows=10&sort=UserName&order=desc
        private int page;

        public int Page
        {
            get { return page; }
            set { page = value; }
        }

        private int rows;

        public int Rows
        {
            get { return rows; }
            set { rows = value; }
        }

        private string sort;

        public string Sort
        {
            get { return sort; }
            set { sort = value; }
        }

        private string order;

        public string Order
        {
            get { return order; }
            set { order = value; }
        }
    }
}
