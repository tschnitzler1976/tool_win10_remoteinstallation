public class c14installation
{

    public bool unauthorised;
    public bool authorized;
    
    public c14installation()
    {
        this.unauthorised = false;
        this.authorized = false;
    }

    public void ausfuehrunginstallation(string workstationname, string username, string password, bool durchfuehren, int msgboxjaneinvalue)
    {
        if (durchfuehren && msgboxjaneinvalue == 1)
        {
            this.unauthorised = false;
            this.authorized = true;

            var connection = new System.Management.ConnectionOptions();
            connection.Username = username; //auskommentieren, wenn der Rechnername 127.0.0.1 ist.
            connection.Password = password; //auskommentieren, wenn der Rechnername 127.0.0.1 ist.
            //Ausfuehrung der PMI.exe ohne Benutzerinteraktion
            object[] theProcessToRun2 = { @"C:\PMI.exe /install  /quiet /norestart" }; //install PMI.exe silently

            var wmiScope = new System.Management.ManagementScope(@"\\" + workstationname + @"\root\cimv2", connection);
            try
            {
                wmiScope.Connect();
                using (var managementClass = new System.Management.ManagementClass(wmiScope, new System.Management.ManagementPath("Win32_Process"), new System.Management.ObjectGetOptions()))
                {
                    managementClass.InvokeMethod("Create", theProcessToRun2);
                }
            }
            catch (System.UnauthorizedAccessException)
            {
                this.unauthorised = true;
                this.authorized = false;
            }
        }
    }
 }