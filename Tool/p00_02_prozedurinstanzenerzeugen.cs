class p00_02_prozedurinstanzenerzeugen
{
    public p00_02_prozedurinstanzenerzeugen()
    {
        this.instanzenvontypenerzeugensuccess = false;
    }

    public bool instanzenvontypenerzeugensuccess;

    public p01loaddatafromconfig p01_loaddatafromconfig;
    public p02loaddatafromworkstationlist p02_loaddatafromworkstationlist;
    public p03runthroughtheworkstationarray p03_runthroughtheworkstationarray;
    public p04variablesfordecisions p04_variablesfordecisions;

    public void instanzenvontypenerzeugen(bool durchfuehren)
    {
        this.instanzenvontypenerzeugensuccess = false;
        if (durchfuehren) {
            this.p01_loaddatafromconfig = new p01loaddatafromconfig();
            this.p02_loaddatafromworkstationlist = new p02loaddatafromworkstationlist();
            this.p03_runthroughtheworkstationarray = new p03runthroughtheworkstationarray();
            this.p04_variablesfordecisions = new p04variablesfordecisions();
            this.instanzenvontypenerzeugensuccess = true;
        }
    }
}