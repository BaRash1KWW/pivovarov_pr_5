using System.Collections.Generic;
using System.Linq;
using pr_5.models; 

namespace pr_5 
{
    public class Helper
    {
  
        private static Entities _context;

        /// <summary>
        /// Метод для получения контекста данных.
        /// </summary>
        public static Entities GetContext()
        {
            if (_context == null)
            {
                _context = new Entities(); 
            }
            return _context;
        }


        public void CreateUser(Users user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void RemoveUser(int idUser)
        {
            var user = _context.Users.Find(idUser);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
        public List<Users> FiltrUsers(string startLetter)
        {
            return _context.Users.Where(x => x.Login.StartsWith(startLetter)).ToList();
        }
    }
}