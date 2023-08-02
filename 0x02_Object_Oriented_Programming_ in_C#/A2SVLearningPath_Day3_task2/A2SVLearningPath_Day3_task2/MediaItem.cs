namespace A2SVLearningPath_Day3_task2
{
    public class MediaItem
    {
        internal string Title { get; set; } = "Media";
        internal string MediaType { get; set; } = "Type";
        internal int Duration { get; set; } = 0;

        public MediaItem(string[] input)
        {
            Title = input[0];
            MediaType = input[1];
            Duration = int.Parse(input[2]);
        }
    }
}