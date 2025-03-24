using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Model
{
    public class CommonModel
    {
    }
    public class ResponseModel
    {
        public string Error { get; set; }
        public string Msg { get; set; }
        public object data { get; set; }
    }

    public class CommonParmIUD
    {
        public int IntId { get; set; }
        public string Type { get; set; }
    }

    public class GenderModel
    {
        public int IntId { get; set; }
        public string strGender { get; set; }
    }
    public class MenuModel
    {
        public int IntId { get; set; }
        public string title { get; set; }
        public string icon { get; set; }
        public string route { get; set; }
        public int seq { get; set; }
        public int parentMenuId { get; set; }
        public bool subMenu { get; set; }
 
    }
}
