public class c17msgboxjanein
{
    public c17msgboxjanein(){
        this.runmsgboxjaneinsuccess = false;
        this.dialogresultint = 3;
    }

    public bool runmsgboxjaneinsuccess;
    public System.Windows.Forms.DialogResult dialogresult;
    public int dialogresultint;

    public void runmsgboxjanein(string text, string caption, bool durchfuehren)
    {
        this.runmsgboxjaneinsuccess = false;
        this.dialogresultint = 3;
        if (durchfuehren)
        {
            //Als erstes in Erfahrung bringen, ob die Software installiert oder deinstalliert werden soll.
            this.dialogresult = System.Windows.Forms.MessageBox.Show(text, caption, System.Windows.Forms.MessageBoxButtons.YesNoCancel);

            if (this.dialogresult == System.Windows.Forms.DialogResult.Yes)
            {
                this.dialogresultint = 1;
            }
            else if (this.dialogresult == System.Windows.Forms.DialogResult.No)
            {
                this.dialogresultint = 2;
            }
            else if (this.dialogresult == System.Windows.Forms.DialogResult.Cancel)
            {
                this.dialogresultint = 3;
            }
        }
        this.runmsgboxjaneinsuccess = true;
    }
}