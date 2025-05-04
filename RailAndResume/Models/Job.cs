using System.Xml.Linq;

namespace RailAndResume.Models
{
    public class Job
    {
        private string m_jobName;
        private string m_jobLocation;
        private string m_jobLink;


        public string jobName {
            get { return m_jobName; }   
            set { m_jobName = value; } 
        }
        public string jobLocation
        {
            get { return m_jobLocation; }
            set { m_jobLocation = value; }
        }
        public string jobLink
        {
            get { return m_jobLink; }
            set { m_jobLink = value; }
        }

        public Job(string jobName, string jobLocation, string jobLink){

            m_jobName       = jobName;
            m_jobLocation   = jobLocation;
            m_jobLink       = jobLink;
        }
    }
}
