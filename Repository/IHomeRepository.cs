using armcoordination_dashboard.Data;
using armcoordination_dashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace armcoordination_dashboard.Repository
{
    public interface IHomeRepository
    {
        Task<List<children>> getChildren(string user_email);
        int addNewChild(ChildModel child, string user_email);
        void deleteInfoChild(int id);
        children getInfoChild(int id);
        void updateInfoChild(ChildModel _children);
    }
}
