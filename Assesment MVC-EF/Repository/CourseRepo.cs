using Assesment_MVC_EF.Context;
using Assesment_MVC_EF.Models;

namespace Assesment_MVC_EF.Repository
{
    public class CourseRepo : CourseInterface
    {
        UserDbContext _db;
        public CourseRepo(UserDbContext db)
        {
            _db = db;



        }
        public Course Create(Course course)
        {
            _db.Courses.Add(course);
            _db.SaveChanges();
            return course;
        }



        public int Delete(int id)
        {
            Course obj2 = GetCourseById(id);
            if (obj2 != null)
            {
                _db.Courses.Remove(obj2);
                _db.SaveChanges();
                return 1;
            }
            return 0;
        }



        public int Edit(int id, Course course)
        {
            Course obj = GetCourseById(id);
            if (obj != null)
            {
                foreach (Course temp in _db.Courses)
                {
                    if (temp.CourseId == id)
                    {
                        temp.CourseName = course.CourseName;
                        temp.Duration = course.Duration;
                        temp.Details = course.Details;
                    }
                }
                _db.SaveChanges();
            }
            return 1;
        }



        public Course GetCourseById(int id)
        {
            return _db.Courses.FirstOrDefault(x => x.CourseId == id);
        }



        public List<Course> GetCourses()
        {
            return _db.Courses.ToList();
        }
    }
}

