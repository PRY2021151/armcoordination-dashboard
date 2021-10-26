using armcoordination_dashboard.Data;
using armcoordination_dashboard.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace armcoordination_dashboard.Repository
{
    public class HomeRepository : IHomeRepository
    {

        private readonly armcoordinationContext _context;
        public HomeRepository(armcoordinationContext context)
        {
            _context = context;
        }

        public int addNewChild(ChildModel child, string user_email) {
            var newChild = new children()
            {
                names = child.names,
                last_name = child.last_name,
                date_of_birth = child.date_of_birth,
                gender = child.gender,
                relationship = user_email,
                is_deleted = false,
                AspNetUsers_Id = "73e241ed-03e5-4ac2-81cb-f26d945bce57"
            };

            _context.child.Add(newChild);
            _context.SaveChanges();

            return newChild.id;
        }

        public void deleteInfoChild(int id)
        {
            children children = _context.child.Where(x => x.id == id).FirstOrDefault();
            children.is_deleted = true;
            _context.Entry(children).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void updateInfoChild(ChildModel _children) {
            children children = _context.child.Where(x => x.id == _children.id).FirstOrDefault();
            children.date_of_birth = _children.date_of_birth;
            children.names = _children.names;
            children.last_name = _children.last_name;
            children.gender = _children.gender;
            _context.Entry(children).State = EntityState.Modified;
            _context.SaveChanges();

        }

        public children getInfoChild(int id) {
            return _context.child.Where(x => x.id == id).FirstOrDefault();
        }

        public async Task<List<children>> getChildren(string user_email)
        {
            var chidren = new List<children>();
            var allChidren = await _context.child.Where(x => x.relationship == user_email && x.is_deleted != true).ToListAsync();
            if (allChidren?.Any() == true)
            {
                foreach (var child in allChidren)
                {
                    chidren.Add(new children() {
                        id = child.id,
                        names = child.names,
                        last_name = child.last_name,
                        date_of_birth = child.date_of_birth,
                        gender = child.gender,
                        relationship = child.relationship,
                        is_deleted = child.is_deleted,
                        AspNetUsers_Id = child.AspNetUsers_Id
                    });
                }
            }

            return chidren;
        }
    }
}
