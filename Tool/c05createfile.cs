public class c05createfile{

    public c05createfile(){
        this.runcreatefilesuccess = false;
    }
    public bool runcreatefilesuccess;

    public void runcreatefile(string pathtofile, bool durchfuehren,int msgboxjaneinvalue){
        this.runcreatefilesuccess = false;
        if (durchfuehren&&msgboxjaneinvalue!=3) {
            try
            {
                System.IO.FileStream sw = System.IO.File.Create(pathtofile);
                sw.Close();
                this.runcreatefilesuccess = true;
            }
            catch (System.IO.DirectoryNotFoundException)
            {
                this.runcreatefilesuccess = false;
            }
        }
    }
}
