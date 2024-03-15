using BooksApi.DAL;
using BooksApi.Model;

namespace BooksApi.BAL
{
    public class BooksType_BALBase
    {
        BookType_DALBase BookType_DALBase = new BookType_DALBase();
        public List<BookType_Model> Getall()
        {
            try
            {
                List<BookType_Model> bookType_Model = BookType_DALBase.Getall();
                return bookType_Model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public BookType_Model SelectRoleByPK(int TypeID)
        {
            try
            {
                BookType_Model bookType_Model = BookType_DALBase.SelectTypeByPk(TypeID);
                return bookType_Model;

            }
            catch (Exception ex)
            {
                return null;

            }
        }
        public bool InsertNewRole(BookType_Model bookType_Model)
        {
            try
            {
                if (BookType_DALBase.InsertBookType(bookType_Model))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateRole( BookType_Model bookType_Model)
        {
            try
            {
                if (BookType_DALBase.UpdateBookType( bookType_Model))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteRole(int TypeID)
        {
            try
            {
                if (BookType_DALBase.DeleteBookType(TypeID))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
