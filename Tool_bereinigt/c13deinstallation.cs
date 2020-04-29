public class c13deinstallation
{
    public bool unauthorised;
    public bool authorized;

    public c13deinstallation()
    {
        this.unauthorised = false;
        this.authorized = true;
    }

    public void ausfuehrungdeinstallation(string workstationname, string username, string password, bool durchfuehren,int msgboxjaneinvalue)
    {
        if (durchfuehren&&msgboxjaneinvalue==2) { 
            this.unauthorised = false;
            this.authorized = true;
            var connection = new System.Management.ConnectionOptions();
            connection.Username = username; //auskommentieren, wenn der Rechnername 127.0.0.1 ist.
            connection.Password = password; //auskommentieren, wenn der Rechnername 127.0.0.1 ist.
            //Ausfuehrung der PMI.exe ohne Benutzerinteraktion
            object[] theProcessToRun1 = { @"C:\PMI.exe /uninstall  /quiet /norestart /log C:\log.txt" }; //uninstall PMI silently

            var wmiScope = new System.Management.ManagementScope(@"\\" + workstationname + @"\root\cimv2", connection);
            try
            {
                wmiScope.Connect();
                using (var managementClass = new System.Management.ManagementClass(wmiScope, new System.Management.ManagementPath("Win32_Process"), new System.Management.ObjectGetOptions()))
                {
                    managementClass.InvokeMethod("Create", theProcessToRun1);
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