public class c09zielpfad
{
    public string dateiname;
    public string zielpfadstringmitdateiname;
    public string zielpfadstringohnedateiname;
    public bool durchlaufezielpfadsuccess;

    public c09zielpfad()
    {
        this.durchlaufezielpfadsuccess = false;
    }

    public void durchlaufezielpfad(string workstationname, bool durchfuehren, int msgboxjaneinvalue)
    {

        this.durchlaufezielpfadsuccess = false;
        if (durchfuehren&&msgboxjaneinvalue!=3) { 
            this.zielpfadstringmitdateiname = @"\\" + workstationname + @"\c$\PMI.exe";
            this.zielpfadstringohnedateiname = @"\\" + workstationname + @"\c$\";
            this.durchlaufezielpfadsuccess = true;
        }
    }
 }