public class c06createandaddfilestreamwriter{

  public System.Collections.Generic.List<System.IO.StreamWriter> listsw;
    public c06createandaddfilestreamwriter(){
        this.runcreatelistforstreamwriteroffilessuccess = false;
        this.runaddstreamwriterforfileintolistsuccess = false;
    }

    public bool runcreatelistforstreamwriteroffilessuccess;
    public bool runaddstreamwriterforfileintolistsuccess;

    public void runcreatelistforstreamwriteroffiles(bool durchfuehren, int msgboxjaneinvalue){
        this.runcreatelistforstreamwriteroffilessuccess = false;
        if (durchfuehren&&msgboxjaneinvalue!=3) {
            this.listsw = new System.Collections.Generic.List<System.IO.StreamWriter>();
            this.runcreatelistforstreamwriteroffilessuccess = true;
        }
    }

    public void runaddstreamwriterforfileintolist(string pathtofile, bool durchfuehren,int msgboxjaneinvalue){
        this.runaddstreamwriterforfileintolistsuccess = false;
        if (durchfuehren&&msgboxjaneinvalue!=3)
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter(pathtofile, true);
            listsw.Add(sw);
            this.runaddstreamwriterforfileintolistsuccess = true;
        }
    }
}
