using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication9.Models
{
    public class PortRepository : IPortRepository
    {
        private PortContext _context;
        private ILogger<PortRepository> _logging;

        public PortRepository(PortContext context, ILogger<PortRepository> logger)
        {
            _context = context;
            _logging = logger;
        }

        public void AddStop(string tripName,Stop newStop)
        {
            var trip = this.GetTripByName(tripName);
            newStop.Order = trip.Stops.Max(s => s.Order) + 1;
            _context.Stops.Add(newStop);
        }

        public void AddTrip(Trip newTrip)
        {
            _context.Add(newTrip);
        }

        public IEnumerable<Trip> GetAllTrips()
        {
            try
            {
                return _context.Trips.OrderBy(a => a.Name).ToList();
            }
            catch (Exception ex)
            {
                _logging.LogError("Could Not get trips", ex);
                return null;
            }
            
        }
        public IEnumerable<Category> GetCategories()
        {
            try
            {
                return _context.Categories.Include(t => t.Posts).OrderBy(a=>a.CategoryName).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<Trip> GetAllTripsWithStops()
        {
            try
            {
                return _context.Trips.Include(t => t.Stops).OrderBy(t=>t.Name).ToList();
            }
            catch (Exception ex)
            {
                _logging.LogError("Could Not get trips", ex);
                return null;
            }
        }

        public Category GetCategoryById(int categoryId)
        {
            return _context.Categories.Include(a=>a.Posts).Where(a => a.ID == categoryId).FirstOrDefault();
        }

        // Get list of categories
        public IEnumerable<Category> GetAuthorList()
        {
            return _context.Categories.OrderBy(a => a.CategoryName).ToList();
        }

        public Trip GetTripByName(string tripName)
        {
            return _context.Trips.Include(t => t.Stops).Where(t=>t.Name == tripName).OrderBy(t => t.Name).FirstOrDefault();
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }

        //Post Module
        public IEnumerable<Post> GetAllPosts()
        {
            return _context.Posts.OrderByDescending(t => t.CreatedDate).ToList();
        }

        public void AddPost(Post newPost)
        {
            try
            {

                _context.Add(newPost);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void AddCategory(Category newPost)
        {
            _context.Add(newPost);
        }

        public void AddAuthor(Author newPost)
        {
            _context.Add(newPost);
        }

        IEnumerable<Author> IPortRepository.GetAuthorList()
        {
            return _context.Authors.OrderBy(t => t.LastName).ToList();
        }
    }
}
