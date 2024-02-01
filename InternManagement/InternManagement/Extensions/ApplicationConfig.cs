using InternManagement.DTOs.Class;

namespace InternManagement.Extensions
{
    public static class ApplicationConfig
    {
        public static List<ClassOuput> GetClass()
        {
            var res = new List<ClassOuput>()
            {
                new ClassOuput()
                {
                    Id = 1,
                    Name = "Hệ thống thông tin"
                },
                new ClassOuput()
                {
                    Id = 2,
                    Name = "Công nghệ thông tin"
                },
                new ClassOuput()
                {
                    Id = 3,
                    Name = "An toàn thông tin"
                },
                new ClassOuput()
                {
                    Id = 4,
                    Name = "Khoa học máy tính"
                },
                new ClassOuput()
                {
                    Id = 5,
                    Name = "Kỹ thuật phần mềm"
                },
            };

            return res;
        }
    }
}
