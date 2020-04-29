public class p02loaddatafromworkstationlist{
    public string [] datafromworkstationlist;
    public bool runsavedatafromworkstationlistsuccess;

    public p02loaddatafromworkstationlist(){
    }
    public void runsavedatafromworkstationlist(string [] sourcedata, bool durchfuehren,int msgboxjaneinvalue){
        this.runsavedatafromworkstationlistsuccess = false;
        if (durchfuehren&&msgboxjaneinvalue!=3)
        {
            this.datafromworkstationlist = sourcedata;
            this.runsavedatafromworkstationlistsuccess = true;
        }
    }
}