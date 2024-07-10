namespace Disconnected_Mode.models
{
    public class Course
    {
        public int crs_Id { get; set; }
        public string crs_Name { get; set; }
        public int crs_Duration { get; set; }
        public int crs_TopicId { get; set; }
        public string crs_TopicName { get; set; }


        public Course()
        {

        }

        public override string ToString()
        {
            return $"{crs_Id}, {crs_Name}, {crs_Duration}, {crs_TopicId}, {crs_TopicName}";
        }
    }
}
