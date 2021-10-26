using armcoordination_dashboard.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace armcoordination_dashboard.Repository
{
    public interface IDashboardRepository
    {
        List<session> getSessions(int id);
        session lastSession(int _id);
        int numberOfSession(int id);
        
    }
}
