using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public class Bookmark
    { 
        public string Title { get; set; }
        public Uri Uri { get; set; }

        /// <summary>
        /// Represents Icon for bookmark in Base64 String
        /// </summary>
        public string Icon { get; set; }
        public DateTime AddedDate { get; set; }
    }
}
