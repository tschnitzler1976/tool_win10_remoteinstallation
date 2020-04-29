public class c08workstationprozesstest{
    public System.Diagnostics.Process[] listeallerprozesse;
    public bool weitermachen;
    public bool nichtweitermachen;
    public bool vorkommenstelle;
    public bool istzugriffaufprozesseaufworktationmoeglichsuccess;
    public bool ueberpruefelaufendeprozesseremotesuccess;

    public c08workstationprozesstest(){
        this.istzugriffaufprozesseaufworktationmoeglichsuccess = false;
        this.ueberpruefelaufendeprozesseremotesuccess = false;
        this.weitermachen = false;
        this.nichtweitermachen = true;
    }

    public void istzugriffaufprozesseaufworktationmoeglich(string computername, bool durchfuehren,int msgboxjaneinvalue)
    {
        this.istzugriffaufprozesseaufworktationmoeglichsuccess = false;
        if (durchfuehren&&msgboxjaneinvalue!=3) { 
            this.weitermachen = true;
            this.nichtweitermachen = false;
            try
            {
                this.listeallerprozesse = System.Diagnostics.Process.GetProcesses(computername);
            }
            catch (System.InvalidOperationException)
            {
                this.weitermachen = false;
                this.nichtweitermachen = true;
            }
            this.istzugriffaufprozesseaufworktationmoeglichsuccess = true;
        }
    }

    public void ueberpruefelaufendeprozesseremote(string prozessname, bool durchfuehren,int msgboxjaneinvalue)
    {
        this.ueberpruefelaufendeprozesseremotesuccess = false;

        if (durchfuehren&&msgboxjaneinvalue!=3) { 
            this.weitermachen = true;
            this.nichtweitermachen = false;
            for (int zahldurchprozesse=0; zahldurchprozesse < this.listeallerprozesse.Length; zahldurchprozesse++)
            {
                string prozess=this.listeallerprozesse[zahldurchprozesse].ToString();
                System.Console.WriteLine(prozess);
                this.vorkommenstelle=prozess.Contains(prozessname);
                if (this.vorkommenstelle)
                {
                    this.weitermachen = false;
                    this.nichtweitermachen = true;

                }
            }
            this.ueberpruefelaufendeprozesseremotesuccess = true;
        }
    }
}
