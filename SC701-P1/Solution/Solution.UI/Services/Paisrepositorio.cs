using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.UI.Services
{
    public class Paisrepositorio : IRepositorioPais
    {
        public List<string> ObtenerTodos()
        {
            return new List<string>() { "Ghana", "Japon", "Costa Rica", "Ecuador", "Argentina" };
        }
    }
}
