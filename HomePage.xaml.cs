using System;
using System.Collections.Generic;

using Xamarin.Forms;
using SchoolCreditSystem.Classes;
using System.Net.Http;
using Newtonsoft.Json;
using System.Linq;
using static SchoolCreditSystem.Classes.Student;

namespace SchoolCreditSystem
{
    public partial class HomePage : ContentPage
    {
        public static int totalCredits = 0;
        public static int totalCreditsSpent = 0;

        public static string studentMailingAddress;

        static string schoolID;
        static string studentID;
        static int daysEnrolled = 0;
        static int daysPresent = 0;
        static int daysAbsence = 0;
        static int daysExcused = 0;
        static int daysUnexcused = 0;
        static int daysTardy = 0;
        static int daysTruancy = 0;
        static int daysSuspension = 0;
        static string schoolYear;
        static string schoolName;
        public static string firstName;
        public static string lastName;
        static string grade;
        static double gpaUnweighted;
        static double gpaWeighted;
        static double classRank;
        static double attemptedClassCredits;
        static double completedClassCredits;

        

        public HomePage(string _schoolID, string _studentID)
        {
            InitializeComponent();

            schoolID = _schoolID;
            studentID = _studentID;

            GetSchoolInformation();
            GetStudentData();
            GetStudentAttendanceHistory();
            GetGradeData();


            //Reset credits
            totalCredits = 0;


            CalculateCredits();

            totalCredits -= totalCreditsSpent;

            SetLabelValues();


        }
        public HomePage(string _schoolID, string _studentID, string notFirstTime)
        {
            InitializeComponent();

            schoolID = _schoolID;
            studentID = _studentID;

            SetLabelValues();


        }


        public void SetLabelValues()
        {
            //Upper UI Labels
            StudentNameLabel.Text = firstName + " " + lastName;
            ClassRankLabel.Text = classRank.ToString();
            CurrentCreditsLabel.Text = totalCredits.ToString();

            //Grid Labels

            GPAUWLabel.Text = gpaUnweighted.ToString();
            GPAWLabel.Text = gpaWeighted.ToString();
            CreditScoreLabel.Text = completedClassCredits + "/" + attemptedClassCredits;
            DaysPresentedLabel.Text = daysPresent.ToString();
            DaysUnexcusedLabel.Text = daysUnexcused.ToString();
            DaysAbsentLabel.Text = daysAbsence.ToString();
            DaysTardyLabel.Text = daysTardy.ToString();
            DaysSuspendedLabel.Text = daysSuspension.ToString();
        }

        private static HttpClient client = new HttpClient();

        public void GetSchoolInformation()
        {
            using (client)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri(@"https://demo.aeries.net/aeries");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("AERIES-CERT", "477abe9e7d27439681d62f4e0de1f5e1");

                var response = client.GetAsync("https://demo.aeries.net/aeries/api/v3/schools/" + schoolID).Result;
                string resultSchools = response.Content.ReadAsStringAsync().Result;
                School[] schoolData = JsonConvert.DeserializeObject<School[]>(resultSchools);
                foreach (var item in schoolData.ToList())
                {
                    schoolName = item.Name;
                }


            }
        }

        public void GetStudentData()
        {


            var response2 = client.GetAsync("https://demo.aeries.net/aeries/api/v3/schools/" + schoolID + "/students/" + studentID).Result;
            string resultStudents = response2.Content.ReadAsStringAsync().Result;
            Student[] studentData = JsonConvert.DeserializeObject<Student[]>(resultStudents);
            foreach (var item in studentData.ToList())
            {
                
                firstName = item.FirstName;
                lastName = item.LastName;
                grade = item.Grade;
                studentMailingAddress = item.MailingAddress;
            }

        }

        public void GetStudentAttendanceHistory()
        {


            var response3 = client.GetAsync("https://demo.aeries.net/aeries/api/v3/schools/" + schoolID + "/AttendanceHistory/summary/" + studentID).Result;
            string resultStudentAttendance = response3.Content.ReadAsStringAsync().Result;
            AttendanceHistorySummary[] attendanceData = JsonConvert.DeserializeObject<AttendanceHistorySummary[]>(resultStudentAttendance);
            foreach (var item in attendanceData.ToList())
            {
                
                schoolYear = item.HistorySummaries[0].SchoolYear;
                daysAbsence = item.HistorySummaries[0].DaysAbsence;
                daysPresent = item.HistorySummaries[0].DaysPresent;
                daysSuspension = item.HistorySummaries[0].DaysSuspension;
                daysUnexcused = item.HistorySummaries[0].DaysUnexcused;
                daysTardy = item.HistorySummaries[0].DaysTardy;
            }
        }

        public void GetGradeData()
        {


            var response4 = client.GetAsync("https://demo.aeries.net/aeries/api/v3/schools/" + schoolID + "/gpas/" + studentID).Result;
            string resultStudentGrades = response4.Content.ReadAsStringAsync().Result;
            StudentGrade[] gradesData = JsonConvert.DeserializeObject<StudentGrade[]>(resultStudentGrades);
            foreach (var item in gradesData.ToList())
            {
                
                gpaUnweighted = item.GPA_GradeReportingAcademicNonWeighted;
                gpaWeighted = item.GPA_GradeReportingAcademic;
                classRank = item.GradeReportingClassRank;
                attemptedClassCredits = item.GradeReportingCreditsAttempted;
                completedClassCredits = item.GradeReportingCreditsCompleted;
            }
        }

        public void CalculateCredits()
        {
            CalculateAttendanceCredits();

            CalculateUnweightedGPACredits();

            CalculateWeightedGPACredits();
        }

        public void CalculateAttendanceCredits()
        {

            totalCredits += daysPresent * 2;
            

            totalCredits -= daysUnexcused * 4;
            totalCredits -= daysSuspension * 10;
            totalCredits -= daysTruancy * 6;

           

        }

        public void CalculateUnweightedGPACredits()
        {
            if (gpaUnweighted >= 3.7)
            {
                totalCredits += 100;
            }
            else if (gpaUnweighted > 3.3)
            {
                totalCredits += 80;
            }
            else if (gpaUnweighted > 3.0)
            {
                totalCredits += 70;
            }
            else if (gpaUnweighted > 2.7)
            {
                totalCredits += 60;
            }
            else if (gpaUnweighted > 2.3)
            {
                totalCredits += 50;
            }
            else if (gpaUnweighted > 2.0)
            {
                totalCredits += 45;
            }
            else
            {
                totalCredits += 40;
            }

        }
        public void CalculateWeightedGPACredits()
        {

            if (gpaWeighted >= 4.8)
            {
                totalCredits += 500;
            }
            else if (gpaWeighted > 4.5)
            {
                totalCredits += 430;
            }
            else if (gpaWeighted > 4.0)
            {
                totalCredits += 300;
            }
            else if (gpaWeighted > 3.8)
            {
                totalCredits += 280;
            }
            else if (gpaWeighted > 3.5)
            {
                totalCredits += 200;
            }
            else if (gpaWeighted > 2.6)
            {
                totalCredits += 170;
            }
            else if (gpaWeighted > 2.0)
            {
                totalCredits += 100;
            }
            else
            {
                totalCredits += 40;
            }

        }

    }
}
