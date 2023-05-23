using Assesment_MVC_EF.Models;

namespace Assesment_MVC_EF
{
    public interface CourseInterface
    {
        List<Course> GetCourses();
        Course Create(Course course);
        int Edit(int id, Course course);
        int Delete(int id);
        Course GetCourseById(int id);
    }
}
