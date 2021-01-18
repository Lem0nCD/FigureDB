using System;
using System.Collections.Generic;
using System.Text;

namespace FigureDB.Model.DTO
{
    public class CommentDTO
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string NickName { get; set; }
        public string Avatar { get; set; }
        public int UpVote { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
