using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpJExcel.Jxl;

namespace SystemEnumerationAuditorium
{
    public class Parser
    {
        private const int tb = 44;
        public static void Parse()
        {
            var fileName = Environment.CurrentDirectory + "\\vt.xls";
            Workbook workbook = Workbook.getWorkbook(new System.IO.FileInfo(fileName));
            var sheet = workbook.getSheet(0);
            var rows = sheet.getRows();
            var countTeacher = (rows + 2) / tb;
            for (int i = 0; i < countTeacher; i++)
            {
                var teacherName = sheet.getCell(1, i * tb + 6).getContents();
                var chairName = sheet.getCell(2, i * tb + 6).getContents();
                for (int day = 0; day < 6; day++)
                {
                    for (int para = 0; para < 8; para++)
                    {
                        var groups1week = sheet.getCell(day + 1, i * tb + 8 + para * 4).getContents();
                        var auditoriums1week = sheet.getCell(day + 1, i * tb + 9 + para * 4).getContents();
                        var groups2week = sheet.getCell(day + 1, i * tb + 10 + para * 4).getContents();
                        var auditoriums2week = sheet.getCell(day + 1, i * tb + 11 + para * 4).getContents();

                    }
                }
            }


            workbook.close();
        }
    }
}
