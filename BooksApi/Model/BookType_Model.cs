using System.Globalization;

namespace BooksApi.Model
{
    public class BookType_Model
    {
        public int TypeID { get; set; }
        public string TypeName { get; set; }
        public DateTime Created { get; set; }
        public DateTime modified { get; set; }
    }
}
