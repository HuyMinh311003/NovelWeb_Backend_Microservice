﻿namespace HistoryMicroservice.Models
{
    public class AddHistoryRequest
    {
        public int UserId { get; set; }
        public int NovelId { get; set; }
        public int? ChapterID { get; set; }
    }

}
