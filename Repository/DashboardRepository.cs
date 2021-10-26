using armcoordination_dashboard.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace armcoordination_dashboard.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly armcoordinationContext _context;
        public DashboardRepository(armcoordinationContext context)
        {
            _context = context;
        }

        public List<session> getSessions(int id)
        {
            int numberOfSession = _context.session.Where(x => x.child_id == id).Count();
            List<session> sessions = new List<session>();

            if (numberOfSession >= 12)
            {
                sessions = _context.session.Where(x => x.child_id == id).OrderByDescending(x => x.date).Take(12).ToList();
            }
            else
            {
                sessions = _context.session.Where(x => x.child_id == id).OrderByDescending(x => x.date).Take(numberOfSession).ToList();
            }
            
            return sessions;
        }


        public int numberOfSession(int id)
        {
            return _context.session.Where(x => x.child_id == id).Count();
        }


        public session lastSession(int _id)
        {
            
            var _session = _context.session.Where(x => x.child_id == _id).OrderByDescending(x => x.id).First();
            return _session;
        }

    }
}
