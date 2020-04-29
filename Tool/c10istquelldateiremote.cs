public class c10istquelldateiremote
{
    public string dateiname;
    public string zielpfadstringmitdateiname;
    public string zielpfadstringohnedateiname;
    public bool durchlaufezielpfadsuccess;

    public bool quelldateiistremote;
    public bool testeobquelldateiremoteliegtsuccess;

    public c10istquelldateiremote()
    {
        this.testeobquelldateiremoteliegtsuccess = false;
    }

    public void testeobquelldateiremoteliegt(string zielpfad, bool durchfuehren)
    {
        this.testeobquelldateiremoteliegtsuccess = false;
        this.quelldateiistremote = true;
        if (durchfuehren)
        {
            if (System.IO.File.Exists(zielpfad) == false)
            {
                this.quelldateiistremote = false;
            }
            this.testeobquelldateiremoteliegtsuccess = true;
        }
    }
 }