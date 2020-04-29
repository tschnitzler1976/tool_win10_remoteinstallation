public class p03runthroughtheworkstationarray{
    public bool runthroughtheworkstationarraysuccess;

    public p03runthroughtheworkstationarray(){
    }
    public void runthroughtheworkstationarray(p01loaddatafromconfig p01, p02loaddatafromworkstationlist p02, c07savestringinfile c07,
        c06createandaddfilestreamwriter c06, c02readalllinesfromtextfile c02,
        c08workstationprozesstest c08, c09zielpfad c09, c10istquelldateiremote c10, c11loeschequelldateiremote c11,
        c12kopierequelldateinachremote c12, c13deinstallation c13, c14installation c14, c15checkstringempty c15,
        c16msgbox c16,bool durchfuehren,string benutzername,string passwort,int msgboxjaneinvalue){

        this.runthroughtheworkstationarraysuccess = false;
        if (durchfuehren&&msgboxjaneinvalue!=3)
        {
            for (int workstationzaehler = 0; workstationzaehler < p02.datafromworkstationlist.Length; workstationzaehler++)
            {
                if (msgboxjaneinvalue == 2)
                {
                    //Deinstallation
                    c13.ausfuehrungdeinstallation(c02.readalllinesfromtextfile[workstationzaehler], benutzername, passwort, true, msgboxjaneinvalue);
                    c07.runsavestringinfile(c06.listsw[0], "Falsche Logindaten. Deswegen schlug Authentifizierung auf Workstation " +
                        c02.readalllinesfromtextfile[workstationzaehler]
                        + " fehl. Deshalb wurde die Deinstallation nicht ausgeführt.", c13.unauthorised, msgboxjaneinvalue);
                    c07.runsavestringinfile(c06.listsw[0], "Login auf Workstation " + c02.readalllinesfromtextfile[workstationzaehler]
                        + " erfolgreich. Deshalb wird die Deinstallation der vorherigen PMI-Version ausgeführt.", c13.authorized, msgboxjaneinvalue);
                    c07.runsavestringinfile(c06.listsw[0], "Deinstallation auf Workstation "
                        + c02.readalllinesfromtextfile[workstationzaehler]
                        + " erfolgreich gestartet.", c08.weitermachen, msgboxjaneinvalue);
                }
                else if (msgboxjaneinvalue == 1)
                {
                   
                    c07.runsavestringinfile(c06.listsw[0], "Es wird überprüft, ob der Zugriff auf Prozesse auf " + p02.datafromworkstationlist[workstationzaehler] + " möglich ist.", durchfuehren, msgboxjaneinvalue);
                    c08.istzugriffaufprozesseaufworktationmoeglich(c02.readalllinesfromtextfile[workstationzaehler], c07.runsavestringinfilesuccess, msgboxjaneinvalue);
                    c07.runsavestringinfile(c06.listsw[0], "Weil auf die Prozesse der Workstation " + c02.readalllinesfromtextfile[workstationzaehler] + " nicht zugegriffen werden kann, wird das Update nicht ausgeführt.", c08.weitermachen, msgboxjaneinvalue);
                    c07.runsavestringinfile(c06.listsw[1], c02.readalllinesfromtextfile[workstationzaehler] + " //auf Prozesse konnte nicht zugegriffen werden", c08.weitermachen, msgboxjaneinvalue);
                    c07.runsavestringinfile(c06.listsw[0], "Weil auf die Prozesse der Workstation " + c02.readalllinesfromtextfile[workstationzaehler] + " zugegriffen werden kann, wird überprüft, ob PMI auf Workstatation "
                        + c02.readalllinesfromtextfile[workstationzaehler] + " läuft.", c08.weitermachen, msgboxjaneinvalue);
                    c07.runsavestringinfile(c06.listsw[0], "Prozesse untersuchen. Ist die Zeichenkette 'PMI' Teil der Bezeichnung eines Prozesses auf " + c02.readalllinesfromtextfile[workstationzaehler] + ", wird das Update nicht ausgeführt.", c08.weitermachen, msgboxjaneinvalue);
                    c08.ueberpruefelaufendeprozesseremote("PMi", c08.weitermachen, msgboxjaneinvalue);
                    c07.runsavestringinfile(c06.listsw[0], "Ein PMI-Prozess läuft derzeit auf Workstation " + c02.readalllinesfromtextfile[workstationzaehler] + ". Deshalb wird das Update nicht ausgeführt.", c08.weitermachen, msgboxjaneinvalue);
                    c07.runsavestringinfile(c06.listsw[1], c02.readalllinesfromtextfile[workstationzaehler] + " //PMI-Prozess lief", c08.weitermachen, msgboxjaneinvalue);
                    c07.runsavestringinfile(c06.listsw[0], "Kein PMI-Prozess läuft derzeit auf Workstation " + c02.readalllinesfromtextfile[workstationzaehler] + ". Deshalb wird das Update ausgeführt.", c08.weitermachen, msgboxjaneinvalue);
                    c07.runsavestringinfile(c06.listsw[0], "Da kein PMI-Prozess läuft (siehe Punkt 6), muss die PMI-Updatedatei (PMI.exe) auf " + c02.readalllinesfromtextfile[workstationzaehler] + " kopiert und ausgeführt werden.", c08.weitermachen, msgboxjaneinvalue);
                    c09.durchlaufezielpfad(c02.readalllinesfromtextfile[workstationzaehler], c08.weitermachen, msgboxjaneinvalue);
                    c12.prozedurkopierequelldateinachremote(p01.sourcefile, c09.zielpfadstringmitdateiname,c08.weitermachen);
                    c14.ausfuehrunginstallation(c02.readalllinesfromtextfile[workstationzaehler], benutzername, passwort, c08.weitermachen, msgboxjaneinvalue);
                }
            }
        }
    }
}