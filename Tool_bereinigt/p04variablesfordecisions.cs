public class p04variablesfordecisions
{
    public p04variablesfordecisions(){
        this.konfigurationsdateivorhanden = false;
        this.benutzernamevorhanden = false;
        this.passwortvorhanden = false;
        this.logfilecouldbecreated = false;
        this.workstationfilecouldbecreated = false;
        this.workstationfilevorhanden = false;
        this.installationsdateivorhanden = false;
    }

    public bool konfigurationsdateivorhanden;
    public bool benutzernamevorhanden;
    public bool passwortvorhanden;
    public bool workstationfilevorhanden;
    public bool installationsdateivorhanden;
    public bool logfilecouldbecreated;
    public bool workstationfilecouldbecreated;
}