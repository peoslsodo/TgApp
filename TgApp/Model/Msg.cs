
namespace TgApp.Model
{
    public class Msg
    {
        public const string MsgInfo = "Information";
        public const string MsgError = "Error";
        public const string ContactSync = "Sync Contact Complete!";
        public const string ContactDel = "Are you sure del the contact?";
        public const string ContactClear = "Are you sure clear all contact?";

        public const string ConfigExist = "Phone number already exists, please do not add it again!";
        public const string ConfigPhone = "The phone number cannot be empty!";
        public const string ConfigApiId = "The ApiId cannot be empty!";
        public const string ConfigApiHash = "The ApiHash cannot be empty!";


        public const string NoData = "No Data!";
        public const string ExportSuccess = "Export Success!";
        public const string ClearAll = "Are you sure you want to clear all data?";
        public const string DelSucess = "Delete data success!";
        public const string DelSure = "Are you sure delete item?";
        public const string SaveSuccess = "Save Success!";
        public const string SaveFail = "Save Fail!";

        public const string AuthCode = "Login code cannot be empty!";
        public const string AuthSuccess = "Authorization Success!";
        public const string AuthFail = "Authorization Fail!";
        public const string AuthCheck = "Login code expired or wrong！";
        public const string AuthSendCode = "Login code send successfully!";


        public const string TdExceptionParam = "call setTdlibParameters first";


        public const string TdConfigParam = "Please complete parameter Setup and authorization first";
    }
}
