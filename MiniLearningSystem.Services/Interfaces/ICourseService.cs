﻿using MiniLearningSystem.Models.EntityModels;
using MiniLearningSystem.Models.ViewModels.Course;
using System.Collections.Generic;

namespace MiniLearningSystem.Services.Interfaces
{
    public interface ICourseService
    {
        ICollection<Course> GetAll();

        Course GetById(int id);

        CourseDetailsVm GetDetailedById(int id);

        bool Create(CreateCourseVm model);

        bool IsCourseApplied(int id);

        IList<CourseIndexVm> SetApplyedCourses();

        void SetIcons(IList<CourseIndexVm> courses);

        (bool success, string courseName) AddStudent(int courseId);

        (bool success, string courseName) RemoveStudent(int courseId);
    }
}
