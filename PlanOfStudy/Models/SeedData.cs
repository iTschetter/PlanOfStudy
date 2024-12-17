using Microsoft.EntityFrameworkCore;
namespace PlanOfStudy.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            POSDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<POSDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Courses.Any())
            {
                context.Courses.AddRange(
                    new Course
                    {
                        CourseNumber = "Gen Req",
                        Description = "System-wide Gen Ed Requirements",
                        Credits = 30,
                        Category = "Gen"
                    },
                    new Course
                    {
                        CourseNumber = "Inst Req",
                        Description = "Institutional Gen Ed Requirements",
                        Credits = 11,
                        Category = "Inst"
                    },
                    new Course
                    {
                        CourseNumber = "ACCT 210",
                        Description = "Principles of Accounting",
                        Credits = 3,
                        Category = "ACCT"
                    },
                    new Course
                    {
                        CourseNumber = "BADM 220",
                        Description = "Business Statistics",
                        Credits = 3,
                        Category = "BADM"
                    },
                    new Course
                    {
                        CourseNumber = "BADM 344",
                        Description = "Managerial Communications",
                        Credits = 3,
                        Category = "BADM"
                    },
                    new Course
                    {
                        CourseNumber = "BADM 350",
                        Description = "Legal Environment of Business",
                        Credits = 3,
                        Category = "BADM"
                    },
                    new Course
                    {
                        CourseNumber = "BADM 360",
                        Description = "Organization and Management",
                        Credits = 3,
                        Category = "BADM"
                    },
                    new Course
                    {
                        CourseNumber = "BADM 370",
                        Description = "Marketing",
                        Credits = 3,
                        Category = "BADM"
                    },
                    new Course
                    {
                        CourseNumber = "CIS 351",
                        Description = "Business Applications Programming",
                        Credits = 3,
                        Category="CIS"
                    },
                    new Course
                    {
                        CourseNumber = "CIS 325",
                        Description = "Management Information Systms",
                        Credits = 3,
                        Category = "CIS"
                    },
                    new Course
                    {
                        CourseNumber = "CIS 332",
                        Description = "Structured Systems Analysis and Design",
                        Credits = 3,
                        Category = "CIS"
                    },
                    new Course
                    {
                        CourseNumber = "CIS 338",
                        Description = "Project Management",
                        Credits = 3,
                        Category = "CIS"
                    },
                    new Course
                    {
                        CourseNumber = "CIS 427",
                        Description = "Information Systems Planning and Management",
                        Credits = 3,
                        Category = "CIS"
                    },
                    new Course
                    {
                        CourseNumber = "CIS 484",
                        Description = "Database Management Systms",
                        Credits = 3,
                        Category = "CIS"
                    },
                    new Course
                    {
                        CourseNumber = "Experience",
                        Description = "Internship or Research",
                        Credits = 3,
                        Category = "Experience"
                    },
                    new Course
                    {
                        CourseNumber = "CSC 363",
                        Description = "Hardware, Virtualization, and Data Communications",
                        Credits = 3,
                        Category = "CSC"
                    },
                    new Course
                    {
                        CourseNumber = "CSC 245",
                        Description = "Information Security FUndamentals",
                        Credits = 3,
                        Category = "CSC"
                    },
                    new Course
                    {
                        CourseNumber = "CIS 275",
                        Description = "Web Application Programming",
                        Credits = 3,
                        Category = "CIS"
                    },
                    new Course
                    {
                        CourseNumber = "CIS 361",
                        Description = "Advanced Programming for Business Apps",
                        Credits = 3,
                        Category = "CIS"
                    },
                    new Course
                    {
                        CourseNumber = "CIS 375",
                        Description = "Web Application Programming II",
                        Credits = 3,
                        Category = "CIS"
                    },
                    new Course
                    {
                        CourseNumber = "CIS 424",
                        Description = "Software Development with Agile Methodologies",
                        Credits = 3,
                        Category = "CIS"
                    },
                    new Course
                    {
                        CourseNumber = "CIS 487",
                        Description = "Database Programming",
                        Credits = 3,
                        Category = "CIS"
                    },
                    new Course
                    {
                        CourseNumber = "MATH 201",
                        Description = "Introduction to Discrete Mathematics",
                        Credits = 3,
                        Category = "Math"
                    },
                    new Course
                    {
                        CourseNumber = "Electives",
                        Description = "Electives",
                        Credits = 16,
                        Category = "Electives"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}