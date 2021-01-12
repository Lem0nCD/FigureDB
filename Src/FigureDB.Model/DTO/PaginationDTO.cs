using System;

namespace FigureDB.Model.DTO
{
    public class PaginationDTO<T> where T : class
    {
        public int Total { get; set; }
        public T Data { get; set; }

        public PaginationDTO(int total, T data)
        {
            Total = total;
            Data = data ?? throw new ArgumentNullException(nameof(data));
        }
        public PaginationDTO()
        {

        }
    }
}
