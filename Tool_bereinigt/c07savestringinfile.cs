public class c07savestringinfile{

    public c07savestringinfile(){
        this.runsavestringinfilesuccess = false;
    }

    public bool runsavestringinfilesuccess;

  public void runsavestringinfile(System.IO.StreamWriter sw, string nachricht, bool durchfuehren, int msgboxjaneinvalue){
        this.runsavestringinfilesuccess = false;
        if (durchfuehren&&msgboxjaneinvalue!=3) {
            sw.WriteLine(nachricht);
            sw.Flush();
            this.runsavestringinfilesuccess = true;
        }
    }
}
