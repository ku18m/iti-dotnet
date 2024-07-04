using Microsoft.Data.SqlClient;

namespace Courses_Manipulation
{
    public partial class Courses : Form
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-C2CGBOT\\SQLEXPRESS;Database=ITI;Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=True");
        public Courses()
        {
            InitializeComponent();
        }

        private void Courses_Load(object sender, EventArgs e)
        {
            GetCourses();
        }
    }
}
