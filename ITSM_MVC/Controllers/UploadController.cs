using itsm.parser.Model;
using ITSM_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.OleDb;

namespace ITSM_MVC.Controllers
{
    public class UploadController : Controller
    {
        private readonly ILogger<UploadController> _logger;
        private readonly ServerDBContext _dbContext = null;

        public UploadController(ILogger<UploadController> logger, ServerDBContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
         
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormFile file,string tableType)
        {
            var path = Path.Combine("D:\\ITSM\\", "uploads", file.FileName);
            if (file.Length > 0)
            {
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyToAsync(fileStream);
                }
                if (Request.Form["tableType"].ToString() == "1")
                {
                    InsertGplextoDatabase(path);
                }
                else if (Request.Form["tableType"].ToString() == "2")
                {
                    InsertOTRStoDatabase(path);
                }

            }
            return View();
        }
        public bool InsertGplextoDatabase(string strFilePath)
        {

            using (StreamReader reader = new StreamReader(strFilePath))
            {
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    GPlex tblObj = new GPlex();
                    if (!string.IsNullOrEmpty(line))
                    {
                        string[] values = line.Split(',');
                        tblObj.start_time = DateTime.Parse(values[0].ToString());
                        tblObj.stop_time = DateTime.Parse(values[1].ToString());
                        tblObj.caller_id = values[2];
                        tblObj.did = values[3];
                        tblObj.ivr_enter_time = values[4];
                        tblObj.ivr = values[5];
                        tblObj.time_in_ivr = values[6];
                        tblObj.ivr_language = values[7];
                        tblObj.skill_enter_time = values[8];
                        tblObj.skill = values[9];
                        tblObj.hold_in_queue = values[10];
                        tblObj.agent_id = values[11];
                        tblObj.nick_name = values[12];
                        tblObj.status = values[13];
                        tblObj.service_time = values[14];
                        tblObj.total_time = values[15];
                        tblObj.missed_call = values[16];
                        tblObj.disc_party = values[17];
                        tblObj.call_id = values[18];
                        _dbContext.GPlex.Add(tblObj);
                        _dbContext.SaveChanges();
                    }
                }
            }

            return true;
        }
        public bool InsertOTRStoDatabase(string strFilePath)
        {
            string connString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + strFilePath + "; Extended Properties =\"Excel 12.0;HDR=Yes;IMEX=2\"";
            bool result = false;
            OleDbConnection oledbConn = new OleDbConnection(connString);
            DataTable dt = new DataTable();
            try
            {
                oledbConn.Open();
                using (OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Sheet1$]", oledbConn))
                {
                    OleDbDataAdapter oleda = new OleDbDataAdapter();
                    oleda.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    oleda.Fill(ds);

                    dt = ds.Tables[0];

                    if (dt.Rows.Count > 0)
                    {

                        foreach (DataRow row in dt.Rows)
                        {
                            string ticketNumber = row["Ticket Number"].ToString();
                            if (_dbContext.OTRS.Where(a=>a.ticket_number == ticketNumber).Count() == 0 ) {
                                OTRS otrs = new OTRS();
                                otrs.ticket_number = ticketNumber;
                                otrs.age = row["Age"].ToString();
                                otrs.createdDate = DateTime.Parse(row["Created"].ToString());
                                otrs.closed = row["Closed"].ToString();
                                otrs.firstLock = row["FirstLock"].ToString();
                                otrs.firstResponse = row["FirstResponse"].ToString();
                                otrs.state = row["State"].ToString();
                                otrs.priority = row["Priority"].ToString();
                                otrs.queue = row["Queue"].ToString();
                                otrs.locks = row["Lock"].ToString();
                                otrs.owner = row["Owner"].ToString();
                                otrs.userFirstname = row["UserFirstname"].ToString();
                                otrs.userLastname = row["UserLastname"].ToString();
                                otrs.customerID = row["CustomerID"].ToString();
                                otrs.customer_name = row["Customer Name"].ToString();
                                otrs.from = row["From"].ToString();
                                otrs.subject = row["Subject"].ToString();
                                otrs.accountedTime = row["AccountedTime"].ToString();
                                otrs.articleTree = row["ArticleTree"].ToString();
                                otrs.solutionInMin = row["SolutionInMin"].ToString();
                                otrs.solutionDiffInMin = row["SolutionDiffInMin"].ToString();
                                otrs.firstResponseInMin = row["FirstResponseInMin"].ToString();
                                otrs.firstResponseDiffInMin = row["FirstResponseDiffInMin"].ToString();

                                _dbContext.OTRS.Add(otrs);
                                _dbContext.SaveChanges();
                            }

                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            finally
            {
                oledbConn.Close();
            }
            return result;

        }

    }
}
