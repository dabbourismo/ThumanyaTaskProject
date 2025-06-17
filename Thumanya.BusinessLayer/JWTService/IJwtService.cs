using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thumanya.DataAccessLayer.DatabaseEntities;

namespace Thumanya.BusinessLayer.JWTService
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }

}
