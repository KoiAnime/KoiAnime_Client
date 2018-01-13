using System;

namespace KoiAnime_Client.UserLibs
{
    [Serializable]
    public class Title
    {
        public string WindowCategory { get; set; }
        public int TitleId { get; set; }
        public string TitleName { get; set; }
        public string TitleDescription { get; set; }
        public int TitleCategory { get; set; }
        public int TitleNumberChapters { get; set; }
        public DateTime TitleStartDateTime { get; set; }
        public string TitleCoverImg { get; set; }
        public int TitleState { get; set; }
        public long TitleViews { get; set; }

        public Title(string windowCategory,int titleid, string name,string description,int category,int numChapters,DateTime startDate,string cover,int state,long views)
        {
            WindowCategory = windowCategory;
            TitleId = titleid;
            TitleName = name;
            TitleDescription = description;
            TitleCategory = category;
            TitleNumberChapters = numChapters;
            TitleStartDateTime = startDate;
            TitleCoverImg = cover;
            TitleState = state;
            TitleViews = views;
        }

        public string GetWindowCategory()
        {
            return WindowCategory;
        }

        public int GetTitleId()
        {
            return TitleId;
        }

        public string GetTitleName()
        {
            return TitleName;
        }

        public string GetTitleDescription()
        {
            return TitleDescription;
        }

        public int GetTitleCategory()
        {
            return TitleCategory;
        }

        public int GetTitleChapterNumbers()
        {
            return TitleNumberChapters;
        }

        public DateTime GetTitleStartDateTime()
        {
            return TitleStartDateTime;
        }

        public string GetTitleCoverImg()
        {
            return TitleCoverImg;
        }

        public int GetTitleState()
        {
            return TitleState;
        }

        public long GetTitleViews()
        {
            return TitleViews;
        }
    }
}
