public class p01loaddatafromconfig{
    public string [] datafromconfig;
    public string sourcefile;
    public string workstationlist;
    public string pathtooutputlogfile;
    public string pathtooutputworkstationfile;
    public bool runsavedatafromconfigsuccess;
    public bool runarraytosaveconfigsuccess;

    public p01loaddatafromconfig()
    {
        this.runarraytosaveconfigsuccess = false;
        this.runsavedatafromconfigsuccess = false;
    }

    public void runsavedatafromconfig(string [] sourcedata, bool durchfuehren, int msgboxjaneinvalue){
        this.runsavedatafromconfigsuccess = false;
        if (durchfuehren&&msgboxjaneinvalue!=3)
        {
            this.datafromconfig = sourcedata;
            this.runsavedatafromconfigsuccess = true;
        }
    }
    public void runarraytosaveconfig(bool durchfuehren, int msgboxjaneinvalue){
        this.runarraytosaveconfigsuccess = false;
        if (durchfuehren&&msgboxjaneinvalue!=3) {        
            string [] tempvar=datafromconfig[0].Split('=');
            this.sourcefile = tempvar[1];
            tempvar = datafromconfig[1].Split('=');
            this.workstationlist = tempvar[1];
            tempvar = datafromconfig[2].Split('=');
            this.pathtooutputlogfile=tempvar[1];
            tempvar = datafromconfig[3].Split('=');
            this.pathtooutputworkstationfile = tempvar[1];
            this.runarraytosaveconfigsuccess = true;
       }
    }
}