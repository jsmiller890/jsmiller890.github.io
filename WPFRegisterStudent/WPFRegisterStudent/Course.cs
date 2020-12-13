using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFRegisterStudent
{
    class Course
    {
        private string name = "";
        private string courseId = "";
        private string courseDesc = "";
        private string prereqs = "";
        private int creditHours = 0;
        private int classSize = 0;
        private int studentsRegistered = 0;
        private bool isRegisteredAlready = false;

        public Course(string courseId, string name, string courseDesc, string prereqs, int creditHours, int classSize, int studentsRegistered)
        {
            this.name = name;
            this.courseId = courseId;
            this.courseDesc = courseDesc;
            this.prereqs = prereqs;
            this.creditHours = creditHours;
            this.classSize = classSize;
            this.studentsRegistered = studentsRegistered;
        }

        public void setCourseId(string courseId)
        {
            this.courseId = courseId;
        }

        public string getCourseId()
        {
            return courseId;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public string getName()
        {
            return name;
        }

        public void setCourseDesc(string courseDesc)
        {
            this.courseDesc = courseDesc;
        }

        public string getCourseDesc()
        {
            return courseDesc;
        }

        public void setCreditHours(int creditHours)
        {
            this.creditHours = creditHours;
        }

        public int getCreditHours()
        {
            return creditHours;
        }
        
        public void setPrereqs(string prereqs)
        {
            this.prereqs = prereqs;
        }

        public string getPrereqs()
        {
            return prereqs;
        }

        public void setClassSize(int classSize)
        {
            this.classSize = classSize;
        }

        public int getClassSize()
        {
            return classSize;
        }

        public void setStudentsRegistered(int studentsRegistered)
        {
            this.studentsRegistered = studentsRegistered;
        }

        public int getStudentsRegistered()
        {
            return studentsRegistered;
        }

        public bool IsRegisteredAlready()
        {
            return isRegisteredAlready;
        }

        public void SetToRegistered()
        {
            isRegisteredAlready = true;
        }

        public override string ToString()
        {
            return getName();
        }
    }
}
