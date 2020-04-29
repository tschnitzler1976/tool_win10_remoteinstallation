public class c11loeschequelldateiremote
{
    public bool loeschenquelldateierfolgreich;
    public bool testeobquelldateiremoteliegtsuccess;


    public c11loeschequelldateiremote()
    {
        this.testeobquelldateiremoteliegtsuccess = false;
        this.loeschenquelldateierfolgreich = true;
    }

    public void fuehreloeschenquelldateiremotedurch(string zielpfad, bool durchfuehren,int msgboxjaneinvalue)
    {
        this.testeobquelldateiremoteliegtsuccess = false;
        this.loeschenquelldateierfolgreich = true;
        if (durchfuehren&&msgboxjaneinvalue!=3)
        {

            //PMI.exe auf C: von Workstation löschen
            //Es ist moeglich, dass die Datei in Zugriff ist

            try
            {
                System.IO.File.Delete(zielpfad);
            }
            catch (System.UnauthorizedAccessException)
            {
                this.loeschenquelldateierfolgreich = false;
            }
            this.testeobquelldateiremoteliegtsuccess = true;
        }
    }
 }