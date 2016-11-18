using System.Collections.Generic;

namespace WebApplication9.Models
{
    public interface IPortRepository
    {
        IEnumerable<Trip> GetAllTrips();
        IEnumerable<Trip> GetAllTripsWithStops();
        void AddTrip(Trip newTrip);
        bool SaveAll();
        Category GetCategoryById(int categoryId);
        IEnumerable<Author> GetAuthorList();
        Trip GetTripByName(string tripName);
        void AddStop(string tripName, Stop newStop);
        IEnumerable<Post> GetAllPosts();
        void AddPost(Post newPost);
        void AddCategory(Category newPost);
        void AddAuthor(Author newPost);
        IEnumerable<Category> GetCategories();
    }
}