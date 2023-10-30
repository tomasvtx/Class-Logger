using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logger
{
    public class Msg
    {
        // APP
        public const string AlreadyRunning = "The program is already running";
        public const string ConfigNotFound = "Configuration file not found";
        public const string ConfigNotValid = "Invalid configuration file";
        public const string ArgsNotValid = "Arguments configuration is not set properly";
        public const string ConfigCreated = "Configuration file created";
        public const string ConfigUnableToCreate = "Unable to create configuration file";

        // INIT
        public const string Init = "Init started";
        public const string InitDio = "DIO init started";
        public const string InitDioDone = "DIO init finished";
        public const string InitPrn = "PRN init started";
        public const string InitPrnDone = "PRN init finished";
        public const string InitDb = "DB connection test started";
        public const string InitDbDone = "DB connection test finished";
        public const string InitBcs = "BCS init started";
        public const string InitBcsDone = "BCS init finished";
        public const string InitSio = "SIO init started";
        public const string InitSioDone = "SIO init finished";
        public const string InitIdc = "IDC init started";
        public const string InitIdcSuccess = "IDC init finished";
        public const string InitDone = "Init completed";
        public const string FtpInit = "FTP init started";
        public const string FtpCompleted = "FTP list completed";
        public const string FtpError = "FTP init end with error {0}";
        public const string FtpDone = "FTP process done";

        // PROCESS
        public const string Start = "Task started";
        public const string Done = "Task completed";
        public const string Exit = "Exit requested";

        // DIO
        public const string DioOkPressed = "OK button pressed";
        public const string DioNgPressed = "NG button pressed";

        // DB
        public const string DbConnectionTest = "Connection test";
        public const string DbErrorException = "ERROR: DB exception: {0}";
        public const string DbErrorQuery = "ERROR: DB query: {0}";
        public const string DbTransactionBegin = "Transaction begin";
        public const string DbTransactionBeginUnable = "Unable to start transaction, another transaction in progress";
        public const string DbTransactionCommit = "Transaction commit";
        public const string DbTransactionCommitUnable = "Unable to commit transaction, no transaction in progress";
        public const string DbTransactionRollback = "Transaction rollback";
        public const string DbTransactionRollbackUnable = "Unable to rollback transaction, no transaction in progress";
        public const string DbRead = "Read data from DB";

        // TABLE
        public const string DbReadTable = "Read data from table {0}";
        public const string DbInsert = "Add record(s) into table {0}";
        public const string DbDelete = "Delete record(s) from table {0}";
        public const string DbSbnKishu = "Getting KISHU for SEBAN: {0} from table: {1}";
        public const string DbUpdateIdData = "Update ID Data in table {0}";
        public const string DbNoRecordToUpdate = "No record to update";
        public const string DbGetKishu = "Getting KISHU for SEBAN from {0}";

        // BCS
        public const string ReadBarcode = "Read barcode";
        public const string BarcodeLengthData = "BC length:{0}, data:\"{1}\"";

        // LOGIN
        public const string LoginRequired = "Authorization required";
        public const string LoginAuthorized = "Authorized (UserID: {0})";
        public const string LoginInvalid = "Invalid username/password (UserID: {0})";
        public const string LoginUnauthorized = "Not authorized (UserID: {0})";

        // ERRORS
        public const string DioErrorException = "ERROR: DIO exception: {0}";
        public const string PrnErrorException = "ERROR: PRN exception: {0}";
        public const string BcsErrorException = "ERROR: BCS exception: {0}";
        public const string SioErrorException = "ERROR: BCS exception: {0}";
        public const string IdcErrorException = "ERROR: IDC init exception: {0}";

        // MISC
        public const string WaitXSec = "Waiting for {0} seconds";
    }
}
