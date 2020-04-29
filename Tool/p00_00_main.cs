class p00main
{
    /*Ziel des Programms:
     *Remote sollen über ein Windows-Netzwerk Workstations mit in einer Quelldatei befindlichen Installationsroutine aktualisiert
     * werden. Es sind drei Parameter dafür notwendig. Der erste Parameter ist der Pfad zur Quelldatei. Der zweite Parameter
     * ist die Liste mit den IP-Adressen oder Windows-Rechnernamen, die vom DNS oder WINS in IP-Adressen umgewandelt werden können,
     * die in einer Eingabedatei im Textformat vorliegen muss. Der dritte Parameter ist die Ausgabe des Programms und die Ausgabe
     * der IP-Adressen oder Rechnernamen der Workstations, bei denen das Ausführen der Installationsroutine ausgehend von der
     * oben genannten Quelldatei nicht erfolgreich war. Diese Information liegt in einer Ausgabedatei im Textformat vor, die gegen
     * die oben genannte Eingabedatei im Textformat mit Rechnernamen von Workstations getauscht werden kann, die wie bereits erwähnt,
     * nicht im vorigen Durchlauf mit in einer Quelldatei befindlichen Installationsroutine aktualisiert werden konnten. Diese drei
     * Parameter sind in einer Konfigurationsdatei zu finden, die Bestandteil dieses Programms ist und die durch den ausführenden
     * Benutzer dieses Programmes anzupassen ist. Weitere Informationen zur Konfigurationsdatei weiter unten.
     */

    [System.STAThreadAttribute]
    static void Main(string[] args)
    {

        p00_01_generischeinstanzenerzeugen p00_01 = new p00_01_generischeinstanzenerzeugen();
        p00_02_prozedurinstanzenerzeugen p00_02 = new p00_02_prozedurinstanzenerzeugen();
        //1.Laden wichtiger Hilfsinstanzen.

        //Instanzen erzeugen von generischen Typen.
        //Nur, wenn true, ansonsten Programmende.
        p00_01.instanzenvongenerischentypenerzeugen(true);
        //Instanzen erzeugen von nicht-generischen Typen.
        //Nur, wenn p00_01.instanzenvongenerischentypenerzeugensuccess=true, ansonsten Programmende.
        p00_02.instanzenvontypenerzeugen(p00_01.instanzenvongenerischentypenerzeugensuccess);
        /*2. Einlesen der Konfigurationsdatei in den Speicher, um diese Informationen im weiteren Verlauf zu verwenden.
        Es muss eine Konfigurationsdatei mit 3 Angaben gefunden werden. Díe erste Angabe ist
        "pathtosaveoutputfile"=Pfad für Ausgabedateien, wobei die erste Ausgabedatei für allgemeine
        Ausgaben' ist und die zweite Ausgabedatei die Workstations beinhaltet, bei denen das Update nicht
        durchgeführt werden konnte. Diese zweite Ausgabedatei kann dann verwendet werden als 'Workstationliste' hinter
        der dritten und letzten Angabe in dieser Konfigurationsdatei. Die besagte dritte und letzte Angabe in der
        Konfigurationsdatei ist der Pfad zur Datei mit einer Liste der Rechnernamen von Workstations, die für ein
        PMI-Update zu berücksichtigen sind. Diese Angabe hat folgendes Aussehen: 
        "workstationslist"=Pfad zur Datei mit einer Liste der Rechnernamen von Workstations, die für ein PMI-Update
        zu berücksichtigen sind. */

        //Benutzer darüber informieren, dass erst jede PMI-Software deinstalliert werden muss, bevor installiert wird.
        p00_01.c16_msgbox.runmsgboxpositive("Bitte erst 'Deinstallation = Nein' wählen. Wenn die Deinstallation durchgelaufen ist,"
           + " bitte erst dann 'Installation = Ja' wählen", true, 0);
        //Benutzer fragen, ob installiert oder deinstalliert werden soll.
        p00_01.c17_msgboxjanein.runmsgboxjanein("Soll die Software installiert "
                + "oder deinstalliert werden? 'Ja' bedeutet Installation und 'Nein' bedeutet Deinstallation", "Installieren oder deinstallieren?", p00_02.instanzenvontypenerzeugensuccess);

        if (p00_01.c17_msgboxjanein.dialogresultint == 1 || p00_01.c17_msgboxjanein.dialogresultint == 2)
        {

            //Ort der Konfigurationsdatei durch den Benutzer angeben lassen.
            p00_01.c16_msgbox.runmsgboxpositive("Bitte den Pfad zur Konfigurationsdatei in das folgende Eingabefeld"
                + " eintragen. Der Name für die Konfigurationsdatei ist bereits auf 'pkconfig.conf' voreingestellt. "
                + "Beispiel fuer einen richtigen Eintrag mit Beispiel-Ordnername 'ordnermitkonfigurationddatei': "
                + "'C:/ordnermitkonfigurationddatei/'. Danach bitte Benutzername und Passwort für Benutzer mit "
                + "Administratorrechten eingeben, damit ein Login zur Installation bzw. Deinstallation auf "
                + "betreffende Workstations gemäß Workstationliste möglich ist.", true, 0);
            //Nur, wenn p00_01.instanzenvongenerischentypenerzeugensuccess=true, ansonsten Programmende.
            p00_01.c00_openfilewithprompt.runopenedfile("Pfad zur Datei", "Pfad zur Konfigurationsdatei", p00_02.instanzenvontypenerzeugensuccess, p00_01.c17_msgboxjanein.dialogresultint);

            //Den Pfad gemäß oben stehender Meldung mit Dateinamen für die Konfigurationsdatei konkatenieren.
            p00_01.c00_openfilewithprompt.openedfilepath = p00_01.c00_openfilewithprompt.openedpath + @"\pkconfig.conf";

            //Prüfen, dass der Benutzer keinen leeren String übergeben hat.
            //Nur, wenn p00_01.instanzenvongenerischentypenerzeugensuccess=true, ansonsten Programmende.
            p00_01.c15_checkstringempty.checkstringempty(p00_01.c00_openfilewithprompt.openedpath, p00_01.c00_openfilewithprompt.runopenedfilesuccess, p00_01.c17_msgboxjanein.dialogresultint);

            //Warm-Messagebox ausgeben, falls Benutzer leeren String übergeben hat. Msgbox wird ausgelöst, wenn p00_01.c15_checkstringempty.stringnotempty=false.
            //Nur wenn p00_01.c15_checkstringempty.stringnotemptys=false. Daraus folgt das Programmende.
            p00_01.c16_msgbox.runmsgboxnegative("Die Zeichenkette, die den Pfad zur Konfigurationsdatei enthalten soll, ist leer. Programmende.", p00_01.c15_checkstringempty.stringempty, p00_01.c17_msgboxjanein.dialogresultint);

            //Prüfen, ob die Konfigurationsdatei existiert.
            //Ist die Angabe des Benutzers richtig?
            //Nur, wenn p00_01.c15_checkstringempty.stringnotempty=true, ansonsten Programmende.
            p00_01.c01_fileexists.runopenfile(p00_01.c00_openfilewithprompt.openedfilepath, p00_01.c15_checkstringempty.stringnotempty, p00_01.c17_msgboxjanein.dialogresultint);

            //Messagebox ausgeben, wenn der Benutzer einen falschen Pfad angegeben hat.
            //Nur wenn p00_01.c01_fileexists.fileexists=false, dann Programmende.
            if (p00_01.c15_checkstringempty.stringnotempty)
                p00_01.c16_msgbox.runmsgboxnegative("Die Konfigurationsdatei existiert nicht unter '" + p00_01.c00_openfilewithprompt.openedfilepath + "'. Programmende.", p00_01.c01_fileexists.filedoesnotexist, p00_01.c17_msgboxjanein.dialogresultint);

            //Davon ausgehen, dass Konfigurationsdatei nicht existiert. Dies für weitere Bedingungsprüfungen global speichern.
            //In diesem Falle weitere Ausführungen verhindern.
            if (p00_01.c01_fileexists.fileexists)
            {
                p00_02.p04_variablesfordecisions.konfigurationsdateivorhanden = true;
            }
        } //Nur, wenn Deinstallation oder Installation in oberster Messagebox gewählt wurde . -Emde-

        if(p00_02.p04_variablesfordecisions.konfigurationsdateivorhanden){

            /*Falls die Konfigurationsdatei tatsächlich gemäß übergebenen Pfad des Benutzers existiert, den
             * *Inhalt der Konfigurationsdatei einlesen.
            *Die Konfigurationsdatei konnte geöffnet werden. Deshalb wird der Pfad zur Quelldatei für die Installation,
            * der Pfad für die Ausgabedateien (Log und Workstations, die für die Installation nicht berücksichtigt werden konnten),
             *und die Liste mit den betreffenden Workstations eingelesen.*/

            //Alle Werte in der Konfigurationsdatei einlesen.
            //Nur, wenn p00_01.c01_fileexists.fileexists=true, ansonsten Programmende.
            p00_01.c02_readalllinesfromtextfile.runreadalllinesfromfile(p00_01.c00_openfilewithprompt.openedfilepath, p00_01.c01_fileexists.fileexists, p00_01.c17_msgboxjanein.dialogresultint);
            //Alle Daten in der Konfigurationsdatei in ein String-Array speichern.
            //Nur, wenn p00_01.c02_openandreadalllinesintextfile.runreadfilesuccess=true, ansonsten Prog999rammende.
            p00_02.p01_loaddatafromconfig.runsavedatafromconfig(p00_01.c02_readalllinesfromtextfile.readalllinesfromtextfile, p00_01.c02_readalllinesfromtextfile.runreadalllinesfromtextfilesuccess, p00_01.c17_msgboxjanein.dialogresultint);
            //Das String-Array auslesen und die relevanten Werte in dafür vorgesehene Variablen speichern.
            //Nur, wenn p00_01.p01_loaddatafromconfig.runsavedatafromconfigsuccess=true, ansonsten Programmende.
            p00_02.p01_loaddatafromconfig.runarraytosaveconfig(p00_02.p01_loaddatafromconfig.runsavedatafromconfigsuccess, p00_01.c17_msgboxjanein.dialogresultint);
            //Usernamen eingeben lassen.
            //Nur, wenn p00_01.p01_loaddatafromconfig.runarraytosaveconfigsuccess=true, ansonsten Programmende.
            p00_01.c03_loginwithprompt.runlogin("Benutzername", "Eingabe Benutzername für TEVLAN-Admin für Workstations im TEVLAN", p00_02.p01_loaddatafromconfig.runarraytosaveconfigsuccess,p00_01.c17_msgboxjanein.dialogresultint);
            //Prüfen, ob der Benutzername nicht leer ist.
            //Nur, wenn p00_01.c03_loginwithprompt.runloginbenutzernamesuccess=true, ansonsten Programmende.
            p00_01.c15_checkstringempty.checkstringempty(p00_01.c03_loginwithprompt.benutzername, p00_01.c03_loginwithprompt.runloginbenutzernamesuccess,p00_01.c17_msgboxjanein.dialogresultint);
            //Messagebox ausgeben, falls Benutzer leeren String übergeben hat.
            //Nur wenn p00_01.c15_checkstringempty.stringnotempty=false. Daraus folgt das Programmende.
            p00_01.c16_msgbox.runmsgboxnegative("Benutzername ist leer. Programmende.", p00_01.c15_checkstringempty.stringempty,p00_01.c17_msgboxjanein.dialogresultint);
            //Wenn kein Benutzername übergeben wurde, dies in einer globalen Variable für den weiteren Verlauf in "main" vermerken.

            if (p00_01.c15_checkstringempty.stringnotempty)
            {
                p00_02.p04_variablesfordecisions.benutzernamevorhanden = true;
            }

            if (p00_02.p04_variablesfordecisions.benutzernamevorhanden)
            {

                //Passwort eingeben lassen.
                //Nur, wenn p00_01.c03_loginwithprompt.runloginbenutzernamesuccess=true, ansonsten Programmende. 
                p00_01.c03_loginwithprompt.runlogin("Passwort", "Eingabe Passwort", p00_02.p04_variablesfordecisions.benutzernamevorhanden, p00_01.c17_msgboxjanein.dialogresultint);

                //Nur, wenn p00_01.c03_loginwithprompt.runloginpasswortsuccess=true, ansonsten Programmende.
                p00_01.c15_checkstringempty.checkstringempty(p00_01.c03_loginwithprompt.passwort, p00_01.c03_loginwithprompt.runloginpasswortsuccess, p00_01.c17_msgboxjanein.dialogresultint);

                //Messagebox ausgeben, falls Benutzer leeren String für das Passwort übergeben hat.
                //Nur wenn p00_01.c15_checkstringempty.stringemptys=true, aber kein Programmende, da ein Passwort durchaus auch leer sein kann.
                p00_01.c16_msgbox.runmsgboxpositive("Passwort ist leer.", p00_01.c15_checkstringempty.stringempty, p00_01.c17_msgboxjanein.dialogresultint);

                //Für die Ausgabedatei einen Dateinamen generieren.
                //Nur, wenn p00_01.c03_loginwithprompt.runloginpasswortsuccess=true (da ein Passwort durchaus auch leer sein kann), ansonsten Programmende.
                p00_01.c04_createnameoffilename.initializelistforfilenames(p00_01.c03_loginwithprompt.runloginpasswortsuccess, p00_01.c17_msgboxjanein.dialogresultint);
                //Nur, wenn p00_01.c04_createnameoffilename.initializelistforfilenamessuccess=true, ansonsten Programmende. 
                p00_01.c04_createnameoffilename.runcreatepartoffilename(p00_02.p01_loaddatafromconfig.pathtooutputlogfile, "output", ".txt", p00_01.c04_createnameoffilename.initializelistforfilenamessuccess, p00_01.c17_msgboxjanein.dialogresultint);

                //Die Datei erstellen für die Ausgabe.
                //Nur, wenn p00_01.c04_createnameoffilename.runcreatepartoffilenamesuccess=true, ansonsten Programmende.
                if (p00_01.c04_createnameoffilename.runcreatepartoffilenamesuccess && p00_01.c17_msgboxjanein.dialogresultint != 3)
                    p00_01.c05_createfile.runcreatefile(p00_01.c04_createnameoffilename.listwithfilenames[0], p00_01.c04_createnameoffilename.runcreatepartoffilenamesuccess, p00_01.c17_msgboxjanein.dialogresultint);

                if (p00_01.c05_createfile.runcreatefilesuccess)
                {
                    p00_02.p04_variablesfordecisions.logfilecouldbecreated = true;
                    p00_01.c16_msgbox.runmsgboxnegative("Logdatei unter '" + p00_01.c04_createnameoffilename.listwithfilenames[0]
                    + "' erstellt. Bitte Informationen zum Programmverlauf dort nachlesen.", true, 1);
                }
                else
                {
                    p00_01.c16_msgbox.runmsgboxnegative("Pfad '" + p00_01.c04_createnameoffilename.listwithfilenames[0]
                        + "' in Konfigurationsdatei zur Erstellung der Ausgabedatei falsch. Bitte korrigieren. Programmende.",true,1);
                }

                if (p00_02.p04_variablesfordecisions.logfilecouldbecreated)
                {
                    //Filestreams in Liste aufnehmen.
                    //Nur, wenn p00_01.c05_createfile.runcreatefilesuccess=true, ansonsten Programmende. 
                    p00_01.c06_createandaddfilestreamwriter.runcreatelistforstreamwriteroffiles(p00_01.c05_createfile.runcreatefilesuccess, p00_01.c17_msgboxjanein.dialogresultint);

                    //Schreibzugriff auf die Ausgabedatei ermöglichen.
                    //Nur, wenn p00_01.c05_createfile.runcreatefilesuccess=true, ansonsten Programmende. 
                    if (p00_01.c05_createfile.runcreatefilesuccess && p00_01.c17_msgboxjanein.dialogresultint != 3)
                        p00_01.c06_createandaddfilestreamwriter.runaddstreamwriterforfileintolist(p00_01.c04_createnameoffilename.listwithfilenames[0], p00_01.c05_createfile.runcreatefilesuccess, p00_01.c17_msgboxjanein.dialogresultint);

                    //Nur wenn Installation (Update) gewählt wurde.
                    if (p00_01.c17_msgboxjanein.dialogresultint == 1)
                    {
                        //Nachricht in die Ausgabedatei bzgl. Prüfung des Strings für den Pfad zur Quelldatei schreiben.
                        //Nur, wenn p00_01.c06_openfile.runopenfilesuccess=true, ansonsten Programmende.
                        if (p00_01.c06_createandaddfilestreamwriter.runaddstreamwriterforfileintolistsuccess && p00_01.c17_msgboxjanein.dialogresultint != 3)
                            p00_01.c07_savestringinfile.runsavestringinfile(p00_01.c06_createandaddfilestreamwriter.listsw[0], "Überprüfen, ob der Pfad für die Quelldatei nicht leer ist.", p00_01.c06_createandaddfilestreamwriter.runaddstreamwriterforfileintolistsuccess, p00_01.c17_msgboxjanein.dialogresultint);

                        //Überprüfen, ob der Pfad für die Quelldatei nicht leer ist.
                        //Nur, wenn p00_01.c07_savestringinfile.runsavestringinfilesuccess=true, ansonsten Programmende.
                        p00_01.c15_checkstringempty.checkstringempty(p00_02.p01_loaddatafromconfig.sourcefile, p00_01.c07_savestringinfile.runsavestringinfilesuccess, p00_01.c17_msgboxjanein.dialogresultint);

                        //Messagebox ausgeben, falls Benutzer leeren String für Quelldatei in Konfigurationsdatei eingetragen hat.
                        //Nur wenn p00_01.c15_checkstringempty.stringnotemptys=false. In diesem Falle folgt das Programmende.
                        p00_01.c16_msgbox.runmsgboxnegative("Pfad für die Quelldatei ist leer. Programmende. Bitte Informationen in Ausgabedateien nachschauen.", p00_01.c15_checkstringempty.stringempty, p00_01.c17_msgboxjanein.dialogresultint);

                        //Nachricht in die Ausgabedatei bzgl. Quelldatei schreiben
                        //Nur, wenn p00_01.c15_checkstringempty.stringnotemptys=true, ansonsten Programmende 
                        if (p00_01.c17_msgboxjanein.dialogresultint == 1 && p00_01.c15_checkstringempty.stringnotempty)
                        {
                            p00_01.c07_savestringinfile.runsavestringinfile(p00_01.c06_createandaddfilestreamwriter.listsw[0], "Überprüfen, ob ein Zugriff auf die Quelldatei mithilfe der Pfadangabe möglich ist.", p00_01.c15_checkstringempty.stringnotempty, p00_01.c17_msgboxjanein.dialogresultint);
                            //Überprüfen, ob ein Zugriff auf die Quelldatei mit dem nicht-leeren String, der äquivalent zum Pfad der Quelldatei aus
                            //der Konfigurationsdatei sein soll, möglich ist.
                            //Nur, wenn p00_01.c15_checkstringempty.stringnotemptys.
                            p00_01.c01_fileexists.runopenfile(p00_02.p01_loaddatafromconfig.sourcefile, p00_01.c15_checkstringempty.stringnotempty, p00_01.c17_msgboxjanein.dialogresultint);


                            if (p00_01.c01_fileexists.fileexists)
                            {
                                p00_02.p04_variablesfordecisions.installationsdateivorhanden = true;
                            }
                            //Entsprechende Meldung ausgeben, wenn der Pfad zur Quelldatei richtig war oder nicht.
                            //Falls der Pfad zur Quelldatei richtig ist, entsprechende Meldung in die Ausgabedatei schreiben
                            if (p00_02.p04_variablesfordecisions.installationsdateivorhanden)
                            {
                                p00_01.c07_savestringinfile.runsavestringinfile(p00_01.c06_createandaddfilestreamwriter.listsw[0], "Die Quelldatei wurde gefunden.", p00_02.p04_variablesfordecisions.installationsdateivorhanden, p00_01.c17_msgboxjanein.dialogresultint);
                                p00_01.c07_savestringinfile.runsavestringinfile(p00_01.c06_createandaddfilestreamwriter.listsw[0], "Liste der Workstations, für die Updates vorgesehen sind, gemäß Workstatationliste einlesen.", p00_02.p04_variablesfordecisions.installationsdateivorhanden, p00_01.c17_msgboxjanein.dialogresultint);
                            }
                            else
                            {
                                //Falls der Pfad zur Quelldatei nicht richtig ist, entsprechende Meldung in die Ausgabedatei schreiben
                                p00_01.c07_savestringinfile.runsavestringinfile(p00_01.c06_createandaddfilestreamwriter.listsw[0], "Die Quelldatei wurde nicht gefunden.", p00_01.c01_fileexists.filedoesnotexist, p00_01.c17_msgboxjanein.dialogresultint);
                                //Falls der Pfad zur Quelldatei nicht richtig ist, entsprechende Messagebox ausgeben
                                p00_01.c16_msgbox.runmsgboxpositive("Die Installationsdatei wurde nicht gefunden. Programmende. Bitte Informationen in Ausgabedateien nachschauen.", p00_01.c01_fileexists.filedoesnotexist, p00_01.c17_msgboxjanein.dialogresultint);
                            }
                        }
                    }

                    //Ueberpruefen, ob der Pfad zur Datei mit der Workstationliste nicht leer ist.
                    //In die Ausgabedatei schreiben, dass der Pfad zur Datei mit der Workstationliste auf NULL oder Nicht-NULL überprüft wird.
                    //Nur, wenn entweder deinstalliert oder mittels Quelldatei installiert werden soll.
                    if (p00_01.c17_msgboxjanein.dialogresultint==2 || (p00_01.c17_msgboxjanein.dialogresultint==1 && p00_02.p04_variablesfordecisions.installationsdateivorhanden))
                    {
                        p00_01.c07_savestringinfile.runsavestringinfile(p00_01.c06_createandaddfilestreamwriter.listsw[0], "Überprüfen, ob der Pfad für die Datei, die die Liste für die Workstations enthält, nicht leer ist.", p00_01.c01_fileexists.fileexists, p00_01.c17_msgboxjanein.dialogresultint);

                        //Überprüfen, ob der Pfad für die Datei mit der Workstationliste nicht leer ist.
                        //Nur, wenn p00_01.c07_savestringinfile.runsavestringinfilesuccess=true, ansonsten Programmende.
                        p00_01.c15_checkstringempty.checkstringempty(p00_02.p01_loaddatafromconfig.workstationlist, p00_01.c07_savestringinfile.runsavestringinfilesuccess, p00_01.c17_msgboxjanein.dialogresultint);

                        //Messagebox ausgeben, falls Benutzer leeren String für Datei mit der Workstationliste in Konfigurationsdatei eingetragen hat.
                        //Nur wenn p00_01.c15_checkstringempty.stringnotemptys=false. In diesem Falle folgt das Programmende.
                        p00_01.c16_msgbox.runmsgboxnegative("Pfad für die Datei mit der Workstationliste ist leer. Programmende. Bitte Informationen in Ausgabedateien nachschauen.", p00_01.c15_checkstringempty.stringempty, p00_01.c17_msgboxjanein.dialogresultint);

                        //Nachricht in die Ausgabedatei bzgl. Datei mit der Workstationliste schreiben
                        //Nur, wenn p00_01.c15_checkstringempty.stringnotemptys=true, ansonsten Programmende 
                        if (p00_01.c15_checkstringempty.stringnotempty && p00_01.c17_msgboxjanein.dialogresultint != 3)
                            p00_01.c07_savestringinfile.runsavestringinfile(p00_01.c06_createandaddfilestreamwriter.listsw[0], "Überprüfen, ob ein Zugriff auf die Datei mit der Workstationliste möglich ist.", p00_01.c15_checkstringempty.stringnotempty, p00_01.c17_msgboxjanein.dialogresultint);

                        //Überprüfen, ob ein Zugriff auf die Datei mit der Workstationliste mit dem nicht-leeren String, der äquivalent zum Pfad
                        //der Datei mit der Workstationliste aus der Konfigurationsdatei sein soll, möglich ist.
                        //Nur, wenn p00_01.c15_checkstringempty.stringnotemptys=false, ansonsten Programmende.
                        p00_01.c01_fileexists.runopenfile(p00_02.p01_loaddatafromconfig.workstationlist, p00_01.c07_savestringinfile.runsavestringinfilesuccess, p00_01.c17_msgboxjanein.dialogresultint);

                        //Entsprechende Meldung ausgeben, wenn der Pfad zur Datei mit der Workstationliste richtig war oder nicht.
                        //Falls der Pfad zur Datei mit der Workstationliste richtig ist, entsprechende Meldung in die Ausgabedatei schreiben
                        if (p00_01.c01_fileexists.fileexists && p00_01.c17_msgboxjanein.dialogresultint != 3)
                            p00_01.c07_savestringinfile.runsavestringinfile(p00_01.c06_createandaddfilestreamwriter.listsw[0], "Die Datei mit der Workstationliste wurde gefunden.", p00_01.c01_fileexists.fileexists, p00_01.c17_msgboxjanein.dialogresultint);

                        if (p00_01.c01_fileexists.fileexists)
                        {
                            p00_02.p04_variablesfordecisions.workstationfilevorhanden = true;
                        }

                        //Falls der Pfad zur Datei mit der Workstationliste nicht richtig ist, entsprechende Meldung in die Ausgabedatei schreiben.
                        if (p00_02.p04_variablesfordecisions.workstationfilevorhanden==false && p00_01.c17_msgboxjanein.dialogresultint != 3) { 
                            p00_01.c07_savestringinfile.runsavestringinfile(p00_01.c06_createandaddfilestreamwriter.listsw[0], "Die Datei mit der Workstationliste wurde nicht gefunden.", p00_01.c01_fileexists.filedoesnotexist, p00_01.c17_msgboxjanein.dialogresultint);
                            //Falls der Pfad zur Datei mit der Workstationliste nicht richtig ist, entsprechende Messagebox ausgeben.
                            p00_01.c16_msgbox.runmsgboxpositive("Die Datei mit der Workstationliste wurde nicht gefunden. Programmende. Bitte Informationen in Ausgabedateien nachschauen.", p00_01.c01_fileexists.filedoesnotexist, p00_01.c17_msgboxjanein.dialogresultint);
                        }

                        if (p00_02.p04_variablesfordecisions.workstationfilevorhanden)
                        {
                            //Es wird der Versuch unternommen, den Inhalt der Datei, welche die Workstationliste enthält, einzulesen.
                            //Dies geschieht aber nur in dem Fall, dass diese Datei vorher gefunden werden konnte.
                            //Sollte dieser Versuch misslingen, so erfolgt ein Programmabbruch.

                            //Entsprechende Meldung in die Ausgabedatei schreiben
                            if (p00_02.p04_variablesfordecisions.konfigurationsdateivorhanden && p00_01.c01_fileexists.filedoesnotexist && p00_01.c17_msgboxjanein.dialogresultint != 3)
                                p00_01.c07_savestringinfile.runsavestringinfile(p00_01.c06_createandaddfilestreamwriter.listsw[0], "Es wird der Versuch unternommen, den Inhalt der Datei, welche die Workstationliste enthält, einzulesen.", p00_01.c01_fileexists.fileexists, p00_01.c17_msgboxjanein.dialogresultint);

                            //Einlesen der Workstationliste
                            p00_01.c02_readalllinesfromtextfile.runreadalllinesfromfile(p00_02.p01_loaddatafromconfig.workstationlist, p00_01.c01_fileexists.fileexists, p00_01.c17_msgboxjanein.dialogresultint);

                            //Übergebe die Liste an eine eigens für die Workstationliste vorgesehene Datenstruktur
                            p00_02.p02_loaddatafromworkstationlist.runsavedatafromworkstationlist(p00_01.c02_readalllinesfromtextfile.readalllinesfromtextfile, p00_01.c02_readalllinesfromtextfile.runreadalllinesfromtextfilesuccess, p00_01.c17_msgboxjanein.dialogresultint);
                        }

                        //Nur im Falle, dass eine Installation (Update) ausgewählt wurde.
                        if (p00_01.c17_msgboxjanein.dialogresultint == 1)
                        {
                            //Meldung, dass eine Ausgabedatei erstellt wird, in die alle Workstations eingetragen werden, für die die Installation nicht funktionieren wird.
                            //Das wird nur erledigt, wenn zuvor ein Speichern der Liste der Workstations in das obige Array mithilfe "p00_01.p02_loaddatafromworkstationlist.runsavedatafromworkstationlist" erfolgte.

                            if (p00_02.p02_loaddatafromworkstationlist.runsavedatafromworkstationlistsuccess && p00_01.c17_msgboxjanein.dialogresultint != 3)
                                p00_01.c07_savestringinfile.runsavestringinfile(p00_01.c06_createandaddfilestreamwriter.listsw[0], "Es wird eine Ausgabedatei erstellt zur Speicherung der Workstations in einer Liste, für die die Installation nicht erfolgreich ist."
                                + " Diese Liste ist für einen nachfolgenden Installationsversuch zu verwenden.", p00_02.p02_loaddatafromworkstationlist.runsavedatafromworkstationlistsuccess, p00_01.c17_msgboxjanein.dialogresultint);

                            //Diese Ausgabedatei erzeugen
                            p00_01.c04_createnameoffilename.runcreatepartoffilename(p00_02.p01_loaddatafromconfig.pathtooutputworkstationfile, "output_no_installation", ".txt", p00_01.c02_readalllinesfromtextfile.runreadalllinesfromtextfilesuccess, p00_01.c17_msgboxjanein.dialogresultint);
                            if (p00_01.c04_createnameoffilename.runcreatepartoffilenamesuccess && p00_01.c17_msgboxjanein.dialogresultint != 3)
                            {
                                p00_01.c05_createfile.runcreatefile(p00_01.c04_createnameoffilename.listwithfilenames[1], p00_01.c04_createnameoffilename.runcreatepartoffilenamesuccess, p00_01.c17_msgboxjanein.dialogresultint);

                                if (p00_01.c05_createfile.runcreatefilesuccess)
                                {
                                    p00_02.p04_variablesfordecisions.workstationfilecouldbecreated = true;
                                    p00_01.c16_msgbox.runmsgboxnegative("Datei für eine Liste von Workstations,"
                                        + " für die die Installation "
                                        + " ggf. nicht erfolgreich sein wird, unter '"
                                        + p00_01.c04_createnameoffilename.listwithfilenames[1]
                                        + "' erstellt. Bitte diese Liste als Liste für Workstations, für die eine Installation ansteht,"
                                        + " im weiteren Verlauf nach Programmende verwenden.", true, 1);
                                }
                                else
                                {
                                    p00_01.c16_msgbox.runmsgboxnegative("Pfad für eine Liste von Workstations,"
                                        + " für die die Installation "
                                        + " ggf. nicht erfolgreich sein wird, in '"
                                        + p00_01.c04_createnameoffilename.listwithfilenames[1]
                                        + "' falsch. Bitte korrigieren. Programmende.", true, 1);
                                }
                            }
                        }
                        //Falls die Liste mit den Workstations erstellt werden konnte, die die Workstations beinhaltet
                        //die nicht für eine Installation berücksichtigt werden konnten oder falls PMI von Workstations
                        //deinstalliert werden soll, dann eine Schleife durch alle Workstations machen, um je nach Wahl
                        //in der obersten Messagebox die Installation oder Deinstallation von PMI durchzuführen.
                        if (p00_02.p04_variablesfordecisions.workstationfilecouldbecreated ||
                            (p00_01.c17_msgboxjanein.dialogresultint == 2 && p00_02.p04_variablesfordecisions.workstationfilevorhanden))
                        {
                            //Wenn die Kopie der Workstations in das Workstationarray erfolgreich erfolgte, dann führe die Installation für
                            //jede in dem Workstationarray vorhandene Workstation aus.
                            p00_02.p03_runthroughtheworkstationarray.runthroughtheworkstationarray(p00_02.p01_loaddatafromconfig,
                                p00_02.p02_loaddatafromworkstationlist,
                                p00_01.c07_savestringinfile, p00_01.c06_createandaddfilestreamwriter, p00_01.c02_readalllinesfromtextfile,
                                p00_01.c08_workstationprozesstest, p00_01.c09_zielpfad, p00_01.c10_istquelldateiremote,
                                p00_01.c11_loeschequelldateiremote, p00_01.c12_kopierequelldateinachremote, p00_01.c13_deinstallation,
                                p00_01.c14_installation, p00_01.c15_checkstringempty,
                                p00_01.c16_msgbox, p00_01.c02_readalllinesfromtextfile.runreadalllinesfromtextfilesuccess,
                                p00_01.c03_loginwithprompt.benutzername, p00_01.c03_loginwithprompt.passwort, p00_01.c17_msgboxjanein.dialogresultint);
                        }
                    }//Nur wenn Deinstlallation gewählt oder eine Instllation mit gefundener Quelldatei gewählt wurde -Ende-
                } //Dateierstellung wegen Angabe von korrekten Ausgabedateipfaden in der Konfigurationsdatei möglich -Ende-
            } //Benutzername vorhanden -Ende-
        } //Konfigurationsdatei ist vorhanden -Ende-
    } //static void main -Ende 
} //class p00_00_main -Ende-