using BooksApi.DAL;
using BooksApi.Model;

namespace BooksApi.BAL
{
    public class Author_BALBase
    {
        Author_DALBase author_DALBase = new Author_DALBase ();
        public List<Author_Model> Getall()
        {
            try
            {
                List<Author_Model> author_Models = author_DALBase.Getall();
                return author_Models;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<AuthorComboBox> AuthorComboBox()
        {
            try
            {
                List<AuthorComboBox> authorComboBox = author_DALBase.AuthorComboBox();
                return authorComboBox;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public Author_Model SelectAuthorByPK(int AuthorID)
        {
            try
            {
                Author_Model author_Model = author_DALBase.SelectAuthorByPk(AuthorID);
                return author_Model;
            }
            catch (Exception ex)
            {
                return null;

            }
        }
        public bool InsertAuthor(Author_Model author_Model)
        {
            try
            {
                if (author_DALBase.InsertAuthor(author_Model))
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

        public bool UpdateAuthor(Author_Model author_Model)
        {
            try
            {
                if (author_DALBase.UpdateAuthor(author_Model))
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

        public bool DeleteAuthor(int AuthorID)
        {
            try
            {
                if (author_DALBase.DeleteAuthor(AuthorID))
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
