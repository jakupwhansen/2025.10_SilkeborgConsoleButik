using System.Reflection.Metadata;

Console.WriteLine();
Butik butik = new Butik();
butik.GUI();
class Butik
{
    private Lager lager = new Lager();

    public void GUI()
    {
        Console.WriteLine("Velkommen til min butik");
        List<Vare> kurv = new List<Vare>();
        while (true)
        {
            Console.WriteLine("Du kan købe ved at indtaste vare nummer og trykke enter. Vil du betale skriv X og så enter");
            string ind = Console.ReadLine();
            if(ind=="X")
            {
                break;
            }
            int vareID = Convert.ToInt32(ind);
            Vare vare = købeVare(vareID);
            if(vare != null)
            {
                kurv.Add(vare);
                Console.WriteLine(vare.printVare());
            }
        }
        //Vi har nu købt færdig, nu skal du udskrive samlet PRIS på alle varer i kurven.
        int i = 0;
        double sum = 0;
        while (i < kurv.Count)
        {
            Vare lokal = kurv[i];
            sum = sum + lokal.pris;
            i = i + 1;
        }
        Console.WriteLine( "Summen er: "+ sum );

    }
    public Vare købeVare(int id)
    {
        return lager.hentVare(id);
    }
}
class Lager
{
    private List<Vare> beholdning = new List<Vare>();
    public Lager()
    {
        fyldLager();
    }
    public Vare hentVare(int id)
    {
        Vare svar = null;
        //-----OPGVE-------------------
        int i = 0;
        while (i < beholdning.Count)
        {
            Vare lokal = beholdning[i];
            if (lokal.id == id)
            {
                svar = lokal;
                break;
            }
            i = i + 1;
        }
        return svar;
    }
    public void fyldLager()
    {
        //--Nu skal du fylde varer ind i beholdning listen. Lav 3 bananer, 4 Chips og 2 mælk)
        Vare v = new Vare();
        v.id = 1;
        v.navn = "Banan";
        v.pris = 4.3;

        beholdning.Add(v);//Tilføjere ét objekt af typen Vare
        v = new Vare();
        v.id = 1;
        v.navn = "Banan";
        v.pris = 4.3;

        beholdning.Add(v);//Tilføjere ét objekt af typen Vare
        v = new Vare();
        v.id = 1;
        v.navn = "Banan";
        v.pris = 4.5;

        beholdning.Add(v);//Tilføjere ét objekt af typen Vare
        v = new Vare();
        v.id = 1;
        v.navn = "Banan";
        v.pris = 4.8;

        beholdning.Add(v);//Tilføjere ét objekt af typen Vare

        //Chips
        v = new Vare();
        v.id = 2;
        v.navn = "Chips";
        v.pris = 12.7;

        beholdning.Add(v);//Tilføjere ét objekt af typen Vare
        //Chips
        v = new Vare();
        v.id = 2;
        v.navn = "Chips";
        v.pris = 12.7;

        beholdning.Add(v);//Tilføjere ét objekt af typen Vare
        //Chips
        v = new Vare();
        v.id = 2;
        v.navn = "Chips";
        v.pris = 12.7;

        beholdning.Add(v);//Tilføjere ét objekt af typen Vare
        //Chips
        v = new Vare();
        v.id = 2;
        v.navn = "Chips";
        v.pris = 12.7;

        beholdning.Add(v);//Tilføjere ét objekt af typen Vare
                          //---MÆLK

        v = new Vare();
        v.id = 3;
        v.navn = "Mælk";
        v.pris = 8.0;

        beholdning.Add(v);//Tilføjere ét objekt af typen Vare
        v = new Vare();
        v.id = 3;
        v.navn = "Mælk";
        v.pris = 8.0;

        beholdning.Add(v);//Tilføjere ét objekt af typen Vare

        TilbudsVare tb1 = new TilbudsVare();
        tb1.id = 10;
        tb1.pris = 35;
        tb1.navn = "Kaffe tilbud";
        tb1.procenter = 20;
        beholdning.Add(tb1);
    }
}
class TilbudsVare:Vare
{
    public int procenter = 20;
    public override string printVare()
    {
        return "TILBUD på procenter:"+procenter+ " id:" + id + " navn:" + navn + " pris:" + pris;

    }
}

class Vare
{
    public int id;
    public string navn;
    public double pris;
    public virtual string printVare()
    {
        return "id:" + id + " navn:" + navn + " pris:" + pris;
    }
}