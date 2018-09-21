﻿using MiniLearningSystem.Models.EntityModels;
using MiniLearningSystem.Models.ViewModels.Course;
using System.Collections.Generic;

namespace MiniLearningSystem.Services.Interfaces
{
    public interface ICourseService
    {
        ICollection<Course> GetAll();

        Course GetById(int id);

        IList<CourseIndexVm> SetApplyedCourses();

        void SetIcons(IList<CourseIndexVm> courses);
    }
}
