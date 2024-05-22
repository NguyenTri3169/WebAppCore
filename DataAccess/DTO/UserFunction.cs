using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class UserFunction
    {
        public int UserFunctionID { get; set; }
        public int UserId { get; set; }
        public int FunctionID { get; set; }
        public int IsView { get; set; }
        public int IsInsert { get; set; }
        public int Isupdate { get; set; }
        public int IsDelete { get; set; }
    }
}
