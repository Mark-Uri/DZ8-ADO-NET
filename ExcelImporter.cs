using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;

public class ExcelImporter
{
    public static List<User> ImportUsersFromExcel(string filePath)
    {
        
        ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

        List<User> users = new List<User>();




        using (var package = new ExcelPackage(new FileInfo(filePath)))
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets[0];


            int rowCount = worksheet.Dimension.Rows;
            for (int row = 2; row <= rowCount; row++)
            {
                string username = worksheet.Cells[row, 1].Text;
                string password = worksheet.Cells[row, 2].Text;

                users.Add(new User { Username = username, Password = password });


            }


        }

        return users;
    }
}
