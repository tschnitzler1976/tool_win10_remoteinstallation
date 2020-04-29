class p00_01_generischeinstanzenerzeugen
{
    public p00_01_generischeinstanzenerzeugen()
    {
        this.instanzenvongenerischentypenerzeugensuccess = false;
    }

    public bool instanzenvongenerischentypenerzeugensuccess;


    public c00openfilewithprompt c00_openfilewithprompt;
    public c01fileexists c01_fileexists;
    public c02readalllinesfromtextfile c02_readalllinesfromtextfile;
    public c03loginwithprompt c03_loginwithprompt;
    public c04createnameoffilename c04_createnameoffilename;
    public c05createfile c05_createfile;
    public c06createandaddfilestreamwriter c06_createandaddfilestreamwriter;
    public c07savestringinfile c07_savestringinfile;
    public c08workstationprozesstest c08_workstationprozesstest;
    public c09zielpfad c09_zielpfad;
    public c10istquelldateiremote c10_istquelldateiremote;
    public c11loeschequelldateiremote c11_loeschequelldateiremote;
    public c12kopierequelldateinachremote c12_kopierequelldateinachremote;
    public c13deinstallation c13_deinstallation;
    public c14installation c14_installation;
    public c15checkstringempty c15_checkstringempty;
    public c16msgbox c16_msgbox;
    public c17msgboxjanein c17_msgboxjanein;

    public void instanzenvongenerischentypenerzeugen(bool durchfuehren)
    {
        this.instanzenvongenerischentypenerzeugensuccess = false;
        if (durchfuehren)
        {
            this.c00_openfilewithprompt = new c00openfilewithprompt();
            this.c01_fileexists = new c01fileexists();
            this.c02_readalllinesfromtextfile = new c02readalllinesfromtextfile();
            this.c03_loginwithprompt = new c03loginwithprompt();
            this.c04_createnameoffilename = new c04createnameoffilename();
            this.c05_createfile = new c05createfile();
            this.c06_createandaddfilestreamwriter = new c06createandaddfilestreamwriter();
            this.c07_savestringinfile = new c07savestringinfile();
            this.c08_workstationprozesstest = new c08workstationprozesstest();
            this.c09_zielpfad = new c09zielpfad();
            this.c10_istquelldateiremote = new c10istquelldateiremote();
            this.c11_loeschequelldateiremote = new c11loeschequelldateiremote();
            this.c12_kopierequelldateinachremote = new c12kopierequelldateinachremote();
            this.c13_deinstallation = new c13deinstallation();
            this.c14_installation = new c14installation();
            this.c15_checkstringempty = new c15checkstringempty();
            this.c16_msgbox = new c16msgbox();
            this.c17_msgboxjanein = new c17msgboxjanein();
            this.instanzenvongenerischentypenerzeugensuccess = true;
        }
    }
}