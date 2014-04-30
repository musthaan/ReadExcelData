using Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string file = FileUpload1.FileName;
        if (file.EndsWith(".xlsx"))
        {
            // Reading from a binary Excel file (format; *.xlsx)
            string folderPath = Server.MapPath("uploads");
            FileUpload1.SaveAs(folderPath + "\\" + file);
            FileStream stream = File.Open(folderPath + "\\"+ file, FileMode.Open, FileAccess.Read);
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            DataSet result = excelReader.AsDataSet();
            excelReader.Close();
            GVList.DataSource = result;
            GVList.DataBind();
        }
    }
}