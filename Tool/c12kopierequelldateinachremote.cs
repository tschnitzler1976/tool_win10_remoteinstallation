public class c12kopierequelldateinachremote
{
    public bool prozedurkopierequelldateinachremotesuccess;

    public c12kopierequelldateinachremote()
    {
        this.prozedurkopierequelldateinachremotesuccess = false;
    }

    public void prozedurkopierequelldateinachremote(string quellpfad, string zielpfad,bool durchfuehren)
    {
        this.prozedurkopierequelldateinachremotesuccess = false;
        if (durchfuehren) { 
            System.IO.File.Copy(quellpfad, zielpfad);
            this.prozedurkopierequelldateinachremotesuccess = true;
        }
    }
}